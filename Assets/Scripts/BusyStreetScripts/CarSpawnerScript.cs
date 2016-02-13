using UnityEngine;
using System.Collections;

public class CarSpawnerScript : MonoBehaviour {

    [SerializeField]
    private GameObject carPrefab = null;

    [SerializeField]
    private float laneSpeed = 1.0f;

    private float countDown = 0.0f;
    private float maxCountDown = 500.0f;

	// Use this for initialization
	void Start () {
	    foreach(CarScript car in GetComponentsInChildren<CarScript>()) {
            car.SetSpeed(laneSpeed);
        }
	}
	
	// Update is called once per frame
	void Update () {
        //countDown -= Time.deltaTime;

        //if (countDown < 0) {
        //    countDown = maxCountDown * Random.Range(0.5f, 1.5f);
        //    CarScript newCar = Instantiate(carPrefab, this.transform.position, Quaternion.identity) as Car;
        //    newCar.
        //}
    }
}
