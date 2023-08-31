using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    public GameObject cellParent;
    GameObject[] cellObjects;
    Text[] cellTexts = new Text[81];

    int[] currentSolution = new int[81];

    //lord forgive me
    int[] preset1Unsolved = {
            0, 6, 3, 0, 0, 0, 1, 0, 7,
            4, 0, 0, 0, 0, 0, 0, 5, 8,
            5, 7, 0, 0, 9, 0, 0, 0, 4,
            0, 8, 0, 1, 3, 0, 0, 4, 0,
            0, 9, 0, 0, 6, 0, 0, 0, 0,
            0, 0, 1, 0, 0, 0, 6, 0, 0,
            0, 0, 0, 3, 1, 0, 0, 0, 0,
            0, 5, 0, 0, 0, 9, 0, 0, 6,
            0, 0, 0, 0, 0, 0, 9, 0, 5};

    int[] preset1Solved = {
            2, 6, 3, 5, 4, 8, 1, 9, 7,
            4, 1, 9, 6, 7, 3, 2, 5, 8,
            5, 7, 8, 2, 9, 1, 3, 6, 4,
            6, 8, 5, 1, 3, 2, 7, 4, 9,
            3, 9, 4, 8, 6, 7, 5, 2, 1,
            7, 2, 1, 9, 5, 4, 6, 8, 3,
            9, 4, 6, 3, 1, 5, 8, 7, 2,
            1, 5, 2, 7, 8, 9, 4, 1, 6,
            8, 3, 7, 4, 2, 6, 9, 0, 5};

    int[] preset2Unsolved = {
            0, 0, 0, 0, 0, 0, 6, 0, 0,
            0, 1, 9, 0, 0, 2, 0, 0, 0,
            0, 0, 4, 0, 0, 0, 8, 0, 5,
            0, 0, 0, 3, 0, 0, 5, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 6, 3,
            0, 0, 0, 0, 0, 8, 1, 0, 2,
            6, 8, 0, 0, 4, 9, 0, 3, 0,
            9, 0, 0, 0, 8, 0, 0, 0, 0,
            0, 2, 0, 0, 6, 5, 0, 1, 0};

    int[] preset2Solved = {
            2, 5, 7, 8, 3, 4, 6, 9, 1,
            8, 1, 9, 6, 5, 2, 3, 7, 4,
            3, 6, 4, 9, 1, 7, 8, 2, 5,
            1, 4, 2, 3, 7, 6, 5, 8, 9,
            5, 9, 8, 4, 2, 1, 7, 6, 3,
            7, 3, 6, 5, 9, 8, 1, 5, 2,
            6, 8, 5, 1, 4, 9, 2, 3, 7,
            9, 7, 1, 2, 8, 3, 4, 5, 6,
            4, 2, 3, 7, 6, 5, 9, 1, 8};

    int[] preset3Unsolved = {
            0, 0, 0, 0, 8, 3, 0, 0, 0,
            0, 5, 8, 7, 1, 0, 0, 0, 2,
            0, 9, 0, 2, 0, 6, 0, 0, 0,
            3, 7, 0, 0, 0, 0, 8, 0, 6,
            0, 0, 0, 0, 0, 1, 0, 0, 3,
            0, 0, 2, 0, 0, 0, 0, 0, 1,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 8, 0, 0, 7, 0, 0,
            0, 8, 7, 5, 0, 0, 9, 0, 0};

    int[] preset3Solved = {
            7, 2, 6, 4, 8, 3, 1, 5, 9,
            4, 5, 8, 7, 1, 9, 3, 6, 2,
            1, 9, 3, 2, 5, 6, 4, 8, 7,
            3, 7, 1, 9, 2, 5, 8, 4, 6,
            8, 4, 5, 6, 7, 1, 2, 9, 3,
            9, 6, 2, 3, 4, 8, 5, 7, 1,
            5, 3, 4, 1, 9, 7, 6, 2, 8,
            2, 1, 9, 8, 6, 4, 7, 3, 5,
            6, 8, 7, 5, 3, 2, 9, 1, 4};
    private void Start()
    {
        cellObjects = GameObject.FindGameObjectsWithTag("Cell");
        
        for (int i = 0; i < cellObjects.Length; i++)
        {
            cellTexts[i] = cellObjects[i].GetComponent<Text>();
;
        }
    }

    private void Update()
    {
        foreach(Text text in cellTexts)
        {
            if(int.Parse(text.text) == 0)
            {
                text.color = Color.white;
            }
            else
            {
                text.color = Color.black;
            }
        }
    }

    public void preset1()
    {
        for (int i =0; i < cellTexts.Length; i++)
        {
            cellTexts[i].text = preset1Unsolved[i].ToString();
            Debug.Log(cellTexts[i].text);
        }

        currentSolution = preset1Solved;
    }

    public void preset2()
    {
        for (int i = 0; i < cellTexts.Length; i++)
        {
            cellTexts[i].text = preset2Unsolved[i].ToString();
            Debug.Log(cellTexts[i].text);
        }
        currentSolution = preset2Solved;
    }

    public void preset3()
    {
        for (int i = 0; i < cellTexts.Length; i++)
        {
            cellTexts[i].text = preset3Unsolved[i].ToString();
            Debug.Log(cellTexts[i].text);
        }
        currentSolution = preset3Solved;
    }
}

