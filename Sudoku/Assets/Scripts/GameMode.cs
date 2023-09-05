using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    public GameObject cellParent;
    GameObject[] cellObjects;
    Text[] cellTexts = new Text[81];
    public Text NumCorrectTextBox;
    int numToFill = 0;

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
        }

        currentSolution = preset1Solved;

        numToFill = -1;
        foreach (int t in preset1Unsolved)
        {
            if (t == 0)
                numToFill ++;
        }
    }

    public void preset2()
    {
        for (int i = 0; i < cellTexts.Length; i++)
        {
            cellTexts[i].text = preset2Unsolved[i].ToString();
        }
        currentSolution = preset2Solved;

        numToFill = 0;
        foreach (int t in preset1Unsolved)
        {
            if (t == 0)
                numToFill++;
        }
    }

    public void preset3()
    {
        for (int i = 0; i < cellTexts.Length; i++)
        {
            cellTexts[i].text = preset3Unsolved[i].ToString();
        }
        currentSolution = preset3Solved;

        numToFill = 0;
        foreach (int t in preset1Unsolved)
        {
            if (t == 0)
                numToFill++;
        }
    }

    public void solvePuzzle()
    {
        int numFilled = getNumFilled();
        int numCheck = 1;
        int numsPlaced = 0;
        
        while(numCheck <= 9)
        {
            foreach(Text t in cellTexts)
            {
                if(int.Parse(t.text) == 0)
                {
                    if(checkCell(t ,numCheck))
                    {
                        t.text = numCheck.ToString();
                        numsPlaced++;
                    }
                }
            }
            numCheck++;
        }

        //look for the nonette, column, then row with the least amount of 0s
        //if there is only 1, fill it in





        

        //List<Text> current = new List<Text>();

        //foreach(Text t in cellTexts)
        //{
        //    current.Add(t);
        //}
        //for (int x = 0; x < numToFill + 120; x++)
        //{


        //    current = findNext();
        //    List<int> currentInts = new List<int>();
        //    int missing = 0;



        //    int zeros = 0;
        //    foreach (Text t in current)
        //    {
        //        currentInts.Add(int.Parse(t.text));
        //        if (int.Parse(t.text) == 0)
        //        {
        //            zeros++;
        //        }
        //    }

        //    if (zeros == 1)
        //    {
        //        foreach (Text t in current)
        //        {
        //            if (int.Parse(t.text) == 0)
        //            {
        //                t.text = getMissingNumber(currentInts).ToString();
        //            }
        //        }
        //    }



        //    //checking each empty cell if the missing number fits
        //    for (int i = 0; i < current.Count; i++)
        //    {
        //        if (currentInts[i] == 0)
        //        {


        //            if (current[2].transform.position.x == current[1].transform.position.x)
        //            {
        //                //check columns
        //                for (int j = 720; j <= 1200; j += 60)
        //                {
        //                    //find the first missing number in the array
        //                    missing = getMissingNumber(currentInts);

        //                    foreach (Text obj in current)
        //                    {

        //                        //Debug.Log(obj.transform.position);
        //                        if (obj.transform.position.x == j && obj.transform.position.y == current[i].transform.position.y && int.Parse(obj.text) == 0)
        //                        {
        //                            if (checkAvailable(obj, missing))
        //                            {
        //                                obj.text = missing.ToString();
        //                                Debug.Log(obj.text + "a");
        //                                break;
        //                            }

        //                        }

        //                    }
        //                }
        //            }
        //            else if (current[2].transform.position.y == current[1].transform.position.y)
        //            {
        //                //check rows
        //                for (int j = 780; j >= 300; j -= 60)
        //                {
        //                    //find the first missing number in the array
        //                    missing = getMissingNumber(currentInts);

        //                    foreach (Text obj in cellTexts)
        //                    {
        //                        //Debug.Log("Filled2");
        //                        if (obj.transform.position.x == current[i].transform.position.x && obj.transform.position.y == j && int.Parse(obj.text) == 0)
        //                        {

        //                            if (checkAvailable(obj, missing))
        //                            {
        //                                obj.text = missing.ToString();
        //                                Debug.Log(obj.text + "a");
        //                                break;
        //                            }
        //                        }

        //                    }
        //                }
        //            }
        //            else
        //            {
        //                //check nonettes
        //                for (int j = 1; j <= 3; j++)
        //                {
        //                    for (int k = 1; k <= 3; k++)
        //                    {
        //                        //find the first missing number in the array
        //                        missing = getMissingNumber(currentInts);

        //                        foreach (Text obj in cellTexts)
        //                        {
        //                            if (cellTexts[k].transform.position.x / 180 == i && cellTexts[k].transform.position.y / 180 == j)
        //                            {
        //                                if (checkAvailable(obj, missing))
        //                                {
        //                                    obj.text = missing.ToString();
        //                                    Debug.Log(obj.text + "a");
        //                                    break;
        //                                }
        //                            }
        //                        }

        //                    }
        //                }
        //            }
        //        }
        //    }
        //}


        int count = 0;
        for (int i = 0; i < 81; i++)
        {
            if (currentSolution[i] == int.Parse(cellTexts[i].text))
            {
                count++;
            }
        }
        int correct = count - numFilled - 1;
        NumCorrectTextBox.text = "Numbers Correct: " + correct + "\nNumbers Placed: " + numsPlaced;
    }
    
    bool checkCell(Text t, int value)
    {
        List<Text> current = new List<Text>();
        List<Text> toRemove = new List<Text>();
        //check the associated nonette
        foreach (Text obj in cellTexts)
        {
            if (t.transform.position.x / 180 == obj.transform.position.x / 180 && t.transform.position.y / 180 == obj.transform.position.y / 180)
            {
                current.Add(obj);
            }
        }

        foreach (Text obj in current)
        {
            //if the value currently being searched for is already in the nonette, its wrong
            if(int.Parse(obj.text) == value)
            {
                return false;
            }

            if (int.Parse(obj.text) == 0)
            {
                foreach (Text checkText in cellTexts)
                {
                    //checking columns if the value fits
                    if (checkText.transform.position.y == obj.transform.position.y)
                    {
                        if (int.Parse(checkText.text) == value)
                        {
                            toRemove.Add(obj);
                        }
                    }
                    //checking rows if the value fits
                    if (checkText.transform.position.x == obj.transform.position.x)
                    {
                        if (int.Parse(checkText.text) == value)
                        {
                            toRemove.Add(obj);
                        }
                    }
                }
            }
            else
            {
                toRemove.Add(obj);
            }
        }

        foreach(Text obj in toRemove)
        {
            if (current.Contains(obj))
            {
                current.Remove(obj);
            }
        }

        if (current.Count == 1)
            return true;
        else return false;
    }



    bool checkExclusive(List<Text> t, int n)
    {
        int count = 0;
        foreach(Text obj in t)
        {
            if (checkAvailable(obj, n))
            {
                count ++;
            }
        }
        if(count != 1)
        {
            return false;
        }
        return true;
    }

    int getExclusiveIndex(List<Text> t, int n)
    {
        int count = 0;
        foreach (Text obj in t)
        {
            if (checkAvailable(obj, n))
            {
                count++;
            }
        }
        if (count != 1)
        {
            return -1;
        }
        foreach (Text obj in t)
        {
            if(int.Parse(obj.text) == n)
            {
                return t.IndexOf(obj);
            }
        }
        return -1;
    }
    bool checkAvailable(Text obj, int n)
    {
        //checking rows
        foreach(Text t in cellTexts)
        {
            if(t.transform.position.y == obj.transform.position.y)
            {
                if(int.Parse(t.text) == n)
                {
                    return false;
                }
            }
            //checking columns
            if (t.transform.position.x == obj.transform.position.x)
            {
                if (int.Parse(t.text) == n)
                {
                    return false;
                }
            }

            //checking nonettes
            if (t.transform.position.x / 180 == obj.transform.position.x/180 && t.transform.position.y / 180 == obj.transform.position.y / 180)
            {
                if (int.Parse(t.text) == n)
                {
                    return false;
                }
            }
        }

        return true;
    }



    int getMissingNumber(List<int> toCheck)
    {
        for (int i = 1; i <= 9; i++)
        {
            if (!toCheck.Contains(i))
            {
                return i;
            }
        }
        return 0;
    }
    int getNumFilled()
    {
        int numFilled = 0;

        foreach (Text text in cellTexts)
        {
            if (int.Parse(text.text) != 0)
            {
                numFilled++;
            }
        }
        return numFilled;
    }

    List<Text> findNext()
    {
        //Cells start at 720, 780 and end at 1200, 300
        //They both increment by 60
        List<Text> current = new List<Text>();
        int maxOccupied = 0; ;
        int currentOccupied = 0;

        //check nonettes
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                foreach (Text obj in cellTexts)
                {
                    if (obj.transform.position.x / 180 == i && obj.transform.position.y / 180 == j && int.Parse(obj.text) != 0)
                        currentOccupied++;
                }

                if (currentOccupied > maxOccupied && currentOccupied < 9)
                {
                    current.Clear();
                    for (int k = 0; k < cellTexts.Length; k++)
                    {
                        if (cellTexts[k].transform.position.x / 180 == i && cellTexts[k].transform.position.y / 180 == j)
                        {
                            current.Add(cellTexts[k]);
                        }
                    }
                    maxOccupied = currentOccupied;
                }
            }
        }

        //check columns
        for (int i = 720; i <= 1200; i += 60)
        {
            for (int j = 780; j >= 300; j--)
            {
                foreach (Text obj in cellTexts)
                {
                    if (obj.transform.position.x == i && obj.transform.position.y == j && int.Parse(obj.text) != 0)
                        currentOccupied++;
                }
            }
            if (currentOccupied > maxOccupied && currentOccupied < 9)
            {
                current.Clear();

                for (int k = 0; k < cellTexts.Length; k++)
                {
                    if (cellTexts[k].transform.position.x == i)
                    {
                        current.Add(cellTexts[k]);

                    }
                }
                maxOccupied = currentOccupied;
            }
            currentOccupied = 0;
        }


        //check rows
        for (int j = 780; j >= 300; j--)
        {
            for (int i = 720; i <= 1200; i += 60)
            {
                foreach (Text obj in cellTexts)
                {
                    if (obj.transform.position.x == i && obj.transform.position.y == j && int.Parse(obj.text) != 0)
                        currentOccupied++;
                }
            }
            if (currentOccupied > maxOccupied && currentOccupied < 9)
            {
                current.Clear();
                for (int k = 0; k < cellTexts.Length; k++)
                {
                    if (cellTexts[k].transform.position.y == j)
                    {
                        current.Add(cellTexts[k]);
                    }
                }
                maxOccupied = currentOccupied;
            }

            currentOccupied = 0;
        }

       
                return current;
    }
}

