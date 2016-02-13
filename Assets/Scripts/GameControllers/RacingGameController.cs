using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class RacingGameController : MonoBehaviour {

    static public RacingGameController instance = null;

    [SerializeField]
    private RhythmButtonSpawner spawner = null;

    [SerializeField]
    private GameObject pausePanel = null;

    private float maxCountDown = 3.0f;
    private float countDown = 0.0f;

    public List<RhythmGuiMovement> rhythmButtons = new List<RhythmGuiMovement>();

    void Awake() {
        Time.timeScale = 1.0f;
        MakeInstance();
    }

    // Update is called once per frame
    void Update() {
        countDown -= Time.deltaTime;
        if (countDown < 0.0f) {
            countDown = maxCountDown * Random.Range(0.75f, 1.25f);
            spawner.ReleaseRhythmButton();
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
    }

    public void MakeInstance() {
        if (instance == null)
            instance = this;
    }

    public void GetNextRhythmButton() {
        rhythmButtons.RemoveAt(0);
    }

    public void GoToHub() {
        SceneManager.LoadScene("TestHub");
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
