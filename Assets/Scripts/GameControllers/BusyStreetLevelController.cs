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
    private Transform grandmaSpawner = null;

    [SerializeField]
    private BroBotBusyStreetController player = null;

    [SerializeField]
    private Text starCount = null;

    [SerializeField]
    private Button launchButton = null;

    [SerializeField]
    private GameObject bg1 = null, bg2 = null;

    [SerializeField]
    private float speedAdjustmentBase = 1.0f;

    [SerializeField]
    private PowerGaugeScript powerGaugeScript = null;

    private float speedAdjustment = 1.0f;
    public float SpeedAdjustment {
        get { return speedAdjustment; }
    }

    private bool isPaused = false;
    public bool IsPaused {
        get { return isPaused; }
    }

    //private int consecutiveScores = 0;
    //private int score = 0;

    private float yTopBound = 7.5f;
    private float yBottomBound = -4.5f;

    private bool isHoldingGrandma = false;

    [SerializeField]
    private GameObject[] cars = new GameObject[0];

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
        speedAdjustment = speedAdjustmentBase;
        //instance.SpawnNewGrandma();
    }

    // Update is called once per frame
    void Update() {
        if (isPaused == true) return;

        if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }

        if(GameManager.instance.CurrentGameScore >= 3) {
            ShowWinScreen();
            return;
        }

        if(isHoldingGrandma == false) {
            GameManager.instance.PlayRobotMoveSound();
            MoveBackground(bg1);
            MoveBackground(bg2);
            speedAdjustment = speedAdjustmentBase;
        }
        else {
            speedAdjustment = 1.0f;
        }
    }

    public void MakeInstance() {
        if (instance == null)
            instance = this;
    }

    private void MoveBackground(GameObject bg) {
        float tempY = bg.transform.position.y;
        //tempY -= 1.0f * Time.fixedDeltaTime;
        tempY -= BusyStreetLevelController.instance.SpeedAdjustment * Time.deltaTime;

        if (tempY < -21.95f) {
            tempY = 21.95f;
        }

        bg.transform.position = new Vector3(bg.transform.position.x, tempY, bg.transform.position.z);
    }

    public void SetStarCountText() {
        instance.starCount.text = "x" + GameManager.instance.CurrentGameScore;
    }

    public bool GetPowerGaugeReadyToFire() {
        return instance.powerGaugeScript.ReadyToFire;
    }

    public float GetPowerGaugeTotalPower() {
        return instance.powerGaugeScript.TotalPower;
    }

    public bool GetPowerGaugeActive() {
        return instance.powerGaugeScript.GaugeActive;
    }

    public void ActivatePowerGauge() {
        instance.powerGaugeScript.ActivateGauge();
    }

    public void StopPowerGauge() {
        instance.powerGaugeScript.StopGauge();
    }

    public void GoToHub() {
        GameManager.instance.StopRobotMoveSound();
        int previousScore = GamePreferences.GetBusyStreetHighScore();
        if (GameManager.instance.CurrentGameScore >= previousScore) { 
            GameManager.instance.SaveGrandmaTossScore();
        }

        SceneManager.LoadScene("HubScene");
    }

    public void PauseGame() {
        Time.timeScale = 0.0f;
        isPaused = true;
        instance.pausePanel.SetActive(true);
        launchButton.gameObject.SetActive(false);
    }

    public void ResumeGame() {
        Time.timeScale = 1.0f;
        isPaused = false;
        instance.pausePanel.SetActive(false);
        launchButton.gameObject.SetActive(true);
    }
    
    public void GrandmaSquashed() {
        //Time.timeScale = 0.0f;
        //instance.pausePanel.SetActive(true);
        GrandmaTossSFXControllerScript.instance.PlayGrandmaSplatSFX();
        PauseGame();
        SpawnNewGrandma();
    }

    public void GrandmaMadeIt(Vector3 position) {
        GrandmaTossSFXControllerScript.instance.PlayGrandmaSuccessSFX();
        SpawnNewGrandma();
        // Score Points
        GameManager.instance.IncreaseScore();
        instance.SetStarCountText();
        Instantiate(starPrefab, position, Quaternion.identity);
    }

    // Spawn new Grandma
    private void SpawnNewGrandma() {
        GameObject newGrandma = Instantiate(instance.grandmaPrefab, 
                                            grandmaSpawner.position,
                                            Quaternion.identity) as GameObject;
        newGrandma.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        instance.isHoldingGrandma = false;
    }

    public void PickUpGrandma(GameObject grandma) {
        instance.isHoldingGrandma = true;
        GameManager.instance.StopRobotMoveSound();
        player.GetNewPassenger(grandma.GetComponent<Rigidbody2D>());
    }

    public void ResetGrandma(GameObject grandma) {
        instance.isHoldingGrandma = false;
        player.GetNewPassenger(grandma.GetComponent<Rigidbody2D>());
    }

    public void ShowWinScreen() {
        launchButton.gameObject.SetActive(false);
        Time.timeScale = 0.0f;
        instance.gameWinPanel.SetActive(true);
    }

    public void LaunchGrandma() {
        //instance.player.LaunchGrandma();

        //if (BusyStreetLevelController.instance.IsPaused == true) return;

        //if (Input.GetKeyDown(KeyCode.Space)) {
        if (instance.powerGaugeScript.GaugeActive == false) {
            //BusyStreetLevelController.instance.ActivatePowerGauge();
            instance.powerGaugeScript.ActivateGauge();
            Debug.Log("Activating Gauge");
        }
        else /*if (instance.powerGaugeScript.GaugeActive == true)*/ {
            //BusyStreetLevelController.instance.StopPowerGauge();
            instance.powerGaugeScript.StopGauge();
            Debug.Log("Stoping Gauge");
            //if (passenger != null) {
            //this.LaunchGrandma();
            instance.player.LaunchGrandma();
            //}
        }
            //if (passenger != null && BusyStreetLevelController.instance.GetPowerGaugeReadyToFire() == true) {
            //    this.LaunchGrandma();
            //}
        //}
    }
}
