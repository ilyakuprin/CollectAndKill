using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace CollectAndKill
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private GameObject _patronPrefab;
        [SerializeField] private GameObject _shootPoint;
        private AttackClickHandler _attackClickHandler;
        private Button _buttonClickHandler;

        private void Awake()
        {
            _attackClickHandler = FindObjectOfType<AttackClickHandler>();
            _buttonClickHandler = _attackClickHandler.GetComponent<Button>();
        }

        private void CreatPatron()
        {
            if (_attackClickHandler.CanShoot)
            {
                PhotonNetwork.Instantiate(_patronPrefab.name, _shootPoint.transform.position, transform.rotation);
                _attackClickHandler.CanShoot = false;
            }
        }

        private void OnEnable()
        {
            _buttonClickHandler.onClick.AddListener(CreatPatron);
        }

        private void OnDisable()
        {
            _buttonClickHandler.onClick.RemoveListener(CreatPatron);
        }
    }
}
