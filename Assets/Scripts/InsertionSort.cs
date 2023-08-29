using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertionSort : MonoBehaviour
{
    public DatasetGenerator datasetGenerator;
    public DatasetVisualizer datasetVisualizer;
    public float delayTime = 0.2f;

    public IEnumerator Sort()
    {
        int[] dataset = datasetGenerator.dataset;

        for (int i = 1; i < dataset.Length; i++)
        {
            int key = dataset[i];
            int j = i - 1;

            while (j >= 0 && dataset[j] > key)
            {
                dataset[j + 1] = dataset[j];
                j = j - 1;

                // Update UI
                yield return StartCoroutine(datasetVisualizer.SwapNumbers(j + 1, j + 2));
                yield return new WaitForSeconds(delayTime);
            }

            dataset[j + 1] = key;
        }
    }
}
