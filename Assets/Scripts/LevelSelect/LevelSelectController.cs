using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectController : MonoBehaviour {

	public Button leftButton;
	public Button rightButton;
	public LevelSelection[] levels;

	public Transform cameraT;
	public Transform jethro;

	private int index = 0;

	private bool moving = false;
	private float moveStartTime;
	private Vector3 oldCameraPos;
	private Vector3 oldJethroPos;
	private Vector3 newCameraPos;
	private Vector3 newJethroPos;

	void Start () {
		if(levels.Length < 2)
			Debug.LogError("There should really be more levels guys, you're messing up my code.");

		switchTo(index);
	}

	void Update() {
		if(moving) {
			float perc = (Time.timeSinceLevelLoad - moveStartTime) / 1f;
			if(perc > 1f) {
				perc = 1f;
				moving = false;
			}
			cameraT.position = Vector3.Lerp(oldCameraPos, newCameraPos, perc);
			jethro.position = Vector3.Lerp(oldJethroPos, newJethroPos, perc);
		}

			
	}

	public void left() {
		if(index != 0)
			switchTo(index-1);
	}

	public void right() {
		if(index != levels.Length - 1)
			switchTo(index+1);
	}

	private void switchTo(int i) {
		levels[index].setIsActive(false);
		index = i;

		levels[i].setScore(2); //figure out to keep track of scores and then implement it here
		levels[i].setIsActive(true);

		oldJethroPos = jethro.position;
		newJethroPos = oldJethroPos;
		newJethroPos.x = levels[i].jethroX;

		oldCameraPos = cameraT.position;
		newCameraPos = oldCameraPos;
		newCameraPos.x = levels[i].cameraX;

		moving = true;
		moveStartTime = Time.timeSinceLevelLoad;

		if(i == 0)
			leftButton.gameObject.SetActive(false);
		else if(i == levels.Length - 1)
			rightButton.gameObject.SetActive(false);
		else {
			leftButton.gameObject.SetActive(true);
			rightButton.gameObject.SetActive(true);
		}
	}
}
