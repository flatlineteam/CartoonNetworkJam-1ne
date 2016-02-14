﻿using UnityEngine;
using System.Collections;

public class SparkScript : MonoBehaviour {

    // Use this for initialization
    void Start() {
        StartCoroutine(DeleteAfterDelay());
    }

    // Update is called once per frame
    void Update() {
        //Vector3 newPos = this.transform.position;
        //newPos.y += Time.deltaTime;
        //newPos.x = this.GetComponentInParent<Transform>().position.x;
        //this.transform.position = newPos;
    }

    IEnumerator DeleteAfterDelay() {
        yield return new WaitForSeconds(1.5f);
        DeleteMe();
    }

    private void DeleteMe() {
        Destroy(this.gameObject);
    }
}
