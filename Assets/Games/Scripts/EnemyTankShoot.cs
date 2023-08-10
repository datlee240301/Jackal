using System.Collections;
using UnityEngine;

namespace io.lockedroom.Games.Jackal {
    public class EnemyTankShoot : MonoBehaviour {
        public Transform ShootingPoint;
        public GameObject Bullet;
        public bool IsShooting;
        private Transform Target;

        void Start() {
            IsShooting = true;
            StartCoroutine(ShootBullets());
        }
        private void Update() {
            Target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        private IEnumerator ShootBullets() {
            while (IsShooting) {
                if (Target != null) {
                    if (Vector2.Distance(Target.position, transform.position) <= 10f) {
                        for (int i = 0; i < 3; i++) {
                            Instantiate(Bullet, ShootingPoint.position, transform.rotation);
                            yield return new WaitForSeconds(0.1f); // time between each bullet
                        }
                        yield return new WaitForSeconds(1.25f); // time between each shot
                    }
                }
                yield return null;
            }
        }
    }
}
