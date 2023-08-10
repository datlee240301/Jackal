using UnityEngine;
namespace io.lockedroom.Games.Jackal {
    public class Missle : MonoBehaviour {
        public float timeToDie;
        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            Destroy(gameObject,timeToDie);
        }
    }
}