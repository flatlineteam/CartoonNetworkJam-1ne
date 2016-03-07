using UnityEngine;
using System.Collections;

public class GrandmaScript : MonoBehaviour {

    private bool isBeingThrown = false, isWaiting = true;

    private float speed = 11.5f;

    [SerializeField]
    private Sprite grandmaIdle = null, grandmaToss = null;

    [SerializeField]
    private SpriteRenderer myRenderer = null;

    // Use this for initialization
    //void Start () {

    //}

    // Update is called once per frame
    void Update() {

        if (BusyStreetLevelController.instance.IsPaused == true) return;

        if (isWaiting == true) {
            MoveGrandma();
        }
        if (isBeingThrown == true) {
            this.transform.position += Vector3.right * Time.deltaTime * speed;
            this.transform.Rotate(Vector3.forward, -25.0f);
        }
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == 8) {
            this.isWaiting = false;
            BusyStreetLevelController.instance.PickUpGrandma(this.gameObject);
        }
        if(coll.gameObject.layer == 10) {
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.isBeingThrown = false;
            BusyStreetLevelController.instance.GrandmaMadeIt(this.transform.position);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        if(coll.gameObject.layer == 11) {
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.isBeingThrown = false;
            BusyStreetLevelController.instance.GrandmaSquashed();
            //BusyStreetLevelController.instance.ResetGrandma(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void ThrowGrandma() {
        this.isBeingThrown = true;
        this.myRenderer.sprite = grandmaToss;
    }

    private void MoveGrandma() {
        float tempY = this.transform.position.y;
        //tempY -= 1.0f * Time.deltaTime;
        tempY -= BusyStreetLevelController.instance.SpeedAdjustment * Time.deltaTime;

        if (tempY < -21.95f) {
            tempY = 21.95f;
        }

        this.transform.position = new Vector3(this.transform.position.x, tempY, this.transform.position.z);
    }
}
