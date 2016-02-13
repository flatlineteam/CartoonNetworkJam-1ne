using UnityEngine;
using System.Collections;

public class TreeMinigame : MonoBehaviour {

	public JethroController jethro;
	public TreeController tree;
	public PowerMeterController powerMeter;
	public HeartCounter heartCounter;

	private bool hitCorrectly = false;
	private int treeHP = 3;
	private int tries = 0;

	// Use this for initialization
	void Start () {
		powerMeter.reset(.33f, .25f);

		//use this for things that you want to happen after the hit animations
		jethro.treeHit += () => {
			tree.hit(hitCorrectly);
			heartCounter.setHP(treeHP);
			if(treeHP == 3)
				powerMeter.reset(.33f, .3f);
			else if(treeHP == 2)
				powerMeter.reset(.66f, .5f);
			else if(treeHP == 1)
				powerMeter.reset(.9f, .75f);
			else
				win();
		};
			
		powerMeter.Finished += (float target, float result) => {
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

			jethro.ramTree();
		};
	}

	void Update () {
		
	}

	private void win() {

	}

	private void lose() {

	}
}
