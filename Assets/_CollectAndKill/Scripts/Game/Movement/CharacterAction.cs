using UnityEngine;

namespace CollectAndKill
{
    [RequireComponent(typeof(PlayerInput))]
    public abstract class CharacterAction : MonoBehaviour
    {
        private PlayerInput _playerInput;

        protected virtual void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        protected abstract void Execute(Vector3 moveDirection);

        private void OnEnable()
        {
            _playerInput.Moved += Execute;
        }

        private void OnDisable()
        {
            _playerInput.Moved -= Execute;
        }
    }
}
