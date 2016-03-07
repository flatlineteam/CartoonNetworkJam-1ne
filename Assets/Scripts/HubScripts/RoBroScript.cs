using UnityEngine;
using System.Collections;

public class RoBroScript : MonoBehaviour {

    [SerializeField]
    private GameObject smokeStack = null, sparks = null;

    [SerializeField]
    private GameObject smokeStart = null, sparkStart = null;

    //[SerializeField]
    private Animator myAnim = null;

    private const int IDLE = 0;
    private const int FORWARD = 1;
    private const int BACKWARD = 2;

    [SerializeField]
    private int speed = 6;

    private float smokeCountDown = 0.0f;
    private float sparkCountDown = 0.0f;

    private const float maxSmokeCountDown = 2.5f;
    private const float maxSparkCountDown = 5.0f;

    private bool playerFlipped = false;
    private bool moveLeft = false;
    private bool moveRight = false;

	// Use this for initialization
	void Start () {
        myAnim = this.GetComponent<Animator>();
        myAnim.SetInteger("jethroState", IDLE);
	}
	
	// Update is called once per frame
	void Update () {
        if (HubControllerScript.instance.IsPaused == true) return;
        if(moveRight == true) {
            MovePlayerRight();
            //GameManager.instance.PlayRobotMoveSound();
        }
        else if (moveLeft == true) {
            MovePlayerLeft();
            //GameManager.instance.PlayRobotMoveSound();
        }
        else { 
            this.HandleMovement();
        }

        this.HandleBounds();
        this.HandleSmokeStack();
        this.HandleSparks();
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == 9) {
            coll.SendMessage("PlayLevel");
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.layer == 9) {
            coll.SendMessage("SkipLevel");
        }
    }

    public void FlipMe() {
        Vector3 temp = this.transform.localScale;
        temp.x *= -1;
        this.transform.localScale = temp;
        playerFlipped = !playerFlipped;
        myAnim.SetInteger("jethroState", IDLE);
    }

    private void HandleMovement() {
        if (playerFlipped == false) {
            if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D)) {
                MovePlayerRight();

                //myAnim.SetInteger("jethroState", FORWARD);

                //this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * speed,
                //                                      this.transform.position.y,
                //                                      -10.0f);
            }

            if (Input.GetKeyUp(KeyCode.D)) {
                myAnim.SetInteger("jethroState", IDLE);
                GameManager.instance.StopRobotMoveSound();
            }
        }
        else if (playerFlipped == true) {
            if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A)) {
                MovePlayerLeft();
                //myAnim.SetInteger("jethroState", FORWARD);

                //this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime * speed,
                //                                      this.transform.position.y,
                //                                      -10.0f);
            }

            if (Input.GetKeyUp(KeyCode.A)) {
                myAnim.SetInteger("jethroState", IDLE);
                GameManager.instance.StopRobotMoveSound();
            }
        }

        //if (this.transform.position.x < -5.0f) {
        //    this.transform.position = new Vector3(-4.9f,
        //                                          this.transform.position.y,
        //                                          0.0f);
        //}
        //else if (this.transform.position.x > 31.0f) {
        //    this.transform.position = new Vector3(30.5f,
        //                                          this.transform.position.y,
        //                                          0.0f);
        //}
    }

    private void HandleBounds() {
        if (this.transform.position.x < -5.0f) {
            this.transform.position = new Vector3(-4.9f,
                                                  this.transform.position.y,
                                                  0.0f);
        }
        else if (this.transform.position.x > 31.0f) {
            this.transform.position = new Vector3(30.5f,
                                                  this.transform.position.y,
                                                  0.0f);
        }
    }

    private void HandleSmokeStack() {
        smokeCountDown -= Time.deltaTime;
        if (smokeCountDown <= 0.0f) {
            GameObject go = Instantiate(smokeStack, smokeStart.transform.position, Quaternion.identity) as GameObject;
            go.transform.SetParent(smokeStart.transform);
            smokeCountDown = maxSmokeCountDown;
        }
    }

    private void HandleSparks() {
        sparkCountDown -= Time.deltaTime;
        if (sparkCountDown <= 0.0f) {
            GameManager.instance.PlaySparkSFX();
            GameObject go = Instantiate(sparks) as GameObject;
            go.transform.SetParent(sparkStart.transform, false);
            sparkCountDown = maxSparkCountDown;
        }
    }

    private void MovePlayerRight() {
        myAnim.SetInteger("jethroState", FORWARD);

        GameManager.instance.PlayRobotMoveSound();

        this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * speed,
                                              this.transform.position.y,
                                              -10.0f);
    }

    private void MovePlayerLeft() {
        myAnim.SetInteger("jethroState", FORWARD);

        GameManager.instance.PlayRobotMoveSound();

        this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime * speed,
                                              this.transform.position.y,
                                              -10.0f);
    }

    public void SetMovement(bool right) {
        this.moveRight = right;
        this.moveLeft = !right;
    }

    public void GoToIdle() {
        this.moveRight = false;
        this.moveLeft = false;
        GameManager.instance.StopRobotMoveSound();
        myAnim.SetInteger("jethroState", IDLE);
    }
}
