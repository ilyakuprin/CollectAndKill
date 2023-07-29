using UnityEngine;

namespace CollectAndKill
{
    public class BirthAndDeath : MonoBehaviour
    {
        private WinHandler _winHandler;

        private void Awake()
        {
            _winHandler = FindObjectOfType<WinHandler>();
        }

        private void Start()
        {
            _winHandler.BirthPlayer(gameObject);
        }

        private void OnDestroy()
        {
            _winHandler.DeathPlayer(gameObject);
        }
    }
}
