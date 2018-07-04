using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddColliders : MonoBehaviour {

    private GameObject[] squares;

	// Use this for initialization
	void Start () {
        squares = GameObject.FindGameObjectsWithTag("square");
        foreach (GameObject square in squares)
        {
            square.AddComponent<BoxCollider2D>();
            square.GetComponent<BoxCollider2D>().size = new Vector2(100, 100);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
