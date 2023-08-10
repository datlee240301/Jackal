using System.Collections;
using UnityEngine;

namespace io.lockedroom.Games.Jackal {
    public class Bullet2 : MonoBehaviour {
        private Animator Grenade;
        private Transform Turret;
        void Start() {
            Grenade = GetComponent<Animator>();
        }
        void Update() {
            BulletLifeTime();
        }
        private void BulletLifeTime() {
            Destroy(gameObject, 1f);
        }
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.CompareTag("House1")) {
                Destroy(gameObject);
            } else if (collision.gameObject.CompareTag("Gate")) {
                Grenade.SetBool("IsExplode", true);
                collision.gameObject.SetActive(false);
            } else if (collision.gameObject.CompareTag("EnemyTank")) {
                Grenade.SetBool("IsExplode", true);
                collision.gameObject.SetActive(false);
            } else if (collision.gameObject.CompareTag("Limited")) {
                collision.gameObject.SetActive(false);
            } else if (collision.gameObject.CompareTag("GreenHouse")) {
                Grenade.SetBool("IsExplode", true);
            } else if (collision.gameObject.CompareTag("Tankkk")) {
                Destroy(gameObject) ;
            }
        }
    }
}
