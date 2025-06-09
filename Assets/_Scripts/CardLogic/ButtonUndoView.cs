using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.CardLogic
{
    public class ButtonUndoView : MonoBehaviour
    {
        [SerializeField] private Button _click;

        public event Action OnClick;
        
        public void Awake()
        {
            _click.onClick.AddListener(ClickButton);
        }

        private void ClickButton()
        {
            OnClick?.Invoke();
        }
    }
}