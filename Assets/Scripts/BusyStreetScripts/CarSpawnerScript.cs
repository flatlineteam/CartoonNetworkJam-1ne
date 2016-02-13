using UnityEngine;
using System.Collections;

public class CarSpawnerScript : MonoBehaviour {

    [SerializeField]
    private GameObject carPrefab = null;

    private float countDown = 0.0f;
    private float maxCountDown = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        countDown -= Time.deltaTime;

        if(countDown < 0) {
            countDown = maxCountDown;
            Instantiate(carPrefab, this.transform.position, Quaternion.identity);
        }
	}
}
