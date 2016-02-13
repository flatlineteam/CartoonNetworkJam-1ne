using UnityEngine;
using System.Collections;

public class BusyStreetLevelController : MonoBehaviour {

    static public BusyStreetLevelController instance = null;

    // Use this for initialization
    void Start() {
        MakeInstance();
    }

    // Update is called once per frame
    void Update() {

    }

    public void MakeInstance() {
        if (instance == null)
            instance = this;
    }
}
