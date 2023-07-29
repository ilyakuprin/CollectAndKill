using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

namespace CollectAndKill
{
    public class SpawnPlayer : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _playersPrefabs;
        [SerializeField] private List<Sprite> _playersSprites;
        [SerializeField] private float _minX, _minZ, _maxX, _maxZ;

        private readonly float _positionY = 1;

        private void Awake()
        {
            Vector3 randomPosition = new(Random.Range(_minX, _maxX), _positionY, Random.Range(_minZ, _maxZ));
            int index = new System.Random().Next(_playersPrefabs.Count);
            GameObject player = PhotonNetwork.Instantiate(_playersPrefabs[index].name, randomPosition, Quaternion.identity);

            TransferMaxCoin(player);
            TransferSprite(player, index);
        }

        private void TransferMaxCoin(GameObject player)
        {
            player.GetComponent<CoinPicker>().MaxCoin = GetComponent<SpawnCoin>().NumberCoins;
        }

        private void TransferSprite(GameObject player, int index)
        {
            player.GetComponent<GettingIndicatorsUi>().Icon = _playersSprites[index];
        }
    }
}
