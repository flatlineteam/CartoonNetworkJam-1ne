using UnityEngine;
using System.Collections;

public class GrandmaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == 10) {
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
