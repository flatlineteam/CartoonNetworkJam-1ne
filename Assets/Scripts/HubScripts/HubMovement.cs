using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class HubMovement : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerDown(PointerEventData data) {
        if(this.gameObject.name == "Right") {
            HubControllerScript.instance.MovePlayer(true);
        }
        else if (this.gameObject.name == "Left") {
            HubControllerScript.instance.MovePlayer(false);
        }
    }

    public void OnPointerUp (PointerEventData data) {
        HubControllerScript.instance.StopPlayer();
    }
}
