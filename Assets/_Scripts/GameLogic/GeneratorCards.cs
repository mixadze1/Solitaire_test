using System.Collections.Generic;
using UnityEngine;
using _Scripts.CardLogic;

namespace _Scripts.GameLogic
{
    public class GeneratorCards
    {
        private readonly string ResourcePath = "Prefabs/CardView";

        public List<CardView> GenerateCards(int amount)
        {
            var cardPrefab = Resources.Load<CardView>(ResourcePath);
            var cardList = new List<CardView>();

            if (cardPrefab == null)
            {
                Debug.LogError($"Card prefab not found at Resources/{ResourcePath}");
                return cardList;
            }

            for (int i = 0; i < amount; i++)
            {
                var instance = Object.Instantiate(cardPrefab);
                cardList.Add(instance);
            }

            return cardList;
        }
    }
}