using UnityEngine;
using System.Collections;

public class JethroController : MonoBehaviour {

	private Vector3 start = new Vector3(-2f, -3.5f);
	private Vector3 finish = new Vector3(1.5f, -3.5f);
	private float hitTime = 0f;
	private float returnTime = 0f;
	private float moveTime;
	private bool eventCalled = false;
	private bool ramming = false;
	private bool hitCorrectly = false;

	private float shakeStart = 0f;
	private float shakeStop = 0f;
	private Vector3 lastMove = Vector3.zero;

	public delegate void TreeHit();
	public event TreeHit treeHit;

	private float time;
	 
	void Start () {
	
	}

	void Update () {
		if(ramming) {
			float time = Time.timeSinceLevelLoad;
			if(time < hitTime) {
				transform.position = Vector3.Lerp(finish, start, (hitTime - time) / moveTime);
			} else if(time < returnTime) {
				if(!eventCalled) {
					treeHit();
					eventCalled = true;
				}
				transform.position = Vector3.Lerp(start, finish, (returnTime - time) / moveTime);
			} else {
				transform.position = start;
				hitTime = 0f;
				returnTime = 0f;
				eventCalled = false;
				ramming = false;
			}
		}

		//this part prob has to stay after the lerping
		if(shakeStop > Time.timeSinceLevelLoad && shakeStart < Time.timeSinceLevelLoad) {
			if(lastMove == Vector3.zero) {
				lastMove = randomVector() * .1f;
				transform.position += lastMove;
			} else {
				transform.position -= lastMove;
				lastMove = Vector3.zero;
			}
		}
	}

	public void ramTree(bool hitCorrectly) {
		time = Time.timeSinceLevelLoad;
		ramming = true;
		if(hitCorrectly)
			moveTime = .25f;
		else {
			moveTime = .75f;
			shakeStart = time + .4f;
			shakeStop = time + .75f;
		}
		returnTime = (hitTime = time + moveTime) + moveTime;
	}
		
	private Vector3 randomVector() {
		return new Vector3(Random.value, Random.value);
	}

}
