using UnityEngine;
using System.Collections;

public class GamePreferences {

    static private string busyStreetHighScore = "busyStreetHighScore";
    static private string racingGameHighScore = "racingGameHighScore";
    static private string treeGameHighScore = "treeGameHighScore";

    static public void SetBusyStreetHighScore(int score) {
        PlayerPrefs.SetInt(busyStreetHighScore, score);
    }

    static public int GetBusyStreetHighScore() {
        return PlayerPrefs.GetInt(busyStreetHighScore);
    }

    static public void SetRacingGameHighScore(int score) {
        PlayerPrefs.SetInt(racingGameHighScore, score);
    }

    static public int GetRacingGameHighScore() {
        return PlayerPrefs.GetInt(racingGameHighScore);
    }

    static public void SetTreeGameHighScore(int score) {
        PlayerPrefs.SetInt(treeGameHighScore, score);
    }

    static public int GetTreeGameHighScore() {
        return PlayerPrefs.GetInt(treeGameHighScore);
    }
}
