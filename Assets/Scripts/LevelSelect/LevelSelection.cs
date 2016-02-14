using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelection : MonoBehaviour {

	public StarCounter starCounter;
	public float cameraX = -5.8f;
	public float jethroX = -8.05f;
	public int sceneIndex;

	private int score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setIsActive(bool active) {
		gameObject.SetActive(active);
	}

	public void setScore(int score) {
		Debug.Log("yo");
		this.score = score;
		starCounter.setScore(score);
	}

	public void play() {
		SceneManager.LoadScene(sceneIndex);
	}
}
