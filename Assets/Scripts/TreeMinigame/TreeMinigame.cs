using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//I'd just like to say that this code was nice and clean,
//and I'm aware that that's not the case anymore
public class TreeMinigame : MonoBehaviour {

	public JethroController jethro;
	public TreeController tree;
	public PowerMeterController powerMeter;
	public HeartCounter heartCounter;
	public GameObject winPanel;
	public Text triesText;
	public StarCounter starCounter;

	private bool hitCorrectly = false;
	private int treeHP = 3;
	private int tries = 0;

	// Use this for initialization
	void Start () {
		powerMeter.reset(.33f, .25f);

		//use this for things that you want to happen after the hit animations
		jethro.treeHit += () => {
			tree.hit(treeHP, hitCorrectly);
			heartCounter.setHP(treeHP);
			powerMeter.shouldHold(false);
			if(treeHP == 3)
				powerMeter.reset(.33f, .3f);
			else if(treeHP == 2)
				powerMeter.reset(.66f, .5f);
			else if(treeHP == 1)
				powerMeter.reset(.9f, .75f);
			else {
				win();
				powerMeter.shouldHold(true);
			}
		};
			
		powerMeter.Finished += (float target, float result) => {
			if(jethro.isRamming())
				return;
			powerMeter.shouldHold(true);

			//Debug.Log("target: " + target + ", result: " + result);
			if(result > target + .05f) {
				hitCorrectly = false;
				treeHP++;
			} else if(result < target - .05f) {
				hitCorrectly = false;
				treeHP++;
			} else {
				hitCorrectly = true;
				treeHP--;
			}
				
			if(treeHP > 3)
				treeHP = 3;

			tries++;


			tree.attack();

			jethro.ramTree(hitCorrectly);
		};
	}

	void Update () {
		
	}

	private void win() {
		triesText.text = "Tries: " + tries;
		int stars = 3;
		if(tries > 3)
			stars = 2;
		if(tries > 5)
			stars = 1;
		starCounter.setScore(stars);
		winPanel.SetActive(true);
	}

	private void lose() {

	}
}