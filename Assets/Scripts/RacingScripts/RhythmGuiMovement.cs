using UnityEngine;
using System.Collections;

public class RhythmGuiMovement : MonoBehaviour {

    private CircleCollider2D target = null;
    private CircleCollider2D myCollider = null;

    //private bool notColliding = false;
    //private bool isColliding = false;
    //private bool isInsideTarget = false;

    private float speed = 1.0f;

    // Use this for initialization
    void Start() { 
        myCollider = this.GetComponent<CircleCollider2D>();
        target = RacingGameController.instance.TopTarget;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 newPostion = new Vector3(this.transform.position.x - (Time.deltaTime * speed), this.transform.position.y, 0.0f);
        this.transform.position = newPostion;

        CheckPositionToTarget();
    }

    private void CheckPositionToTarget() {
        if (target == null) return;

        float dist = (target.transform.position - this.transform.position).magnitude;

        if(dist > target.radius + myCollider.radius) {
            Debug.Log("<color=#33FF33>I Am Not In Contact With The Target!!</color>");// : " + dist);
        }
        else if( dist < target.radius + myCollider.radius) {
            if(dist < target.radius - myCollider.radius) {
                Debug.Log("<color=#FF3333>I Am In The Target!!</color>");// : " + dist);
            }
            else { 
                Debug.Log("<color=#3333FF>I Am In Contact With The Target!!</color>");// : " + dist);
            }
        }
    }
}
