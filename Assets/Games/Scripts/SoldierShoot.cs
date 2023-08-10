using UnityEngine;

namespace io.lockedroom.Games.Jackal {
    public class SoldierShoot : MonoBehaviour {
        public Transform ShootingPoint;
        public GameObject Bullet;
        public bool IsShooting;
        private Transform Target;
        private float ShootingInterval = 2f;
        private float shootingTimer = 0f;

        void Start() {
            IsShooting = true;
        }
        void Update() {
            Target = GameObject.FindGameObjectWithTag("Player").transform;
            if (IsShooting) {
                if (Vector2.Distance(Target.position, transform.position) <= 10f) {
                    if (shootingTimer <= 0f) {
                        Instantiate(Bullet, ShootingPoint.position, transform.rotation);
                        shootingTimer = ShootingInterval;
                    } else {
                        shootingTimer -= Time.deltaTime;
                    }
                }
            }
        }
    }
}
