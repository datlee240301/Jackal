using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace io.lockedroom.Games.Jackal {
    public class DestroyTank : MonoBehaviour {
        private Transform missleTarget;
        // Start is called before the first frame update
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {
            missleTarget = GameObject.FindGameObjectWithTag("Missle").transform;
            if(Vector2.Distance(transform.position, missleTarget.position)<= 0.1f) {
                Destroy(gameObject);
            }
        }
    }
}
