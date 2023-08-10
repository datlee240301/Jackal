using System.Collections;
using UnityEngine;
namespace io.lockedroom.Games.Jackal {
    public class CarSpawnAlly : MonoBehaviour {

        public GameObject Ally2;
        public Transform SpawnPoint;
        private int numberOfAlliesToSpawn = 15;
        private float spawnDelay = 1f;
        public GameObject AllyPoint;
        public MovingObjectsY ScriptMovingObjectsY;
        // Start is called before the first frame update
        void Start() {
            ScriptMovingObjectsY = FindObjectOfType<MovingObjectsY>();
        }

        // Update is called once per frame
        void Update() {

        }
        private IEnumerator OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Stop")) {
                Destroy(collision.gameObject);
                ScriptMovingObjectsY.MovingForward1 = true;
                yield return new WaitForSeconds(7f);
                StartCoroutine(SpawnAllies());
            }
        }
        private IEnumerator SpawnAllies() {
            for (int i = 0; i < numberOfAlliesToSpawn; i++) {
                Instantiate(Ally2, SpawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(spawnDelay);
            }
            if (numberOfAlliesToSpawn >= 5) {
                Destroy(AllyPoint.gameObject);
                Debug.Log("dsf");
            }
        }
    }
}
