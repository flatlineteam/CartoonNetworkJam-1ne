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
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isBeingThrown == true) {
            this.transform.position += Vector3.right * Time.deltaTime * speed;
            //this.transform.rotation += Vector2.right * speed * Time.deltaTime;
            this.transform.Rotate(Vector3.forward, -25.0f);
        }
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == 8) {
            BusyStreetLevelController.instance.PickUpGrandma(this.gameObject);
        }
        if(coll.gameObject.layer == 10) {
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; //RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezeAll;
            this.isBeingThrown = false;
            BusyStreetLevelController.instance.GrandmaMadeIt(this.transform.position);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        if(coll.gameObject.layer == 11) {
            Debug.Log("Grandma Squashed!!");
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; //RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezeAll;
            this.isBeingThrown = false;
            BusyStreetLevelController.instance.GrandmaSquashed();
            BusyStreetLevelController.instance.ResetGrandma(this.gameObject);
            //BusyStreetLevelController.instance.Gran
            //this.gameObject.SetActive(false);
        }
    }

    public void ThrowGrandma() {
        this.isBeingThrown = true;
        this.myRenderer.sprite = grandmaToss;
    }
}
