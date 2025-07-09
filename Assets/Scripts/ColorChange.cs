using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColorChange : MonoBehaviour
{
    public List<Color> possibleColors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AssignColorsToTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void AssignColorsToTiles() {
        int childCount = transform.childCount;


        for (int i = 0; i < childCount; i++)
        {
             Transform tile = transform.GetChild(i);

            Color randomColor = possibleColors[Random.Range(0, possibleColors.Count)];
    Renderer renderer = tile.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = randomColor;
            }
        }

    
    }
    
}
