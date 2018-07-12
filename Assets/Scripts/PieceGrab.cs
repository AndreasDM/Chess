using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class PieceGrab : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    //private GameObject[] squares;
    private List<GameObject> whitePieces;
    private List<GameObject> blackPieces;
    private List<GameObject> allPieces;
    private Vector3 diff = Vector3.zero;
    private bool isDrag = false;
    private Color32 lastColor;
    private Transform canvasTransform;
    private Vector3 beforeSquare;

    public void OnBeginDrag(PointerEventData eventData)
    {
        diff = gameObject.GetComponent<RectTransform>().position - Input.mousePosition;
        beforeSquare = HoverController.lastHoveredSquare.position;
    }

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
            // before placing the piece
            // check if there is a piece at that square
            // 1. loop through squares
            // 2. if piece at same position as square
            // 3. determine if piece is white or black
            // 4. if piece is same color as gameObject
            //      do nothing
            //    else
            //      find piece at the same position as square and destroy it

            string squareName = HoverController.lastHoveredSquare.name;
            GameObject square = GameObject.Find(squareName);
            bool found = false;
            bool busySquare = false;
            
            foreach (GameObject piece in allPieces)
            {
                if (piece != null && piece.transform.position.Equals(square.transform.position))
                {
                    print("same position");
                    if (!gameObject.tag.Equals(piece.tag))
                    {
                        // different color piece
                        // destroy piece
                        Destroy(piece);

                        // remove from list
                        allPieces.Remove(piece);
                        
                        // object found
                        //found = true;

                        // break out of loop
                        break;
                    }
                    else // square is occupied by same colored piece
                    {
                        busySquare = true;
                    }
                }
            }

            if (!busySquare)
            {
                gameObject.transform.SetPositionAndRotation(HoverController.lastHoveredSquare.position, Quaternion.identity);
            }
            else
            {
                gameObject.transform.SetPositionAndRotation(beforeSquare, Quaternion.identity);
            }
        }
        else
        {
            gameObject.transform.SetPositionAndRotation(beforeSquare, Quaternion.identity);
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
        //squares = GameObject.FindGameObjectsWithTag("square");
        

        canvasTransform = GameObject.Find("Canvas").transform;

        GameObject[] arrw = GameObject.FindGameObjectsWithTag("white");
        GameObject[] arrb = GameObject.FindGameObjectsWithTag("black");
        whitePieces = arrw.ToList<GameObject>();
        blackPieces = arrb.ToList<GameObject>();
        allPieces = whitePieces;
        allPieces.AddRange(blackPieces);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            /*
            diff.x = gameObject.GetComponent<RectTransform>().position.x - Input.mousePosition.x;
            diff.y = gameObject.GetComponent<RectTransform>().position.y - Input.mousePosition.y;
            */
            /*diff = gameObject.GetComponent<RectTransform>().position - Input.mousePosition;
            beforeSquare = HoverController.lastHoveredSquare.position;
            */
        }
	}
}
