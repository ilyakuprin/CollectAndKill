using Photon.Pun;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CollectAndKill
{
    public class WinHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _winWindow;
        [SerializeField] private Text _nickname;
        [SerializeField] private Text _countCoin;
        private List<GameObject> _players = new();
        private int _countPlayers = 0;

        public void BirthPlayer(GameObject player)
        {
            _countPlayers++;
            _players.Add(player);
        }

        public void DeathPlayer(GameObject player)
        {
            _countPlayers--;
            
            for (int i = 0; i < _players.Count; i++)
            {
                if (player == _players[i])
                {
                    _players.RemoveAt(i);
                    break;
                }
            }

            if (_countPlayers <= 1)
            {
                _winWindow.SetActive(true);
                _nickname.text = _players[0].GetComponent<PhotonView>().Owner.NickName;
                _countCoin.text = _players[0].GetComponent<CoinPicker>().GetCoinCount.ToString();
            }
        }

        public void EscapeFromRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
    }
}
