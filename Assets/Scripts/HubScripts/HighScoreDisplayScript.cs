using UnityEngine;
using System.Collections;

public class HighScoreDisplayScript : MonoBehaviour {
    [SerializeField]
    private GameObject[] stars = new GameObject[0];

    private int scoreCount = 0;

	// Use this for initialization
	void Start () {
	    
	}

    void Awake() {
        scoreCount = GamePreferences.GetBusyStreetHighScore();
        if (scoreCount > 3) scoreCount = 3;
        for(int n = 0; n < scoreCount; ++scoreCount) {
            stars[n].SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
