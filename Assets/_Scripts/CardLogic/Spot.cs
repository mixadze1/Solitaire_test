using System;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.GameLogic;

namespace _Scripts.CardLogic
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Spot : MonoBehaviour
    {
        [SerializeField] private RectTransform _container;

        private readonly List<CardView> _cards = new();
        private float _cardYOffset;

        private bool _isDragging;
        private CardView _draggingCard;
        private Camera _camera;
        private Canvas _canvas;
        public event Action<Spot, Spot, CardView> OnCardMoved;
        
        public void Initialize(GameConfig config, Camera camera, Canvas canvas)
        {
            _camera = camera;
            _canvas = canvas;
            _cardYOffset = config.CardYOffset;
        }

        public void AddCard(CardView card)
        {
            _cards.Add(card);
            card.transform.SetParent(_container, false);
            UpdateCardPositions();
        }

        public void RemoveCard(CardView card)
        {
            _cards.Remove(card);
            UpdateCardPositions();
        }

        private void Update()
        {
            if (_isDragging && _draggingCard != null)
            {
                Vector3 globalMousePos;
                if (RectTransformUtility.ScreenPointToWorldPointInRectangle(
                        _canvas.transform as RectTransform,
                        Input.mousePosition,
                        _canvas.worldCamera,
                        out globalMousePos))
                {
                    _draggingCard.transform.position = globalMousePos;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    FinishDrag();
                }
            }
        }

        private void OnMouseDown()
        {
            if (_cards.Count == 0 || _isDragging)
                return;

            _draggingCard = _cards[^1];
            _isDragging = true;

            _draggingCard.transform.SetAsLastSibling();
        }

        private void FinishDrag()
        {
            _isDragging = false;

            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction);
            var targetSpot = hit.collider?.GetComponent<Spot>();

            if (targetSpot != null && targetSpot != this)
            {
                OnCardMoved?.Invoke(this, targetSpot, _draggingCard);
            }
            else
            {
                UpdateCardPositions();
            }

            _draggingCard = null;
        }
        
        private void UpdateCardPositions()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                var rect = _cards[i].GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(0, -_cardYOffset * i);
            }
        }
    }
}
