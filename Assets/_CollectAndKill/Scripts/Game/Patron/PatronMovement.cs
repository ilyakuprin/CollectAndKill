using UnityEngine;

namespace CollectAndKill
{
    public class PatronMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _rigidbody.velocity = transform.forward * _speed;
        }

        private void OnValidate()
        {
            if (_speed < 0)
            {
                _speed = 0;
            }
        }
    }
}
