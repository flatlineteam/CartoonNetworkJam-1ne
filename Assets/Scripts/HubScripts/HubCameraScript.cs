using UnityEngine;
using System.Collections;

public class HubCameraScript : MonoBehaviour {

    private Vector3 startingPosition = new Vector3(0.0f, 0.0f, -10.0f);
    private Vector3 endingPosition = new Vector3(25.0f, 0.0f, -10.0f);

	// Use this for initialization
	void Start () {
        //startingPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D)) {
            this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime, 
                                                  this.transform.position.y, 
                                                  -10.0f);
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A)) {
            this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime,
                                                  this.transform.position.y,
                                                  -10.0f);
        }

	    if(this.transform.position.x < startingPosition.x) {
            Vector3 newPos = new Vector3(startingPosition.x, this.transform.position.y, -10.0f);
            this.transform.position = newPos;
        }
        else if(this.transform.position.x > endingPosition.x) {
            Vector3 newPos = new Vector3(endingPosition.x, this.transform.position.y, -10.0f);
            this.transform.position = newPos;
        }
	}
}
