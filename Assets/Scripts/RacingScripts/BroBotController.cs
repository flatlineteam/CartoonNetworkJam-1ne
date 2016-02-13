using UnityEngine;
using System.Collections;

public class BroBotController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(/*Input.GetKey(KeyCode.W) || */Input.GetKeyDown(KeyCode.W)) {
            this.transform.position += Vector3.up;
        }
        if (/*Input.GetKey(KeyCode.S) ||*/ Input.GetKeyDown(KeyCode.S)) {
            this.transform.position += Vector3.down;
        }
    }
}
