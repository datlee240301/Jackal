using UnityEngine;
namespace io.lockedroom.Games.Jackal {
    public class Shoot2 : MonoBehaviour {
        /// <summary>
        /// shooting point position
        /// </summary>
        public Transform ShootingPoint2;
        /// <summary>
        /// game object bullet
        /// </summary>
        public GameObject Bullet2;
        public float TimeBtwFire = 1f;
        public float BulletForce;
        private float timeBtwFire;
        private Rigidbody2D rb;
        public GameObject Missle;
        public bool isMissle = false;
        public float MissleForce ;
        // Start is called before the first frame update
        void Start() {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update() {
            Debug.Log("Update" + isMissle);
            RotateGun();
            timeBtwFire -= Time.deltaTime;
                if (Input.GetMouseButtonDown(1) && timeBtwFire < 0) {
                if (isMissle) {
                    FireMissle();
                } else {
                    FireGrenade();
                }
            }
        }
        void RotateGun() {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 LookDir = MousePos - transform.position;
            float Angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg;
            Quaternion Rotation = Quaternion.Euler(0, 0, Angle);
            transform.rotation = Rotation;
        }
       private void FireGrenade() {
            timeBtwFire = TimeBtwFire;
            GameObject BuleetTmp = Instantiate(Bullet2, ShootingPoint2.position, Quaternion.identity);
            Rigidbody2D rb = BuleetTmp.GetComponent<Rigidbody2D>(); 
            rb.AddForce(transform.right * BulletForce, ForceMode2D.Impulse);
        }
        private void FireMissle() {
            timeBtwFire = TimeBtwFire;
            GameObject BuleetTmp = Instantiate(Missle, ShootingPoint2.position, Quaternion.identity);
            Rigidbody2D rb = BuleetTmp.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * MissleForce, ForceMode2D.Impulse);
        }
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("PowerUp")) {
                isMissle = true;
                Debug.Log(isMissle);
                Destroy(collision.gameObject);
            }else if (collision.gameObject.CompareTag("Tankkk")) {
                Destroy(gameObject);
            }
            
        }
    }
}
