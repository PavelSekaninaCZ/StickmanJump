using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rnColor : MonoBehaviour {
    Color mycolor = Color.blue;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
