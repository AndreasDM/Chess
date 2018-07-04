using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionPieces : MonoBehaviour {

    public GameObject whitePawn;
    public GameObject blackPawn;
    public GameObject blackRook;
    public GameObject blackBishop;
    public GameObject blackKnight;
    public GameObject blackQueen;
    public GameObject blackKing;

    private Transform CanvasTransform;

	void Start () {
        CanvasTransform = GameObject.Find("Canvas").transform;

        GameObject king = GameObject.Find("whiteKing");
        GameObject square = GameObject.Find("e1");
        Vector3 squarepos = square.transform.position;
        king.transform.SetPositionAndRotation(new Vector3(squarepos.x, squarepos.y, 0), new Quaternion(0, 0, 0, 0));

        GameObject knight = GameObject.Find("wknight");
        square = GameObject.Find("g1");
        squarepos = square.transform.position;
        knight.transform.SetPositionAndRotation(squarepos, new Quaternion());

        knight = GameObject.Find("wknight2");
        square = GameObject.Find("b1");
        squarepos = square.transform.position;
        knight.transform.SetPositionAndRotation(squarepos, new Quaternion());

        GameObject bishop = GameObject.Find("wbishop");
        square = GameObject.Find("c1");
        squarepos = square.transform.position;
        bishop.transform.SetPositionAndRotation(squarepos, new Quaternion());
        bishop.AddComponent<PieceGrab>();

        bishop = GameObject.Find("wbishop2");
        square = GameObject.Find("f1");
        squarepos = square.transform.position;
        bishop.transform.SetPositionAndRotation(squarepos, new Quaternion());
        bishop.AddComponent<PieceGrab>();

        GameObject rook = GameObject.Find("wrook");
        square = GameObject.Find("a1");
        squarepos = square.transform.position;
        rook.transform.SetPositionAndRotation(squarepos, new Quaternion());
        rook.AddComponent<PieceGrab>();

        rook = GameObject.Find("wrook2");
        square = GameObject.Find("h1");
        squarepos = square.transform.position;
        rook.transform.SetPositionAndRotation(squarepos, new Quaternion());
        rook.AddComponent<PieceGrab>();

        GameObject queen = GameObject.Find("wqueen");
        square = GameObject.Find("d1");
        squarepos = square.transform.position;
        queen.transform.SetPositionAndRotation(squarepos, new Quaternion());
        queen.AddComponent<PieceGrab>();

        // White pawns
        char startChar = 'a';
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < 8; ++i)
        {
            pos = GameObject.Find(startChar.ToString() + "2").transform.position;
            GameObject p = Instantiate(whitePawn, pos, Quaternion.identity);
            p.transform.SetParent(CanvasTransform);
            p.transform.SetPositionAndRotation(pos, Quaternion.identity);
            p.AddComponent<PieceGrab>();
            ++startChar;
        }

        // Black pawns
        startChar = 'a';
        for (int i = 0; i < 8; ++i)
        {
            pos = GameObject.Find(startChar.ToString() + "7").transform.position;
            GameObject p = Instantiate(blackPawn, pos, Quaternion.identity);
            p.transform.SetParent(CanvasTransform);
            p.transform.SetPositionAndRotation(pos, Quaternion.identity);
            p.AddComponent<PieceGrab>();
            ++startChar;
        }

        // black rooks
        rook = Instantiate(blackRook, pos, Quaternion.identity);
        rook.transform.SetParent(CanvasTransform);
        pos = GameObject.Find("a8").transform.position;
        rook.transform.SetPositionAndRotation(pos, Quaternion.identity);
        rook.AddComponent<PieceGrab>();

        rook = Instantiate(blackRook, pos, Quaternion.identity);
        rook.transform.SetParent(CanvasTransform);
        pos = GameObject.Find("h8").transform.position;
        rook.transform.SetPositionAndRotation(pos, Quaternion.identity);
        rook.AddComponent<PieceGrab>();

        // black bishops
        bishop = Instantiate(blackBishop, pos, Quaternion.identity);
        bishop.transform.SetParent(CanvasTransform);
        pos = GameObject.Find("c8").transform.position;
        bishop.transform.SetPositionAndRotation(pos, Quaternion.identity);
        bishop.AddComponent<PieceGrab>();

        bishop = Instantiate(blackBishop);
        bishop.transform.SetParent(CanvasTransform);
        pos = GameObject.Find("f8").transform.position;
        bishop.transform.SetPositionAndRotation(pos, Quaternion.identity);
        bishop.AddComponent<PieceGrab>();

        // black knights
        knight = Instantiate(blackKnight);
        knight.transform.SetParent(CanvasTransform);
        pos = GameObject.Find("b8").transform.position;
        knight.transform.SetPositionAndRotation(pos, Quaternion.identity);
        knight.AddComponent<PieceGrab>();

        knight = Instantiate(blackKnight);
        knight.transform.SetParent(CanvasTransform);
        pos = GameObject.Find("g8").transform.position;
        knight.transform.SetPositionAndRotation(pos, Quaternion.identity);
        knight.AddComponent<PieceGrab>();

        // black queen
        queen = Instantiate(blackQueen);
        queen.transform.SetParent(CanvasTransform);
        pos = GameObject.Find("d8").transform.position;
        queen.transform.SetPositionAndRotation(pos, Quaternion.identity);
        queen.AddComponent<PieceGrab>();

        // black king
        king = Instantiate(blackKing);
        king.transform.SetParent(CanvasTransform);
        pos = GameObject.Find("e8").transform.position;
        king.transform.SetPositionAndRotation(pos, Quaternion.identity);
        king.AddComponent<PieceGrab>();
    }
	
	void Update () {
		
	}
}
