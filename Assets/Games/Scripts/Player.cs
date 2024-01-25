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
        public Vector2 distanceToMoveX;
        public Vector2 distanceToMoveY;
        // Start is called before the first frame update
        void Start() {
            Tank = GetComponent<Animator>();
        }
        // Update is called once per frame
        void Update() {
            MoveInput.x = Input.GetAxis("Horizontal");
            MoveInput.y = Input.GetAxis("Vertical");
            transform.position += MoveInput * MoveSpeed * Time.deltaTime;
            Telepoort();
            Animate();
        }
        private void Telepoort() {
            if (Input.GetKey(KeyCode.LeftShift)) {
                Vector2 currentPos = transform.position;

                if (Input.GetKey(KeyCode.D))
                    transform.position = currentPos + distanceToMoveX;
                else if (Input.GetKey(KeyCode.A))
                    transform.position = currentPos - distanceToMoveX;
                else if (Input.GetKey(KeyCode.W))
                    transform.position = currentPos + distanceToMoveY;
                else if (Input.GetKey(KeyCode.S))
                    transform.position = currentPos - distanceToMoveY;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Soldier")) {
                collision.gameObject.SetActive(false);
            } else if (collision.gameObject.CompareTag("SoldierBullet")) {
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
