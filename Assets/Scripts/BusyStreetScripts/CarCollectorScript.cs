using UnityEngine;
using System.Collections;

public class CarCollectorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.GetComponent<CarScript>() == true) {
            //Destroy(coll.gameObject);
            Vector3 newPos = new Vector3(coll.transform.transform.position.x, 19.0f, 0.0f);
            coll.transform.position = newPos;
        }
    }
}
