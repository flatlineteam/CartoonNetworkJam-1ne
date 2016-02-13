using UnityEngine;
using System.Collections;

public class RhythmButtonSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject buttonPrefab = null;

    [SerializeField]
    private CircleCollider2D target = null;

    private float maxCountDown = 5.0f;
    private float countDown = 0.0f;

	// Use this for initialization
	void Start () {
        Vector3 newPos = new Vector3(this.transform.position.x,
                                     target.transform.position.y,
                                     0.0f);

        this.transform.position = newPos;
	}
	
	// Update is called once per frame
	void Update () {
        countDown -= Time.deltaTime;
        if (countDown < 0.0f) {
            countDown = maxCountDown * Random.Range(0.75f, 1.25f);
            GameObject newGuiBUtton = (GameObject)Instantiate(buttonPrefab, this.transform.position, Quaternion.identity);
            newGuiBUtton.SendMessage("SetTarget", target);
        }
	}
}
