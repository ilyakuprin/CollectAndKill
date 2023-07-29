using UnityEngine;
using UnityEngine.UI;

namespace CollectAndKill
{
    public class IndicatorVisualization : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] private float _startFillAmount;
        private Image _image;
        private int _maxValue;

        public int MaxValue { set => _maxValue = value; }

        private void Awake()
        {
            _image = GetComponent<Image>();
            _image.fillAmount = _startFillAmount;
        }

        public void ChangeIndicator(int value)
        {
            _image.fillAmount = (float) value / _maxValue;
        }
    }
}
