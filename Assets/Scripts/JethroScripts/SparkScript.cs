using UnityEngine;
using System.Collections;

public class SparkScript : MonoBehaviour {

    // Use this for initialization
    void Start() {
        StartCoroutine(DeleteAfterDelay());
    }

    // Update is called once per frame
    //void Update() {

    //}

    IEnumerator DeleteAfterDelay() {
        yield return new WaitForSeconds(0.75f);
        DeleteMe();
    }

    private void DeleteMe() {
        Destroy(this.gameObject);
    }
}
