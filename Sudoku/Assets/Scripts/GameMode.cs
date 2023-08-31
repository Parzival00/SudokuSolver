using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    public GameObject cellParent;
    GameObject[] cells;


    private void Start()
    {
        cells = GameObject.FindGameObjectsWithTag("Cell");


    }
}

