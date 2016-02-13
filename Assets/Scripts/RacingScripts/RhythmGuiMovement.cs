using UnityEngine;
using System.Collections;

public class RhythmGuiMovement : MonoBehaviour {

    //[SerializeField]
    //private bool isTopRow = false;

    private CircleCollider2D target = null;
    private CircleCollider2D myCollider = null;

    private bool isInContactWithGoal = false;
    private bool isInsideGoal = false;

    public bool IsInContactWithGoal {
        get { return isInContactWithGoal; }
    }

    public bool IsInsideGoal {
        get { return isInsideGoal; }
    }

    private float speed = 3.0f;

    // Use this for initialization
    void Start() { 
        myCollider = this.GetComponent<CircleCollider2D>();
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
            if (isInsideGoal == true) isInsideGoal = false;
            if (isInContactWithGoal == true) isInContactWithGoal = false;
        }
        else if( dist < target.radius + myCollider.radius) {
            if(dist < target.radius - myCollider.radius) {
                isInsideGoal = true;
                isInContactWithGoal = false;
            }
            else {
                isInContactWithGoal = true;
                isInsideGoal = false;
            }
        }
    }

    public void SetTarget(CircleCollider2D tar) {
        if (this.target == null) target = tar;
    }
}
