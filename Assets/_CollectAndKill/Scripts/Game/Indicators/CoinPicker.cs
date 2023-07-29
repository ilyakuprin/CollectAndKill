using UnityEngine;

namespace CollectAndKill
{
    public class CoinPicker : MonoBehaviour
    {
        public delegate void TakeCoin(int value);
        public event TakeCoin CoinTaken;

        private readonly StringTags _stringTags = new();
        private int _coinCounter = 0;
        private int _maxCoin;

        public int MaxCoin { get => _maxCoin; set => _maxCoin = value; }
        public int GetCoinCount { get => _coinCounter; }

        private void AddCoin()
        {
            _coinCounter++;
            CoinTaken?.Invoke(_coinCounter);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(_stringTags.TagCoin))
            {
                AddCoin();
                Destroy(other.gameObject);
            }
        }
    }
}
