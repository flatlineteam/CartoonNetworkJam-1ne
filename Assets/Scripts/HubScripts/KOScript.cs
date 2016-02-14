using UnityEngine;
using System.Collections;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class KOScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //void OnPointerDown(PointerEventData eventData) {
    //void OnMouseDown() { 
    //    HubControllerScript.instance.PlayKOLevel();
    //}

    void PlayLevel() {
        HubControllerScript.instance.ShowKOLevel();
    }

    void SkipLevel() {
        HubControllerScript.instance.DontPlayLevel();
    }
}
