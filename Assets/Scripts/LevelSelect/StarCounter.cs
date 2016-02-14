using UnityEngine;
using System.Collections;

public class StarCounter : MonoBehaviour {

	public StarController star1;
	public StarController star2;
	public StarController star3;

	void Start () {
	}

	public void setScore(int score) {
		Debug.Log("this was called");
		switch(score) {
		case 0:
			star1.setGold(false);
			star2.setGold(false);
			star3.setGold(false);
			break;
		case 1:
			star1.setGold(true);
			star2.setGold(false);
			star3.setGold(false);
			break;
		case 2:
			star1.setGold(true);
			star2.setGold(true);
			star3.setGold(false);
			break;
		case 3:
			star1.setGold(true);
			star2.setGold(true);
			star3.setGold(true);
			break;
		}
	}
}
