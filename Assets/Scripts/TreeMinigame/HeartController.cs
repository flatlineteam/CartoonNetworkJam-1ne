using UnityEngine;
using System.Collections;

public class HeartController : MonoBehaviour {

	GameObject emptyHeart;
	GameObject fullHeart;

	// Use this for initialization
	void Start () {
		emptyHeart = transform.FindChild("EmptyHeart").gameObject;
		fullHeart = transform.FindChild("FullHeart").gameObject;
		setFull(true);
	}
	
	public void setFull(bool full) {
		fullHeart.SetActive(full);
		emptyHeart.SetActive(!full);
	}
}
