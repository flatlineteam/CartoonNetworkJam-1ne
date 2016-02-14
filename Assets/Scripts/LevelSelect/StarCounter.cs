using UnityEngine;
using System.Collections;

public class StarCounter : MonoBehaviour {

	public StarController star1;
	public StarController star2;
	public StarController star3;

	void Start () {
		setScore(3);
	}

	public void setScore(int score) {
		switch(score) {
		case 0:
			star1.setFull(false);
			star2.setFull(false);
			star3.setFull(false);
			break;
		case 1:
			star1.setFull(true);
			star2.setFull(false);
			star3.setFull(false);
			break;
		case 2:
			star1.setFull(true);
			star2.setFull(true);
			star3.setFull(false);
			break;
		case 3:
			star1.setFull(true);
			star2.setFull(true);
			star3.setFull(true);
			break;
		}
	}
}
