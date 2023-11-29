using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;  
    public List<GameObject> pooledObject = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;
    // Start is called before the first frame update
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        pooledObject = new List<GameObject> ();
        GameObject newGameobject;
        for(int i = 0; i < amountToPool; i++) {
            newGameobject = Instantiate(objectToPool);
            newGameobject.SetActive (false);
            pooledObject.Add (newGameobject);
        }
    }

    public GameObject GetPooledObject() {
        for(int i = 0;i < amountToPool;i++) {
            if (!pooledObject[i].activeInHierarchy) {
                return pooledObject[i];
            }
        }
        return null;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
