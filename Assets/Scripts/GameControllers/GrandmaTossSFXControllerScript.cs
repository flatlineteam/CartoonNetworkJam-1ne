using UnityEngine;
using System.Collections;

public class GrandmaTossSFXControllerScript : MonoBehaviour {

    static public GrandmaTossSFXControllerScript instance = null;

    [SerializeField]
    private AudioClip grandmaToss = null, grandmaSplat = null, grandmaSuccess = null;

    // Use this for initialization
    void Start() {
        MakeInstance();
    }

    //// Update is called once per frame
    //void Update () {

    //}

    private void MakeInstance() {
        if (instance == null)
            instance = this;
    }

    public void PlayGrandmaTossSFX() {
        GameManager.instance.PlaySFX(grandmaToss);
    }

    public void PlayGrandmaSplatSFX() {
        GameManager.instance.PlaySFX(grandmaSplat);
    }

    public void PlayGrandmaSuccessSFX() {
        GameManager.instance.PlaySFX(grandmaSuccess);
    }
}
