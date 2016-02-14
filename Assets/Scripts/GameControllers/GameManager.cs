using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    static public GameManager instance = null;

    private int currentGameScore = 0;
    public int CurrentGameScore {
        get { return currentGameScore; }
    }

    private int numJethrosRescued = 0;
    public int NumJethrosRescued {
        get { return numJethrosRescued; }
    }

    void Start() {
        GamePreferences.ResetAllScores();
    }

    void Awake() {
        MakeSingleton();
        //GamePreferences.ResetAllScores();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void MakeSingleton() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else { 
            Destroy(this.gameObject);
        }
    }

    public void AddJethros(int value) {
        if (value < 0) value = 0;
        numJethrosRescued += value;
    }

    public void IncreaseScore() {
        ++this.currentGameScore;
    }

    public void SaveGrandmaTossScore() {
        GamePreferences.SetBusyStreetHighScore(instance.currentGameScore);
        instance.currentGameScore = 0;
    }

    public void SaveRacingScore() {
        GamePreferences.SetRacingGameHighScore(instance.currentGameScore);
    }

}
