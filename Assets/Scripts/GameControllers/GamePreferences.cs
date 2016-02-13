using UnityEngine;
using System.Collections;

public class GamePreferences {

    static private string busyStreetHighScore = "busyStreetHighScore";

    static public void SetBusyStreetHighScore(int score) {
        PlayerPrefs.SetInt(busyStreetHighScore, score);
    }

    static public int GetBusyStreetHighScore() {
        return PlayerPrefs.GetInt(busyStreetHighScore);
    }
}
