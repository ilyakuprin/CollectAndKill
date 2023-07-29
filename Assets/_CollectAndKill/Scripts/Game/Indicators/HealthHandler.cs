using UnityEngine;

namespace CollectAndKill
{
    public class HealthHandler : MonoBehaviour
    {
        public delegate void TakeDamage(int value);
        public event TakeDamage DamageTaken;

        private readonly int _maxHealth = 10;
        private int _currentHealth = 10;

        public int GetMaxHealth { get => _maxHealth; }

        public void ReduceHealth(int value)
        {
            _currentHealth -= value;

            if (_currentHealth < 0)
            {
                _currentHealth = 0;
                Die();
            }
            else
            {
                DamageTaken?.Invoke(_currentHealth);
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
