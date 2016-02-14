using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {

	public GameObject greyStar;
	public GameObject goldStar;

	// Use this for initialization
	void Start () {
	}

	public void setGold(bool gold) {
		Debug.Log("" + gameObject.name + " set to: " + gold);
		goldStar.SetActive(gold);
		greyStar.SetActive(!gold);
	}
}
