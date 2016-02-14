using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TouchGrandmaToss : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnPointerDown(PointerEventData data) {
        BusyStreetLevelController.instance.LaunchGrandma();
    }

    public void OnPointerUp(PointerEventData data) {
        // Do nothing for now
    }
}
