using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HubControllerScript : MonoBehaviour {

    static public HubControllerScript instance = null;

    [SerializeField]
    private GameObject radiclesLevel = null, enidLevel = null, koLevel = null;

    // Use this for initialization
    void Start() {
        MakeInstance();
        Time.timeScale = 1.0f;
    }

    void Awake() {
        MakeInstance();
        Time.timeScale = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void MakeInstance() {
        if (instance == null)
            instance = this;
    }

    public void PlayKOLevel() {
        SceneManager.LoadScene("BusyStreetScene");
    }

    public void PlayEnidLevel() {
        Debug.Log("No Level Created Yet!!");
    }

    public void PlayRadiclesLevel() {
        SceneManager.LoadScene("RacingScene");
    }

    public void ShowRadiclesLevel() {
        instance.radiclesLevel.SetActive(true);
    }

    public void ShowEnidLevel() {
        instance.enidLevel.SetActive(true);
    }

    public void ShowKOLevel() {
        instance.koLevel.SetActive(true);
    }

    public void DontPlayLevel() {
        //Debug.Log("This is Happening");
       /* if (instance.radiclesLevel.activeSelf == true)*/ instance.radiclesLevel.SetActive(false);
       /* if (instance.enidLevel.activeSelf == true)*/ instance.enidLevel.SetActive(false);
       /* if (instance.koLevel.activeSelf == true)*/ instance.koLevel.SetActive(false);
    }
}
