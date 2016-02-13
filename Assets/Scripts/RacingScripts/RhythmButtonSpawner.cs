using UnityEngine;
using System.Collections;

public class RhythmButtonSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject buttonPrefab = null;

    private float maxCountDown = 2.50f;
    private float countDown = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        countDown -= Time.deltaTime;
        if (countDown < 0.0f) {
            countDown = maxCountDown;
            Instantiate(buttonPrefab, new Vector3(this.transform.position.x, RacingGameController.instance.TopTarget.transform.position.y, 0.0f), Quaternion.identity);
        }
	}
}
