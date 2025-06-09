using System.Collections.Generic;
using _Scripts.GameLogic;
using UnityEngine;

namespace _Scripts.CardLogic
{
    public class SpotsController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private List<Spot> _spots;
        private GameConfig _gameConfig;

        public void Initialize(List<CardView> cards, GameConfig config)
        {
            _gameConfig = config;

            foreach (var spot in _spots)
                spot.Initialize(config, _camera, _canvas);

            for (int i = 0; i < cards.Count; i++)
            {
                var spot = _spots[i % _spots.Count];
                spot.AddCard(cards[i]);
                cards[i].Initialize(GetRandomCardNumber(_gameConfig));
            }
        }

        private static int GetRandomCardNumber(GameConfig gameConfig) =>
            Random.Range(gameConfig.MinMaxValueCard.x, gameConfig.MinMaxValueCard.y);
    }
}