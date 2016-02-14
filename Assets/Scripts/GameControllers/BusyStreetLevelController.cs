using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BusyStreetLevelController : MonoBehaviour {

    static public BusyStreetLevelController instance = null;

    [SerializeField]
    private GameObject pausePanel = null;

    // Use this for initialization
    void Start() {
        MakeInstance();
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            //instance.pausePanel.SetActive(true);
            PauseGame();
        }
    }

    public void MakeInstance() {
        if (instance == null)
            instance = this;
    }

    public void GoToHub() {
        //SceneManager.LoadScene("TestHub");
        SceneManager.LoadScene("HubScene");
    }

    private void PauseGame() {
        Time.timeScale = 0.0f;
        instance.pausePanel.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1.0f;
        instance.pausePanel.SetActive(false);
    }
}
