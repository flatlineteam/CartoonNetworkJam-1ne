using UnityEngine;
using System.Collections;

public class RhythmButtonSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject buttonPrefab = null;

    [SerializeField]
    private CircleCollider2D target = null;

	// Use this for initialization
	void Start () {
        Vector3 newPos = new Vector3(this.transform.position.x,
                                     target.transform.position.y,
                                     0.0f);

        this.transform.position = newPos;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ReleaseRhythmButton() {
        GameObject newGuiButton = (GameObject)Instantiate(buttonPrefab, this.transform.position, Quaternion.identity);
        newGuiButton.SendMessage("SetTarget", target);
        RacingGameController.instance.rhythmButtons.Add(newGuiButton.GetComponent<RhythmGuiMovement>());
    }
}
