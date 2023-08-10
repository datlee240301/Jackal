using UnityEngine;
namespace io.lockedroom.Games.Jackal {
    public class Shoot : MonoBehaviour {
        /// <summary>
        /// shooting point position
        /// </summary>
        public Transform ShootingPoint;
        /// <summary>
        /// game object bullet
        /// </summary>
        public GameObject Bullet;
        public bool IsShooting;
        // Start is called before the first frame update
        void Start() {
            IsShooting = true;  
        }

        // Update is called once per frame
        void Update() {
            if (IsShooting) {
                if (Input.GetMouseButtonDown(0)) {
                    Instantiate(Bullet, ShootingPoint.position, transform.rotation);
                }
            }
        }
    }
}
