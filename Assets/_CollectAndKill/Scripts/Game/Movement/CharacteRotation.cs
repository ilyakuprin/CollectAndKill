using UnityEngine;

namespace CollectAndKill
{
    public class CharacteRotation : CharacterAction
    {
        [SerializeField] private float _rotateSpeed;

        protected override void Execute(Vector3 moveDirection)
        {
            if (Vector3.Angle(transform.forward, moveDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }

        private void OnValidate()
        {
            if (_rotateSpeed < 0)
            {
                _rotateSpeed = 0;
            }
        }
    }
}
