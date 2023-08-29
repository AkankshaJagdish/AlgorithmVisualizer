using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public BubbleSort bubbleSort;
    public InsertionSort insertionSort;
    public SelectionSort selectionSort;

    public void StartBubbleSort()
    {
        StartCoroutine(bubbleSort.Sort());
    }

    public void StartInsertionSort()
    {
        StartCoroutine(insertionSort.Sort());
    }

    public void StartSelectionSort()
    {
        StartCoroutine(selectionSort.Sort());
    }
}
