using UnityEngine;
using System.Collections;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class RadiclesScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //void OnPointerDown(PointerEventData eventData) {
    //void OnMouseDown(/*PointerEventData eventData*/) { 
    //    HubControllerScript.instance.PlayRadiclesLevel();
    //}

    void PlayLevel() {
        HubControllerScript.instance.ShowRadiclesLevel();
    }
}
