using System.Collections;
using TMPro;
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
        public static Shoot instance;
        public float speed;
        // Start is called before the first frame update
        void Start() {
            IsShooting = true;
        }
        private void Awake() {
            instance = this;
        }
        // Update is called once per frame
        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                GameObject instance = ObjectPool.instance.GetPooledObject();
                if (instance != null) {
                    instance.transform.position = ShootingPoint.position;
                    instance.transform.rotation = ShootingPoint.rotation;
                    instance.SetActive(true);
                    Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                    rb.velocity = transform.up * speed;
                    StartCoroutine(DestroyBullet(instance));
                }
            }
        }
        private IEnumerator DestroyBullet(GameObject gameObject) {
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);    
        }
    }
}
