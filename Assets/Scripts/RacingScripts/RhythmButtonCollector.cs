using UnityEngine;
using System.Collections;

public class RhythmButtonCollector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.GetComponent<RhythmGuiMovement>() == true) {
            Destroy(coll.gameObject);
        }
    }
}
