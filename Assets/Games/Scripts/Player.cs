using UnityEngine;
using UnityEngine.SceneManagement;
namespace io.lockedroom.Games.Jackal {
    public class Player : MonoBehaviour {
        /// <summary>
        /// value of movement speed of player
        /// </summary>
        public float MoveSpeed;
        /// <summary>
        /// Rigidbody 2d
        /// </summary>
        private Rigidbody2D rb;
        /// <summary>
        /// data type of vector 3
        /// </summary>
        public Vector3 MoveInput;
        /// <summary>
        /// animator tank
        /// </summary>
        private Animator Tank;
        // Start is called before the first frame update
        void Start() {
            Tank = GetComponent<Animator>();
        }
        // Update is called once per frame
        void Update() {
            MoveInput.x = Input.GetAxis("Horizontal");
            MoveInput.y = Input.GetAxis("Vertical");
            transform.position += MoveInput * MoveSpeed * Time.deltaTime;
            Animate();
        }
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Soldier")) {
                collision.gameObject.SetActive(false);
            }else if (collision.gameObject.CompareTag("SoldierBullet")) {
                gameObject.SetActive(false);
                SceneManager.LoadScene("Lv1");
            } 
        }
        private void Animate() {
            Tank.SetFloat("MovementX", MoveInput.x);
            Tank.SetFloat("MovementY", MoveInput.y);
        }
    }
}
