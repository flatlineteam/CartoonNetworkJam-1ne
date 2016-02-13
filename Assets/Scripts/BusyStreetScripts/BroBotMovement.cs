using UnityEngine;
using System.Collections;

public class BroBotMovement : MonoBehaviour {

    private Vector3 startPosition = Vector3.zero;

    [SerializeField]
    private float speed = 1.0f;

	// Use this for initialization
	void Start () {
        startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.W)) {
            this.transform.position += Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.S)) {
            this.transform.position += Vector3.down * Time.deltaTime * speed;
        }

        // Check y position to make sure we don't go backwards off of the screen
        if(this.transform.position.y < startPosition.y) {
            Vector3 newPos = new Vector3(this.transform.position.x,
                                         startPosition.y,
                                         0.0f);

            this.transform.position = newPos;
        }
    }
}
