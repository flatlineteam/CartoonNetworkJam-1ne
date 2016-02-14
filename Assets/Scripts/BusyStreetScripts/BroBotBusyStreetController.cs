using UnityEngine;
using System.Collections;

public class BroBotBusyStreetController : MonoBehaviour {

    private Vector3 startPosition = Vector3.zero;
    private Vector3 endPosition = Vector3.zero;

    [SerializeField]
    private Vector3 movementDist = new Vector3(0.0f, 2.5f, 0.0f);

    [SerializeField]
    private Rigidbody2D passenger = null;

    [SerializeField]
    private float speed = 1.0f;

    // Use this for initialization
    void Start() {
        startPosition = this.transform.position;
        endPosition = new Vector3(this.transform.position.x,
                                  this.transform.position.y + (4 * movementDist.y),
                                  0.0f);
    }

    // Update is called once per frame
    void Update() {
//if (passenger != null) return;

        if (/*Input.GetKey(KeyCode.W) ||*/ Input.GetKeyDown(KeyCode.W)) {
            this.transform.position += movementDist;// * Time.deltaTime * speed;
        }
        if (/*Input.GetKey(KeyCode.S) ||*/ Input.GetKeyDown(KeyCode.S)) {
            this.transform.position -= movementDist;// * Time.deltaTime * speed;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Doing this");
            if (passenger != null)
                passenger.AddRelativeForce(Vector2.up);
        }

        // Check y position to make sure we don't go backwards off of the screen
        if (this.transform.position.y < startPosition.y) {
            Vector3 newPos = new Vector3(this.transform.position.x,
                                         startPosition.y,
                                         0.0f);

            this.transform.position = newPos;
        }
        else if (this.transform.position.y > endPosition.y) {
            Vector3 newPos = new Vector3(this.transform.position.x,
                                         endPosition.y,
                                         0.0f);

            this.transform.position = newPos;
        }
    }

    public void LaunchGrandma() {
        if (passenger == null) return;

        passenger.AddRelativeForce(Vector2.up);
        passenger = null;
        passenger.transform.SetParent(null);
    }
}
