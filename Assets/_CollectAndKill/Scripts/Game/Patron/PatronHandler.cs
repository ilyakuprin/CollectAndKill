using CollectAndKill;
using Photon.Pun;
using UnityEngine;

public class PatronHandler : MonoBehaviourPun
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out HealthHandler healthHandler))
        {
            healthHandler.ReduceHealth(_damage);
            Destroy(gameObject);
        }
    }
}
