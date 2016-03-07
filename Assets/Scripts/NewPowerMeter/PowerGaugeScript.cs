using UnityEngine;
using System.Collections;

public class PowerGaugeScript : MonoBehaviour {

    [SerializeField]
    private GameObject needle = null;

    private bool gaugeActive = false;
    public bool GaugeActive {
        get { return gaugeActive; }
    }

    private bool needleIncreasing = false;

    private bool readyToFire = false;
    public bool ReadyToFire {
        get { return readyToFire; }
    }

    private float throwForce = 1.0f;

    private const float MAX_ANGLE = 85.0f;
    private const float MIN_ANGLE = -85.0f;
    private const float MAX_POWER = 3.0f;

    private float currentPower = 0.0f;

    private float totalPower = 0.5f;
    public float TotalPower {
        get { return totalPower; }
    }

    private int offset = 1;

	// Use this for initialization
	void Start () {
        //currentAngle = MIN_ANGLE;
        needle.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, MAX_ANGLE);
        this.gaugeActive = false;
	}
	
	// Update is called once per frame
	void Update () {
	    // if screen is touched, mouse is clicked, or space is pressed...
            // Shart the gauge...
        if(this.gaugeActive == true) {
            MoveGaugeNeedle();
        }

        // if the gauge is active, rotate needle along a semi circle, and ping pong back and forth
            // if the screen is touched, mouse is clicked, or space is pressed...
            // Stop the gauge and apply the force to the grandma launch.
	}

    private void MoveGaugeNeedle() {
        if (this.needleIncreasing == true) {
            float range = Mathf.Abs(MAX_ANGLE) + Mathf.Abs(MIN_ANGLE);
            //float percentage = (0.1f * Time.deltaTime);
            currentPower += (0.5f * Time.deltaTime);
            //Debug.Log("Needle Increasing : " + currentPower);
            this.needle.transform.localRotation = GetAnglePercentage(range, currentPower);
            if (currentPower > 0.99f) needleIncreasing = false;
        }
        else {
            float range = Mathf.Abs(MAX_ANGLE) + Mathf.Abs(MIN_ANGLE);
            //float percentage = (0.1f * Time.deltaTime);
            currentPower -= (0.5f * Time.deltaTime);
            //Debug.Log("Needle Decreasing : " + currentPower);
            this.needle.transform.localRotation = GetAnglePercentage(range, currentPower);
            if (currentPower < 0.02f) needleIncreasing = true;
        }
    }

    public void ActivateGauge() {
        this.gaugeActive = true;
    }

    public void StopGauge() {
        this.gaugeActive = false;
        totalPower = currentPower * MAX_POWER;
        needle.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, MAX_ANGLE);
        currentPower = 0.0f;
    }

    private Quaternion GetAnglePercentage(float range, float perct) {
        float delta = range * perct;
        float angle = MAX_ANGLE - delta;
        return Quaternion.Euler(0f, 0f, angle);
    }
}
