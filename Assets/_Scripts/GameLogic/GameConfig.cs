using UnityEngine;

namespace _Scripts.GameLogic
{
    [CreateAssetMenu(menuName = "Configs/GameConfig", fileName = nameof(GameConfig))]

    public class GameConfig : ScriptableObject
    {
        [SerializeField, Range(1,100)] private int _amountCardsInGame;
        [SerializeField] private Vector2Int _minMaxValueCard;
        [SerializeField] private float _cardYOffset = 30f;
        
        public float CardYOffset => _cardYOffset;
        public int AmountCardsInGame => _amountCardsInGame;

        public Vector2Int MinMaxValueCard
        {
            get
            {
                if (_minMaxValueCard.x < 0 || _minMaxValueCard.y < 0)
                {
                    Debug.LogError($"You are setup not correct values min max card value! min: {_minMaxValueCard.x}, max: {MinMaxValueCard.y}");
                    return new Vector2Int(-1, -1);
                }
                return _minMaxValueCard;
            }
        }
    }
}