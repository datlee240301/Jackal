using System.Collections;
using UnityEngine;
namespace io.lockedroom.Games.Jackal {
    public class TankTurret : MonoBehaviour {
        private Transform Target;
        private bool Detected;
        Vector2 Direction;
        public float Range;
        public GameObject Gun;
        private Transform TargetBullet;
        public GameObject Grenade;
        public float timeToDie;
        private Transform MissleTarget;
        public EnemyTankShoot enemyTankShoot;
        private Animator ani;
        // Start is called before the first frame update
        void Start() {
            enemyTankShoot = GetComponent<EnemyTankShoot>();
            ani = GetComponent<Animator>(); 
        }

        // Update is called once per frame
        void Update() {
            TargetBullet = GameObject.FindGameObjectWithTag("Bullet2").transform;
        }
        private void OnDrawGizmosSelected() {
            Gizmos.DrawWireSphere(transform.position, Range);
        }
        private void FixedUpdate() {
            Target = GameObject.FindGameObjectWithTag("Player").transform;
            Vector2 tagetPos = Target.position;
            Direction = tagetPos - (Vector2)transform.position;
            RaycastHit2D rayInfor = Physics2D.Raycast(transform.position, Direction, Range, 1 << LayerMask.NameToLayer("Player"));
            if (rayInfor) {
                if (rayInfor.collider.gameObject.CompareTag("Player")) {
                    if (Detected == false) {
                        Detected = true;
                    }
                }
            }
            if (Detected) {
                Gun.transform.up = Direction;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.CompareTag("Bullet2")) {
                enemyTankShoot.IsShooting = false;
                ani.SetBool("isExplode", true);
                Destroy(gameObject, 0.35f);
            }
        }
    }
}
