using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {

	public GameObject greyStar;
	public GameObject goldStar;

	// Use this for initialization
	void Start () {
		setFull(true);
	}

	public void setFull(bool full) {
		Debug.Log("" + gameObject.name + " set to: " + full);
		goldStar.SetActive(full);
		greyStar.SetActive(!full);
	}
}
