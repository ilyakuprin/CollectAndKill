using System.Collections;
using UnityEngine;

namespace CollectAndKill
{
    public class AttackClickHandler : MonoBehaviour
    {
        private bool _canShoot = true;
        private readonly float _timeRecharge = 1;

        public bool CanShoot { get => _canShoot; set => _canShoot = value; }

        private void Awake()
        {
            StartCoroutine(Recharge());
        }

        private IEnumerator Recharge()
        {
            WaitForSeconds wait = new (_timeRecharge);

            while (true)
            {
                if (!_canShoot)
                {
                    yield return wait;
                    _canShoot = true;
                }

                yield return null;
            }
        }
    }
}
