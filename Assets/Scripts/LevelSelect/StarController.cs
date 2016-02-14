using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {

	public GameObject greyStar;
	public GameObject goldStar;

	// Use this for initialization
	void Start () {
		greyStar = transform.FindChild("GreyStar").gameObject;
		goldStar = transform.FindChild("GoldStar").gameObject;
		setFull(true);
	}

	public void setFull(bool full) {
		goldStar.SetActive(full);
		greyStar.SetActive(!full);
	}
}
