using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HubControllerScript : MonoBehaviour {

    static public HubControllerScript instance = null;

    [SerializeField]
    private GameObject player = null;

    [SerializeField]
    private GameObject pausePanel = null;   

    [SerializeField]
    private GameObject radiclesLevel = null, enidLevel = null, koLevel = null;

    [SerializeField]
    private GameObject[] grandmaTossStars = new GameObject[0];

    [SerializeField]
    private GameObject garRightImage = null, garLeftImage = null;

    [SerializeField]
    private Button right = null, left = null;

    private bool isPaused = false;
    public bool IsPaused {
        get { return isPaused; }
    }

    // Use this for initialization
    void Start() {
        MakeInstance();
        Time.timeScale = 1.0f;
        //GamePreferences.SetBusyStreetHighScore(0);
    }

    void Awake() {
        MakeInstance();
        Time.timeScale = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Escape)) {
            instance.PauseGame();
        }
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
        instance.ShowKOLevelStars();
        instance.koLevel.SetActive(true);
        instance.ShowKOLevelStars();
    }

    public void DontPlayLevel() {
        instance.radiclesLevel.SetActive(false);
        instance.enidLevel.SetActive(false);
        instance.koLevel.SetActive(false);
    }

    public void FlipPlayer() {
        player.GetComponent<RoBroScript>().FlipMe();

        instance.SwapButtonControls();

        if (right.gameObject.activeSelf == true)
            StartCoroutine(HubControllerScript.instance.DeactivateAfterDelay(garLeftImage));
        else
            StartCoroutine(HubControllerScript.instance.DeactivateAfterDelay(garRightImage));

        //instance.SwapButtonControls();
    }

    private void SwapButtonControls() {
        if(left.gameObject.activeSelf == true) {
            left.gameObject.SetActive(false);
            right.gameObject.SetActive(true);
        }
        else if (right.gameObject.activeSelf == true) {
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(false);
        }

        player.GetComponent<RoBroScript>().GoToIdle();
    }

    private void ShowKOLevelStars() {
        foreach (GameObject go in instance.grandmaTossStars) {
            go.SetActive(false);
        }
        int highScore = GamePreferences.GetBusyStreetHighScore();
        //Debug.Log(highScore);
        if (highScore > 3) highScore = 3;
        if (highScore < 0) highScore = 0;
        for (int n = 0; n < highScore; ++n) {
            instance.grandmaTossStars[n].SetActive(true);
        }
    }

    public void PauseGame() {
        Time.timeScale = 0.0f;
        isPaused = true;
        pausePanel.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1.0f;
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void MovePlayer(bool right = true) {
        if (right == true) instance.MovePlayerRight();
        else instance.MovePlayerLeft();
    }

    private void MovePlayerRight() {
        player.GetComponent<RoBroScript>().SetMovement(true);
    }

    private void MovePlayerLeft() {
        player.GetComponent<RoBroScript>().SetMovement(false);
    }

    public void StopPlayer() {
        player.GetComponent<RoBroScript>().GoToIdle();
    }

    IEnumerator DeactivateAfterDelay(GameObject obj) {
        obj.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        obj.gameObject.SetActive(false);
    }
}
