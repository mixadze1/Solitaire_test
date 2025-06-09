using System.Collections.Generic;
using _Scripts.GameLogic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.CardLogic
{
    public class SpotsController : MonoBehaviour
    {
        [SerializeField] private ButtonUndoView _buttonUndo;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private List<Spot> _spots;

        private readonly Stack<MoveAction> _moveHistory = new();
        private GameConfig _gameConfig;

        public void Initialize(List<CardView> cards, GameConfig config)
        {
            _gameConfig = config;

            _buttonUndo.OnClick += UndoLastAction;
            foreach (var spot in _spots)
            {
                spot.Initialize(config, Camera.main, _canvas);
                spot.OnCardMoved += RegisterMove; 
            }

            for (int i = 0; i < cards.Count; i++)
            {
                var spot = _spots[i % _spots.Count];
                spot.AddCard(cards[i]);
                cards[i].Initialize(GetRandomCardNumber(_gameConfig));
            }
            
            Logger.Log("[Spots controller] initialized!", Color.white);
        }

        private static int GetRandomCardNumber(GameConfig gameConfig) =>
            Random.Range(gameConfig.MinMaxValueCard.x, gameConfig.MinMaxValueCard.y);

        private void RegisterMove(Spot from, Spot to, CardView card)
        {
            from.RemoveCard(card); 
            to.AddCard(card);
            _moveHistory.Push(new MoveAction { From = from, To = to, Card = card });
            Logger.Log($"[Spots controller] Add move history From: {from.name}, To: {to.name}, card Value: {card.ValueCard}, Amount:{_moveHistory.Count}.", Color.green);
        }

        private void UndoLastAction()
        {
            if (_moveHistory.Count > 0)
            {
                var action = _moveHistory.Pop();
                Logger.Log($"[Spots controller] Undo: {action.From.name}, To:{action.To.name}, Card:{action.Card.ValueCard}, Amount:{_moveHistory.Count}.", Color.green);
                action.Undo();
                return;
            }
            
            Logger.Log($"[Spots Controller] Can't execute undo. Amount actions: {_moveHistory.Count}", Color.yellow);
        }

        private void OnDestroy()
        {
            _buttonUndo.OnClick -= UndoLastAction;

            foreach (var spot in _spots)
            {
                spot.OnCardMoved -= RegisterMove;

            }
        }
    }
}