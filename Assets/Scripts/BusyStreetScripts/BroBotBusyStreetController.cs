using UnityEngine;
using System.Collections;

public class BroBotBusyStreetController : MonoBehaviour {

    private Vector3 startPosition = Vector3.zero;
    private Vector3 endPosition = Vector3.zero;

    [SerializeField]
    private Vector3 movementDist = new Vector3(0.0f, 2.5f, 0.0f);

    //private float yTopBound = 10.0f;
    //private float yBottomBound = -7.5f;

    private Vector3 myDirection = Vector3.up;

    [SerializeField]
    private Rigidbody2D passenger = null;

    [SerializeField]
    private GameObject seat = null;

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
        if (Input.GetKeyDown(KeyCode.Space)) {
            //Debug.Log("Doing this");
            //Debug.Log(passenger);
            if (passenger != null) {
                LaunchGrandma();
                //passenger.AddRelativeForce(Vector2.up);
                //passenger.GetComponent<GrandmaScript>().ThrowGrandma();
                //passenger.transform.SetParent(null);
            }
        }

        if (passenger != null) return;

        //Debug.Log(passenger);
        //Debug.Log(myDirection);

        //if (/*Input.GetKey(KeyCode.W) ||*/ Input.GetKeyDown(KeyCode.W)) {
        //    this.transform.position += movementDist;// * Time.deltaTime * speed;
        //}
        //if (/*Input.GetKey(KeyCode.S) ||*/ Input.GetKeyDown(KeyCode.S)) {
        //    this.transform.position -= movementDist;// * Time.deltaTime * speed;
        //}

        //if(Input.GetKeyDown(KeyCode.Space)) {
        //    //Debug.Log("Doing this");
        //    //Debug.Log(passenger);
        //    if (passenger != null) {
        //        LaunchGrandma();
        //        //passenger.AddRelativeForce(Vector2.up);
        //        //passenger.GetComponent<GrandmaScript>().ThrowGrandma();
        //        //passenger.transform.SetParent(null);
        //    }
        //}

        this.transform.position += myDirection * Time.deltaTime * speed;// * Time.deltaTime * speed;

        // Check y position to make sure we don't go backwards off of the screen
        if (this.transform.position.y < BusyStreetLevelController.instance.YBottomBound) {
            Vector3 newPos = new Vector3(this.transform.position.x,
                                         BusyStreetLevelController.instance.YBottomBound,
                                         0.0f);

            this.transform.position = newPos;

            Vector3 temp = this.transform.localScale;
            temp.y *= -1;
            this.transform.localScale = temp;
            myDirection = Vector3.up;
        }
        else if (this.transform.position.y > BusyStreetLevelController.instance.YTopBound) {
            Vector3 newPos = new Vector3(this.transform.position.x,
                                         BusyStreetLevelController.instance.YTopBound,
                                         0.0f);

            this.transform.position = newPos;
            Vector3 temp = this.transform.localScale;
            temp.y *= -1;
            this.transform.localScale = temp;
            myDirection = Vector3.down;
        }
    }

    public void LaunchGrandma() {
        if (passenger == null) return;
        
        passenger.transform.SetParent(null);
        passenger.GetComponent<GrandmaScript>().ThrowGrandma();
        passenger = null;

    }

    private void AssignPassengerToSeat() {
        passenger.transform.SetParent(seat.transform);
        passenger.transform.position = seat.transform.position;
    }

    public void GetNewPassenger(Rigidbody2D pass) {
        passenger = pass;
        AssignPassengerToSeat();
    }

    //void OnTriggerEnter2D(Collider2D coll) {
    //    if(coll.gameObject.layer == 8) {
    //        if (this.passenger != null) return;
    //        BusyStreetLevelController.instance.PickUpGrandma(this.gameObject);
    //    }
    //}
}
