using UnityEngine;
using System.Collections;

public class GrandmaScript : MonoBehaviour {

    private bool isBeingThrown = false;

    private float speed = 11.5f;

    [SerializeField]
    private Sprite grandmaIdle = null, grandmaToss = null;

    [SerializeField]
    private SpriteRenderer myRenderer = null;

	// Use this for initialization
	//void Start () {
	
	//}
	
	// Update is called once per frame
	void Update () {
        if (isBeingThrown == true) {
            this.transform.position += Vector3.right * Time.deltaTime * speed;
            this.transform.Rotate(Vector3.forward, -25.0f);
        }
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == 8) {
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
            BusyStreetLevelController.instance.ResetGrandma(this.gameObject);
        }
    }

    public void ThrowGrandma() {
        this.isBeingThrown = true;
        this.myRenderer.sprite = grandmaToss;
    }
}
