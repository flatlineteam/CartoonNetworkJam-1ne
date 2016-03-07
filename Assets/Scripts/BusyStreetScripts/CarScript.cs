using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour {

    private float speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 newPos = new Vector3(this.transform.position.x - (Time.deltaTime * speed), this.transform.position.y, 0.0f);
        //Vector3 newPos = new Vector3(this.transform.position.x, this.transform.position.y - (Time.deltaTime * speed), 0.0f);
        Vector3 newPos = new Vector3(this.transform.position.x, 
                                     this.transform.position.y - (Time.deltaTime * speed * BusyStreetLevelController.instance.SpeedAdjustment), 
                                     0.0f);
        this.transform.position = newPos;
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == 8) {
            //Debug.Log("Bro-Bot Hit!!");
        }
        if(coll.gameObject.layer == 11) {
            Debug.Log("Granny Got Hit!!");
        }
    }

    public void SetSpeed(float sp) {
        speed = sp;
    }
}
