using System.Collections;
using UnityEngine;
namespace io.lockedroom.Games.Jackal {
    public class MovingObjectsY : MonoBehaviour {
        /// <summary>
        /// Speed of Moving
        /// </summary>
        public float Speed;
        /// <summary>
        /// Bottom Possiton
        /// </summary>
        public float BottomPos;
        public float BottomPos1;
        /// <summary>
        /// Moving variable of object
        /// </summary>
        public bool MovingForward = true;
        public bool MovingForward1 = true;
        // Start is called before the first frame update
        void Start() {
            MovingForward = false;
            MovingForward1 = false;
        }

        // Update is called once per frame
        void Update() {
            if (MovingForward) {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, BottomPos), Speed * Time.deltaTime);
            } else if (MovingForward1) {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, BottomPos1), Speed * Time.deltaTime);
            }
        }
        private IEnumerator OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Ally2")) {
                yield return new WaitForSeconds(18f);
                MovingForward = true;
            }
        }
    }
}
