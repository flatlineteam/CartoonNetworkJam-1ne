using UnityEngine;
using System.Collections;

public class HeartCounter : MonoBehaviour {

	private HeartController heart1;
	private HeartController heart2;
	private HeartController heart3;

	void Start () {
		heart1 = transform.FindChild("Heart1").GetComponent<HeartController>();
		heart2 = transform.FindChild("Heart2").GetComponent<HeartController>();
		heart3 = transform.FindChild("Heart3").GetComponent<HeartController>();
		setHP(3);
	}

	public void setHP(int hp) {
		switch(hp) {
		case 0:
			heart1.setFull(false);
			heart2.setFull(false);
			heart3.setFull(false);
			break;
		case 1:
			heart1.setFull(true);
			heart2.setFull(false);
			heart2.setFull(false);
			break;
		case 2:
			heart1.setFull(true);
			heart2.setFull(true);
			heart3.setFull(false);
			break;
		case 3:
			heart1.setFull(true);
			heart2.setFull(true);
			heart3.setFull(true);
			break;
		}
	}
}
