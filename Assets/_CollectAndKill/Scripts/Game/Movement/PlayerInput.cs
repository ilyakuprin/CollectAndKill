using Photon.Pun;
using UnityEngine;

namespace CollectAndKill
{
    [RequireComponent(typeof(PhotonView))]
    public class PlayerInput : MonoBehaviour
    {
        public delegate void Move(Vector3 moveDirection);
        public event Move Moved;

        private JoystickMovement _joystickMovement;
        private PhotonView _photonView;

        public JoystickMovement GetJoystickMovement { get => _joystickMovement; }

        private void Awake()
        {
            _joystickMovement = FindObjectOfType<JoystickMovement>();
            _photonView = GetComponent<PhotonView>();
        }

        private void Update()
        {
            if (_photonView.IsMine)
            {
                Moved?.Invoke(_joystickMovement.ToMove());
            }
        }
    }
}
