using UnityEngine;
using System.Collections;

public class RoBroScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D)) {
            this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime,
                                                  this.transform.position.y,
                                                  -10.0f);
            //Vector3 temp = this.transform.localScale;
            //temp.x = 1 * 0.33f;
            //this.transform.localScale = temp;
        }
        //else if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A)) {
        //    this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime,
        //                                          this.transform.position.y,
        //                                          -10.0f);
        //    Vector3 temp = this.transform.localScale;
        //    temp.x = -1 * 0.33f;
        //    this.transform.localScale = temp;
        //}

        if(this.transform.position.x < -6.4f) {
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
