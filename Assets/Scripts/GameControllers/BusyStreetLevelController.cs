using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BusyStreetLevelController : MonoBehaviour {

    static public BusyStreetLevelController instance = null;

    [SerializeField]
    private GameObject pausePanel = null;

    [SerializeField]
    private GameObject grandmaPrefab = null;

    [SerializeField]
    private BroBotBusyStreetController player = null;

    private float yTopBound = 10.0f;
    private float yBottomBound = -7.5f;

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

    public void GrandmaSquashed() {
        Time.timeScale = 0.0f;
        instance.pausePanel.SetActive(true);
    }

    public void GrandmaMadeIt() {
        SpawnNewGrandma();
        // Score Points
    }

    // Spawn new Grandma
    private void SpawnNewGrandma() {
        GameObject newGrandma = Instantiate(instance.grandmaPrefab, 
                                            new Vector3(player.transform.position.x,
                                                        Random.Range(instance.YBottomBound + 0.75f, instance.YTopBound - 0.75f),
                                                        0.0f),
                                            Quaternion.identity) as GameObject;
        newGrandma.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //player.GetNewPassenger(newGrandma.GetComponent<Rigidbody2D>());
    }

    public void PickUpGrandma(GameObject grandma) {
        player.GetNewPassenger(grandma.GetComponent<Rigidbody2D>());
    }

    public void ResetGrandma(GameObject grandma) {
        //grandma.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        player.GetNewPassenger(grandma.GetComponent<Rigidbody2D>());
    }
}
