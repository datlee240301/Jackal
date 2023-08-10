using UnityEngine;
namespace io.lockedroom.Games.Jackal {
    public class GreenHouse : MonoBehaviour {
        private Animator ani;
        // Start is called before the first frame update
        void Start() {
            ani = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update() {

        }
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Bullet2")) {
                ani.SetBool("isExplode", true);
            }
        }
    }
}
