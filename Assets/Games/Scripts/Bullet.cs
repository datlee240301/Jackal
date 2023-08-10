using UnityEngine;
namespace io.lockedroom.Games.Jackal {

    public class Bullet : MonoBehaviour {
        /// <summary>
        /// Value of bullet speed
        /// </summary>
        public float Speed;
        /// <summary>
        /// value of vector 2 of target position
        /// </summary>
        private Vector2 TargetPosition;
        /// <summary>
        /// value of the distance of bulllet
        /// </summary>
        public float MaxBulletHeight;
        public bool IsMoving;
        // Start is called before the first frame update
        void Start() {
            TargetPosition = (Vector2)transform.position + Vector2.up * MaxBulletHeight;
            IsMoving = true;
        }

        // Update is called once per frame
        void Update() {
            if(IsMoving) {
                transform.position = Vector2.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);
            }
            BulletLifeTime();
        }
        private void BulletLifeTime() {
            Destroy(gameObject, 1f);
        }
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Soldier")) {
                IsMoving = false;
            } else if (collision.gameObject.CompareTag("Rock")) {
                Destroy(gameObject);
            }
        }
    }
}
