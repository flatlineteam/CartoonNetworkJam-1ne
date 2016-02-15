using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class BusyStreetLevelController : MonoBehaviour {

    static public BusyStreetLevelController instance = null;

    [SerializeField]
    private GameObject pausePanel = null, gameWinPanel = null;

    [SerializeField]
    private GameObject grandmaPrefab = null, starPrefab = null;

    [SerializeField]
    private BroBotBusyStreetController player = null;

    [SerializeField]
    private Text starCount = null;

    [SerializeField]
    private Button launch = null;

    private int consecutiveScores = 0;
    private int score = 0;

    private float yTopBound = 7.5f;
    private float yBottomBound = -4.5f;

    public float YTopBound {
        get { return yTopBound; }
    }
    
    public float YBottomBound {
        get { return yBottomBound; }
    }

    // Use this for initialization
    void Start() {
        MakeInstance();
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }

        if(GameManager.instance.CurrentGameScore >= 3) {
            ShowWinScreen();
        }
    }

    public void MakeInstance() {
        if (instance == null)
            instance = this;
    }

    public void SetStarCountText() {
        instance.starCount.text = "x" + GameManager.instance.CurrentGameScore;
    }

    public void GoToHub() {
       // Debug.Log("My Score : " + GameManager.instance.CurrentGameScore + " XXX Current High Score : " + GamePreferences.GetBusyStreetHighScore());
        int previousScore = GamePreferences.GetBusyStreetHighScore();
        if (GameManager.instance.CurrentGameScore >= previousScore) { 
            GameManager.instance.SaveGrandmaTossScore();
            //Debug.Log("This is happening");
        }

        SceneManager.LoadScene("HubScene");
    }

    private void PauseGame() {
        Time.timeScale = 0.0f;
        instance.pausePanel.SetActive(true);
        launch.gameObject.SetActive(false);
    }

    public void ResumeGame() {
        Time.timeScale = 1.0f;
        instance.pausePanel.SetActive(false);
        launch.gameObject.SetActive(true);
    }
    
    public void GrandmaSquashed() {
        Time.timeScale = 0.0f;
        instance.pausePanel.SetActive(true);
    }

    public void GrandmaMadeIt(Vector3 position) {
        SpawnNewGrandma();
        // Score Points
        GameManager.instance.IncreaseScore();
        instance.SetStarCountText();
        Instantiate(starPrefab, position, Quaternion.identity);
    }

    // Spawn new Grandma
    private void SpawnNewGrandma() {
        GameObject newGrandma = Instantiate(instance.grandmaPrefab, 
                                            new Vector3(player.transform.position.x,
                                                        Random.Range(instance.YBottomBound + 0.75f, instance.YTopBound - 0.75f),
                                                        0.0f),
                                            Quaternion.identity) as GameObject;
        newGrandma.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public void PickUpGrandma(GameObject grandma) {
        player.GetNewPassenger(grandma.GetComponent<Rigidbody2D>());
    }

    public void ResetGrandma(GameObject grandma) {
        player.GetNewPassenger(grandma.GetComponent<Rigidbody2D>());
    }

    public void ShowWinScreen() {
        Time.timeScale = 0.0f;
        instance.gameWinPanel.SetActive(true);
    }

    public void LaunchGrandma() {
        instance.player.LaunchGrandma();
    }
}
