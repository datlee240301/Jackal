using System.Collections;
using UnityEngine;

namespace io.lockedroom.Games.Jackal {
    public class MovingTransportPlane : MonoBehaviour {
        /// <summary>
        /// value of speed
        /// </summary>
        public float speed;
        /// <summary>
        /// variable of movement
        /// </summary>
        public bool isMoving;
        /// <summary>
        /// value of top position 1, 2
        /// </summary>
        public float topPos, topPos2;
        /// <summary>
        /// position of Spawn point
        /// </summary>
        public Transform SpawnPoint;
        /// <summary>
        /// game object player
        /// </summary>
        public GameObject PlayerPrefab;
        /// <summary>
        /// value of delay time
        /// </summary>
        public float delayTime;
        /// <summary>
        /// GameObject playerInstance
        /// </summary>
        private GameObject playerInstance;
        /// <summary>
        /// variable of movement 2
        /// </summary>
        public bool isMoving2;
        void Start() {
            isMoving = true;
            isMoving2 = false;
            Moving();
        }
        void Update() {
            Moving();
            Moving2();
        }
        private void Moving() {
            if (isMoving) {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, topPos), speed * Time.deltaTime);
                StartCoroutine(Spawn());
                if(transform.localPosition.y >= topPos) {
                    isMoving = false;
                }
            } else {
                if (isMoving2 = true) {
                    StartCoroutine(Moving2());    
                }
            }
        }
        private IEnumerator Moving2() {
            yield return new WaitForSeconds(1f); 
            if (isMoving2) {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, topPos2), speed * Time.deltaTime);
            }
        }
        private IEnumerator Spawn() {
            yield return new WaitForSeconds(delayTime);
            if (playerInstance == null) {
                playerInstance = Instantiate(PlayerPrefab, SpawnPoint.position, Quaternion.identity);
                Camera.main.GetComponent<CameraFollow>().Player = playerInstance.transform;
            }
        }
    }
}
