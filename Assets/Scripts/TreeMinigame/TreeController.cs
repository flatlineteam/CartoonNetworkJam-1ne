using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour {

	private float shakeTime = 0f;
	private float lastTime; //used for float overflow checking
	private Vector3 lastMove = Vector3.zero;

	void Update () {
		if(lastTime > Time.timeSinceLevelLoad)
			shakeTime = 0;
		
		if(shakeTime > Time.timeSinceLevelLoad) {
			if(lastMove == Vector3.zero) {
				lastMove = randomVector() * .1f;
				transform.position += lastMove;
			} else {
				transform.position -= lastMove;
				lastMove = Vector3.zero;
			}
		}

		lastTime = Time.timeSinceLevelLoad;
	}

	public void hit(bool hard) {
		shakeTime = hard ? Time.timeSinceLevelLoad + .5f : Time.timeSinceLevelLoad + .25f;
	}

	private Vector3 randomVector() {
		return new Vector3(Random.value, Random.value);
	}
}
