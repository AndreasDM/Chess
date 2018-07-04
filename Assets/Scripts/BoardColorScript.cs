using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoardColorScript : MonoBehaviour
{
    public List<GameObject> squares = new List<GameObject>();
    
    void Start()
    {
        AddSquaresToList();
        AddImageComponent();
        GenerateSquareColor();
    }

    void Update()
    {
        
    }

    private void AddImageComponent()
    {
        foreach (GameObject square in squares)
        {
            square.AddComponent<Image>();
        }
    }

    private void AddSquaresToList()
    {
        // loop through 1 - 8
        for (int j = 1; j < 9; ++j)
        {
            char c = 'a';
            // Loop through a - h
            for (int i = 0; i < 8; ++i)
            {
                // ex. a1, b2 etc
                string squareName = c.ToString() + j.ToString();

                // add the object to list
                squares.Add(GameObject.Find(squareName));
                c += (char)1;
            }
        }
    }

    private void GenerateSquareColor()
    {
        bool flipColors = false;
        // these numbers represent the square index on which we should 
        // flip the applied color.
        List<int> triggerNumbers = new List<int> { 8, 16, 24, 32, 40, 48, 56, 64 };
        
        for (int i = 0; i != squares.Count; ++i)
        {
            // We need to be able to flip the colors
            // on each row, this means that after coloring h1 with a light color,
            // the next square 'a2' needs to also be white, so we 'flip' coloring.
            if (triggerNumbers.Contains(i))
                flipColors = !flipColors;

            if (flipColors)
            {
                if (i % 2 == 0)
                    ApplyLightColor(i); 
                else
                    ApplyDarkColor(i);
            }
            else
            {
                if (i % 2 == 0)
                    ApplyDarkColor(i);
                else
                    ApplyLightColor(i);
            }
        }
    }

    private void ApplyLightColor(int index)
    {
        squares[index].GetComponent<Image>().color = new Color32(240, 217, 181, 255);
        
    }

    private void ApplyDarkColor(int index)
    {
        squares[index].GetComponent<Image>().color = new Color32(181, 136, 99, 255);
    }
}