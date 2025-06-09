using TMPro;
using UnityEngine;

namespace _Scripts.CardLogic
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _numberView;

        public void Initialize(int numberCard)
        {
            _numberView.text = numberCard.ToString();
        }
    }
}