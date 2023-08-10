using System.Collections;
using UnityEngine;

namespace io.lockedroom.Games.Jackal {
    public class Ally : MonoBehaviour {
        private Transform target;
        private bool isChasing;
        public float speed;
        public float chasingDistance = 10f;
        public float stopChasingDistance = 20f;

        void Start() {
            isChasing = false;
        }

        void Update() {
            float distanceToTarget = Vector2.Distance(target.position, transform.position);

            if (distanceToTarget > stopChasingDistance) {
                isChasing = false;
            }

            if (distanceToTarget < chasingDistance && !isChasing) {
                isChasing = true;
            }

            if (isChasing) {
                if (distanceToTarget > chasingDistance) {
                    StopChasing();
                } else {
                    ChaseTarget();
                }
            }
        }

        void ChaseTarget() {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        void StopChasing() {
            isChasing = false;
            StartCoroutine(ResumeChasing());
        }

        IEnumerator ResumeChasing() {
            yield return new WaitForSeconds(1f);
            isChasing = true;
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Player")) {
                gameObject.SetActive(false);
            }
        }
        private void FixedUpdate() {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
