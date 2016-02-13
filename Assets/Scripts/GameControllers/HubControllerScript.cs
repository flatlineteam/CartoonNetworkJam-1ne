using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HubControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayKOLevel() {
        SceneManager.LoadScene("TestFrogger");
    }

    public void PlayEnidLevel() {
        Debug.Log("No Level Created Yet!!");
    }

    public void PlayRadiclesLevel() {
        SceneManager.LoadScene("TestRacing");
    }
}
