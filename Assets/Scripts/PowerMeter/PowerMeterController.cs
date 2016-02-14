using UnityEngine;
using System.Collections;

public class PowerMeterController : MonoBehaviour {

	public float powerTarget = -1f; //should be set between 0f and 1f
	public float difficulty = -1f; //should be set between 0f and 1f

	public delegate void PowerMeterFinishedHandler(float target, float result);
	public event PowerMeterFinishedHandler Finished;

	private Transform needle;
	private Transform target;
	private SpriteRenderer targetSprite;

	//the angles that represent the max position for the needle
	private readonly float left = 55f;
	private readonly float right = -55f;

	private bool idle = true;
	private float currentPowerLevel = 0f;
	private bool opacityDecreasing = true;
	private bool needleIncreasing = true;
	private bool done = false;

	void Awake() {
		if(powerTarget < 0f || difficulty < 0f)
			Debug.LogError("Power Meter properties not set in inspector");
		
		needle = transform.FindChild("NeedleContainer");
		target = transform.FindChild("PowerTargetContainer");
		if(needle == null || target == null)
			Debug.LogError("Power Meter object heirarchy not setup correctly");

		targetSprite = target.gameObject.GetComponentInChildren<SpriteRenderer>();

		//Point the target indicator in the correct direction
		target.localRotation = getRotationFromPercentage(powerTarget);
	}

	//use this to have the player use the power meter again
	public void reset(float powerTarget, float difficulty) {
		this.powerTarget = powerTarget;
		this.difficulty = difficulty;

		currentPowerLevel = 0f;
		opacityDecreasing = true;
		needleIncreasing = true;
		done = false;

		target.localRotation = getRotationFromPercentage(powerTarget);
	}

	void Update() {
		//pulse the opacity of the target indicator for increased visibility and clarity for players
		if(idle) {
			if(opacityDecreasing) {
				float a = targetSprite.color.a - .5f * Time.deltaTime;
				setTargetSpriteAlpha(a);
				if(a <= .5f)
					opacityDecreasing = false;
			} else {
				float a = targetSprite.color.a + .5f * Time.deltaTime;
				setTargetSpriteAlpha(a);
				if(a >= .95f)
					opacityDecreasing = true;
			}
		} else if(!done) { //Once the player has tapped once, stop pulsing target indicator, start moving needle
			if(needleIncreasing) {
				currentPowerLevel += 2f * difficulty * Time.deltaTime;
				needle.localRotation = getRotationFromPercentage(currentPowerLevel);
				if(currentPowerLevel > .95f)
					needleIncreasing = false;
			} else {
				currentPowerLevel -= 2f * difficulty * Time.deltaTime;
				needle.localRotation = getRotationFromPercentage(currentPowerLevel);
				if(currentPowerLevel < .05f)
					needleIncreasing = true;
			}
		}


		#if UNITY_STANDALONE_WIN
		if(Input.GetMouseButtonUp(0) && !done) {
		#endif
		#if UNITY_ANDROID
		if(Input.touchCount > 0 && !done) {
		#endif
			if(idle)
				idle = false;
			else {
				if(Finished == null)
					Debug.LogError("No event listener for Power Meter was added");
				else {
					Finished(powerTarget, currentPowerLevel);
					done = true;
				}
			}
		}
		
	}

	private void setTargetSpriteAlpha(float a) {
		Color c = targetSprite.color;
		c.a = a;
		targetSprite.color = c;
	}

	private Quaternion getRotationFromPercentage(float perc) {
		float range = Mathf.Abs(right) + Mathf.Abs(left);
		float angleDelta = range * perc;
		float angle = left - angleDelta;
		return Quaternion.Euler(0f, 0f, angle);
	}
}
