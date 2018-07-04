using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverController : MonoBehaviour {

    public static RectTransform lastHoveredSquare;

	// Use this for initialization
	void Start () {
        lastHoveredSquare = null;
	}
	   
    // Update is called once per frame
	void Update () {
        float dirx = Input.GetAxis("Mouse X");
        float diry = Input.GetAxis("Mouse Y");
        transform.Rotate(diry, -dirx, 0);

        checkForHit();
	}
    
    void checkForHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, transform.position);
        if (hit.collider != null && hit.collider.tag == "square")
        {
            //print("hit: " + hit.collider.name);
            //GameObject square = GameObject.Find(hit.collider.gameObject.name);
            //set position
            lastHoveredSquare = hit.collider.GetComponent<RectTransform>();
        }
        
    }
}
