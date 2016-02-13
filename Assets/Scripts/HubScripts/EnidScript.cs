using UnityEngine;
using System.Collections;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class EnidScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //void OnPointerDown(PointerEventData eventData) {
    //void OnMouseDown() {
    //    HubControllerScript.instance.PlayEnidLevel();
    //}

    void PlayLevel() {
        HubControllerScript.instance.ShowEnidLevel();
    }
}
