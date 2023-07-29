using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CollectAndKill
{
    public class PlayersWaiting : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private readonly int _numberPlayersToStart = 2;
        private readonly int _countdownStart = 3;
        private readonly int _oneSec = 1;

        private void Awake()
        {
            gameObject.SetActive(true);
        }

        private void Start()
        {
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            while (PhotonNetwork.CurrentRoom.PlayerCount < _numberPlayersToStart)
            {
                yield return null;
            }

            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            WaitForSeconds waitSec = new WaitForSeconds(_oneSec);

            for (int i = _countdownStart; i > 0; i--)
            {
                _text.text = i.ToString();
                yield return waitSec;
            }

            gameObject.SetActive(false);
        }
    }
}
