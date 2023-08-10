using UnityEngine;
namespace io.lockedroom.Games.Jackal {
    public class CameraFollow : MonoBehaviour {
        /// <summary>
        /// player position
        /// </summary>
        public Transform Player;

        // Start is called before the first frame update
        void Start() {
            Player = GameObject.Find("Player").transform;
        }

        // Update is called once per frame
        void Update() {
            Vector3 Camera = transform.position;
            Camera.x = Player.position.x;
            Camera.y = Player.position.y;
            Camera.z = -20;
            transform.position = Camera;

        }
    }
}
