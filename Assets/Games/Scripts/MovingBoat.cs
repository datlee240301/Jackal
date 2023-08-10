using System.Collections;
using UnityEngine;
namespace io.lockedroom.Games.Jackal {
    public class MovingBoat : MonoBehaviour {
        /// <summary>
        /// Speed of Moving
        /// </summary>
        public float Speed;
        /// <summary>
        /// Moving variable of object
        /// </summary>
        public bool MovingForward;
        public Vector2 BottomPos;
        private Transform Target;
        public float rangeForKilling;
        private Animator ani;
        public float timeToDie;
        // Start is called before the first frame update
        void Start() {
            MovingForward = false;
            ani = GetComponent<Animator>();
        }
        // Update is called once per frame
        void Update() {
            if (MovingForward) {
                transform.position = Vector3.MoveTowards(transform.position, BottomPos, Speed * Time.deltaTime);
            }
            if (Vector2.Distance(Target.position, transform.position) <= rangeForKilling) {
                MovingForward = true;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.CompareTag("Missle")) {
                ani.SetBool("isExplode", true);
                Destroy(gameObject, timeToDie);
                Destroy(collision.gameObject);
            } else if (collision.gameObject.CompareTag("Bullet2")) {
                ani.SetBool("isExplode", true);
                Destroy(gameObject, timeToDie);
                Destroy(collision.gameObject);
            }
        }
        private void FixedUpdate() {
            Target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
