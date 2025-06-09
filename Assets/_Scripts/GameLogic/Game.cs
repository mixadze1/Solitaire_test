using System.Collections.Generic;
using _Scripts.CardLogic;
using UnityEngine;
using Zenject;

namespace _Scripts.GameLogic
{
    public class Game : MonoBehaviour
    {
        private GameConfig _gameConfig;
        private GeneratorCards _generatorCards;
        private SpotsController _spotsController;
        
        [Inject]
        private void Construct(GameConfig gameConfig, GeneratorCards generatorCards, SpotsController spotsController)
        {
            _spotsController = spotsController;
            _generatorCards = generatorCards;
            _gameConfig = gameConfig;
        }
        
        private void Start()
        {
            var cards = GenerateCards(_gameConfig);
            _spotsController.Initialize(cards, _gameConfig);
        }

        private List<CardView> GenerateCards(GameConfig gameConfig)
        {
            return _generatorCards.GenerateCards(gameConfig.AmountCardsInGame);
        }
    }
}
