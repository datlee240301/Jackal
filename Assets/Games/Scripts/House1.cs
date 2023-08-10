using System.Collections;
using UnityEngine;
namespace io.lockedroom.Games.Jackal {
    public class House1 : MonoBehaviour {
        private Animator House;
        public GameObject Ally;
        public Transform SpawnPoint;
        private int numberOfAlliesToSpawn = 5;
        private float spawnDelay = 1f;
        public GameObject AllyPoint;
        public GameObject RaisedHandAlly;
        public Transform AllyPoint2;
        public GameObject Point2;
        // Start is called before the first frame update
        void Start() {
            House = GetComponent<Animator>();
            House.SetBool("IsExplode1", false);
        }

        // Update is called once per frame
        void Update() {

        }
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.CompareTag("Bullet2")) {
                House.SetBool("IsExplode1", true);
                StartCoroutine(SpawnAllies());
                StartCoroutine(SpawnRaiseHandAlly());
            } else if (collision.gameObject.CompareTag("Missle")) {
                House.SetBool("IsExplode1", true);
                StartCoroutine(SpawnAllies());
                StartCoroutine(SpawnRaiseHandAlly());
                Destroy(collision.gameObject);
            }
        }
        private IEnumerator SpawnAllies() {
            for (int i = 0; i < numberOfAlliesToSpawn; i++) {
                Instantiate(Ally, SpawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(spawnDelay);
            }
            if (numberOfAlliesToSpawn >= 5) {
                Destroy(AllyPoint);
                Debug.Log("dsf");
            }
        }
        private IEnumerator SpawnRaiseHandAlly() {
            Instantiate(RaisedHandAlly, AllyPoint2.position, Quaternion.identity);
            yield return new WaitForSeconds(1);    
            Destroy(Point2);
        }
    }
}
