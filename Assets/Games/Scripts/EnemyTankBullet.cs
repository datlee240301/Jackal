using UnityEngine;
using UnityEngine.SceneManagement;

namespace io.lockedroom.Games.Jackal {
    public class EnemyTankBullet : MonoBehaviour {
        public float Speed;
        private Vector2 TargetPosition;
        public bool IsMoving;
        void Start() {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) {
                TargetPosition = player.transform.position;
                IsMoving = true;
            }
            BulletLifeTime();
        }
        void Update() {
            if (IsMoving) {
                Vector2 direction = (TargetPosition - (Vector2)transform.position).normalized;
                transform.position += (Vector3)direction * Speed * Time.deltaTime;
            }
            BulletLifeTime();
        }
        private void BulletLifeTime() {
            Destroy(gameObject, 1f);
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.CompareTag("Player")) {
                collision.gameObject.SetActive(false);
                SceneManager.LoadScene("Lv1");
            }
        }

        //private void FixedUpdate() {
        //    if (player != null) {
        //        Vector2 direction = player.transform.position - transform.position;
        //        direction.Normalize();
        //        transform.Translate(direction * Speed * Time.deltaTime);
        //    }
        //}
    }
}
