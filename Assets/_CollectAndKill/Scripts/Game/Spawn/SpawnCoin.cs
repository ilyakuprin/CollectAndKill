using Photon.Pun;
using UnityEngine;

namespace CollectAndKill
{
    public class SpawnCoin : MonoBehaviour
    {
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private int _numberCoins;
        [SerializeField] private float _minX, _minZ, _maxX, _maxZ;

        private readonly float _positionY = 1;

        public int NumberCoins { get => _numberCoins; }

        private void Awake()
        {
            for (int i = 0; i < _numberCoins; i++)
            {
                Vector3 randomPosition = new(Random.Range(_minX, _maxX), _positionY, Random.Range(_minZ, _maxZ));
                PhotonNetwork.Instantiate(_coinPrefab.name, randomPosition, Quaternion.identity);
            }
        }

        private void OnValidate()
        {
            if (_numberCoins < 0)
            {
                _numberCoins = 0;
            }
        }
    }
}
