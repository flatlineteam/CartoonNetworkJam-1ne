using UnityEngine;
using System.Collections;

public class RoBroScript : MonoBehaviour {

    //[SerializeField]
    private Animator myAnim = null;

    private const int IDLE = 0;
    private const int FORWARD = 1;
    private const int BACKWARD = 2;

    [SerializeField]
    private int speed = 6;

	// Use this for initialization
	void Start () {
        myAnim = this.GetComponent<Animator>();
        myAnim.SetInteger("jethroState", IDLE);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D)) {

            myAnim.SetInteger("jethroState", FORWARD);

            Debug.Log(myAnim.GetInteger("jethroState"));

            this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * speed,
                                                  this.transform.position.y,
                                                  -10.0f);

            
            //Vector3 temp = this.transform.localScale;
            //temp.x = 1 * 0.33f;
            //this.transform.localScale = temp;
        }

        if (Input.GetKeyUp(KeyCode.D)) {
            myAnim.SetInteger("jethroState", IDLE);
        }
        //else if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A)) {
        //    this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime,
        //                                          this.transform.position.y,
        //                                          -10.0f);
        //    Vector3 temp = this.transform.localScale;
        //    temp.x = -1 * 0.33f;
        //    this.transform.localScale = temp;
        //}

        if (this.transform.position.x < -6.4f) {
            this.transform.position = new Vector3(-6.4f,
                                                  this.transform.position.y,
                                                  0.0f);
        }
        else if(this.transform.position.x > 31.0f) {
            this.transform.position = new Vector3(31.0f,
                                                  this.transform.position.y,
                                                  0.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == 9) {
            coll.SendMessage("PlayLevel");
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.layer == 9) {
            //Debug.Log("This Is Happening!!!!!!!!!!");
            coll.SendMessage("SkipLevel");
        }
    }
}
