using UnityEngine;
using System.Collections;

public class BroBotRacingController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (/*Input.GetKey(KeyCode.W) || */Input.GetKeyDown(KeyCode.W)) {
            if (RacingGameController.instance.rhythmButtons[0].IsInsideGoal == true) {
                this.transform.position += Vector3.up * 3;
                RacingGameController.instance.GetNextRhythmButton();
            }
            else if (RacingGameController.instance.rhythmButtons[0].IsInContactWithGoal == true) { 
                this.transform.position += Vector3.up;
                RacingGameController.instance.GetNextRhythmButton();
            }
        }
        if (/*Input.GetKey(KeyCode.S) ||*/ Input.GetKeyDown(KeyCode.S)) {
            if (RacingGameController.instance.rhythmButtons[0].IsInsideGoal == true) { 
                this.transform.position += Vector3.down * 3;
                RacingGameController.instance.GetNextRhythmButton();
            }
            else if (RacingGameController.instance.rhythmButtons[0].IsInContactWithGoal == true) { 
                this.transform.position += Vector3.down;
                RacingGameController.instance.GetNextRhythmButton();
            }
        }
    }
}
