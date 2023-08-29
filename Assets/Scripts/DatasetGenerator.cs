using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasetGenerator : MonoBehaviour
{
    public int arraySize = 12;
    public int minValue = 1;
    public int maxValue = 90; // Change the maxValue to 50
    public int[] dataset;
    public DatasetVisualizer datasetVisualizer;

    public void GenerateDataset()
    {
        dataset = new int[arraySize];
        for (int i = 0; i < arraySize; i++)
        {
            dataset[i] = Random.Range(minValue, maxValue + 1); // Add 1 to maxValue to make it inclusive
        }

        datasetVisualizer.UpdateVisualization();
    }
}
