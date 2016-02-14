using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    static public GameManager instance = null;

    private int numJethrosRescued = 0;
    public int NumJethrosRescued {
        get { return numJethrosRescued; }
    }

    void Awake() {
        MakeSingleton();
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
}
