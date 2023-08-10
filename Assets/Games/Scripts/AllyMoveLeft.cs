using UnityEngine;

namespace io.lockedroom.Games.Jackal {
    public class AllyMoveLeft : MonoBehaviour {
        public float speed;
        private bool isMoving = true;
        private Animator ani;
        public float distanceToGo;
        private float originalX; // Vị trí ban đầu của nhân vật

        // Start is called before the first frame update
        void Start() {
            ani = GetComponent<Animator>();
            ani.SetBool("IsRaiseHand", false);

            originalX = transform.localPosition.x; // Lưu vị trí ban đầu
        }

        // Update is called once per frame
        void Update() {
            if (isMoving) {
                float targetX = originalX - distanceToGo; // Vị trí mục tiêu để dừng lại

                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(targetX, transform.localPosition.y), speed * Time.deltaTime);

                if (transform.localPosition.x <= targetX) {
                    isMoving = false;
                    ani.SetBool("IsRaiseHand", true);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Player")) {
                Destroy(gameObject);
            }
        }
    }
}
