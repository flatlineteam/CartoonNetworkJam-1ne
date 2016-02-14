using UnityEngine;
using System.Collections;

public class HeartController : MonoBehaviour {

	public GameObject emptyHeart;
	public GameObject fullHeart;

	// Use this for initialization
	void Start () {
		setFull(true);
	}
	
	public void setFull(bool full) {
		fullHeart.SetActive(full);
		emptyHeart.SetActive(!full);
	}
}
