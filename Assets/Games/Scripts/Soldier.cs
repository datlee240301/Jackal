using System.Collections;
using UnityEngine;
namespace io.lockedroom.Games.Jackal {
    public class Soldier : MonoBehaviour {
        private Transform Target;
        private bool IsChasing;
        public float Speed;
        public float ChasingDistance;
        public float StopChasingDistance;
        private Animator ani;
        public float timeToDie;
        void Start() {
            IsChasing = false;
            ani = GetComponent<Animator>();
        }
        void Update() {
            Target = GameObject.FindGameObjectWithTag("Player").transform;
            if (Vector2.Distance(Target.position, transform.position) <= ChasingDistance) {
                IsChasing = true;
                ani.SetBool("IsRaisehand", false);
                ani.SetBool("IsRun", true);
                ani.SetBool("IsStand", false);
            }
            if (IsChasing) {
                transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
            }
            if (Vector2.Distance(Target.position, transform.position) >= StopChasingDistance) {
                IsChasing = false;
                ani.SetBool("IsRun", false);
                ani.SetBool("IsRaisehand", false);
                ani.SetBool("IsStand", true);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.CompareTag("Bullet")) {
                IsChasing = false;
                ani.SetBool("isDie", true);
                collision.gameObject.SetActive(false);
                Destroy(gameObject, timeToDie);
            } else if (collision.gameObject.CompareTag("Missle")) {
                IsChasing = false;
                ani.SetBool("isExplode", true);
                collision.gameObject.SetActive(false);
                Destroy(gameObject, timeToDie);
            } else if (collision.gameObject.CompareTag("Bullet2")) {
                IsChasing = false;
                ani.SetBool("isExplode", true);
                collision.gameObject.SetActive(false);
                Destroy(gameObject, timeToDie);
            }
        }
    }
}
