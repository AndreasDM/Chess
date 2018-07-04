using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PieceGrab : MonoBehaviour, IDragHandler, IEndDragHandler {

    private GameObject[] squares;
    private GameObject piece;
    private Vector3 diff;
    private bool isDrag;
    private Color32 lastColor;
    private Transform canvasTransform;

    public void OnDrag(PointerEventData eventData)
    {   
        if (isDrag == false)
        {
            gameObject.transform.SetParent(null);
            gameObject.transform.SetParent(canvasTransform);

            isDrag = true;
        }

        /*
        if (isDrag == false)
        {
            string sqr = "";
            foreach (GameObject square in squares)
            {
                if (gameObject.transform.position.Equals(square.transform.position))
                {
                    sqr = square.name;

                    char letter = sqr.Substring(0, 1).ToCharArray()[0];
                    char number = sqr.Substring(1, 1).ToCharArray()[0];

                    string forward = letter.ToString() + ((char)(number + 1)).ToString();
                    print(forward);

                    piece = GameObject.Find(forward);
                    if (piece != null)
                    {
                        lastColor = piece.GetComponent<Image>().color;
                        piece.GetComponent<Image>().color = new Color32(lastColor.r, lastColor.g, lastColor.b, 100);
                    }
                    break;
                }
            }



            isDrag = true;
            
        }
        */
        // set new position + differnece
        gameObject.GetComponent<RectTransform>().transform.SetPositionAndRotation(new Vector3(Input.mousePosition.x + diff.x, Input.mousePosition.y + diff.y, 0), new Quaternion());
        
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (HoverController.lastHoveredSquare != null)
        {
            gameObject.transform.SetPositionAndRotation(HoverController.lastHoveredSquare.position, new Quaternion());
        }

        /*
        // reset highlight color
        if (piece != null)
            piece.GetComponentInChildren<Image>().color = lastColor;

        
        isDrag = false;
        */

        isDrag = false;
    }

    // Use this for initialization
    void Start () {
        diff = Vector3.zero;
        isDrag = false;
        //squares = GameObject.FindGameObjectsWithTag("square");
        canvasTransform = GameObject.Find("Canvas").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            /*
            diff.x = gameObject.GetComponent<RectTransform>().position.x - Input.mousePosition.x;
            diff.y = gameObject.GetComponent<RectTransform>().position.y - Input.mousePosition.y;
            */
            diff = gameObject.GetComponent<RectTransform>().position - Input.mousePosition;
        }
	}
}
