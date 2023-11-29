using System.Collections;
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
            if(Shoot.instance.IsShooting==true) {
                gameObject.SetActive(true);
                StartCoroutine(BulletLifeTime());
            }
            if(IsMoving) {
                transform.position = Vector2.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);
            }
            
        }
        private IEnumerator BulletLifeTime() {
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);    
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
