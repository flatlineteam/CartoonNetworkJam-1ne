using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RacingGameController : MonoBehaviour {

    static public RacingGameController instance = null;

    [SerializeField]
    private RhythmButtonSpawner spawner = null;

    private float maxCountDown = 3.0f;
    private float countDown = 0.0f;

    public List<RhythmGuiMovement> rhythmButtons = new List<RhythmGuiMovement>();

    void Awake() {
        MakeInstance();
    }

    // Update is called once per frame
    void Update() {
        countDown -= Time.deltaTime;
        if (countDown < 0.0f) {
            countDown = maxCountDown * Random.Range(0.75f, 1.25f);
            spawner.ReleaseRhythmButton();
        }
    }

    public void MakeInstance() {
        if (instance == null)
            instance = this;
    }

    public void GetNextRhythmButton() {
        rhythmButtons.RemoveAt(0);
    }
}
