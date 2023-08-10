using UnityEngine;

namespace io.lockedroom.Games.Jackal {
    public class SoldierBullet : MonoBehaviour {
        public float Speed;
        private Vector2 TargetPosition;
        public float MaxBulletHeight;
        public bool IsMoving;

        void Start() {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) {
                TargetPosition = player.transform.position;
                IsMoving = true;
            }
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
    }
}
