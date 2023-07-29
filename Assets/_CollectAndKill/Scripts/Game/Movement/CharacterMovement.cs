using UnityEngine;

namespace CollectAndKill
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : CharacterAction
    {
        [SerializeField] private float _moveSpeed;
        private CharacterController _characterController;

        protected override void Awake()
        {
            base.Awake();

            _characterController = GetComponent<CharacterController>();
        }

        protected override void Execute(Vector3 moveDirection)
        {
            moveDirection *= _moveSpeed;
            _characterController.Move(moveDirection * Time.deltaTime);
        }

        private void OnValidate()
        {
            if (_moveSpeed < 0)
            {
                _moveSpeed = 0;
            }
        }

        public void OMGOMG(Vector3 moveDirection)
        {
            Move(moveDirection);
            Rotate(moveDirection);
        }

        private void Move(Vector3 moveDirection)
        {
            moveDirection *= _moveSpeed;
            _characterController.Move(moveDirection * Time.deltaTime);
        }

        private void Rotate(Vector3 moveDirection)
        {
            if (Vector3.Angle(transform.forward, moveDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, 10, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }
}
