using UnityEngine;


namespace io.lockedroom.Games.Jackal {
    public class Ally2 : MonoBehaviour {
        private Transform Target;
        private bool IsChasing;
        public float Speed;
        public float chasingDistance = 10f;
        public float stopChasingDistance = 20f;

        void Start() {
            Target = GameObject.FindGameObjectWithTag("apache").transform;
        }

        void Update() {
            if (Vector2.Distance(Target.position, transform.position) > 10f) {
                IsChasing = false;
            }

            if (IsChasing) {
                transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
            } else {
                if (Vector2.Distance(Target.position, transform.position) <= 10f) {
                    IsChasing = true;
                }
            }
        }
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("apache")) {
                Destroy(gameObject);
                Debug.Log("df");
            }
        }
    }
}
