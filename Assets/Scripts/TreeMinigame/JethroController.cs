using UnityEngine;
using System.Collections;

public class JethroController : MonoBehaviour {

	private Vector3 start = new Vector3(2.5f, -2.5f);
	private Vector3 finish = new Vector3(2.25f, -2.5f);
	public float hitTime = 0f;
	public float returnTime = 0f;
	public float startTime = 0f;
	private bool eventCalled = false;

	public delegate void TreeHit();
	public event TreeHit treeHit;

	 
	void Start () {
	
	}

	void Update () {
		if(Time.timeSinceLevelLoad < hitTime)
			transform.position = Vector3.Lerp(start, finish, (hitTime - startTime) / .25f);
		else if(Time.timeSinceLevelLoad < returnTime) {
			if(!eventCalled)
				treeHit();
			eventCalled = true;
			transform.position = Vector3.Lerp(finish, start, (returnTime - hitTime) / .25f);
		} else {
			transform.position = start;
			hitTime = 0f;
			returnTime = 0f;
			startTime = 0f;
			eventCalled = false;
		}
	}

	public void ramTree() {
		returnTime = (hitTime = (startTime = Time.timeSinceLevelLoad) + .25f) + .25f; //im so lazy
	}
}
