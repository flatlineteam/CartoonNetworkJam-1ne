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

    void SkipLevel() {
        HubControllerScript.instance.DontPlayLevel();
    }

    //void OnTriggerExit2D(Collider2D coll) {
    //    if (coll.gameObject.layer == 8) {
    //        //Debug.Log("This Is Happening!!");
    //        //coll.SendMessage("SkipLevel");
    //        this.SkipLevel();
    //    }
    //}
}
