using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    public DatasetGenerator datasetGenerator;
    public DatasetVisualizer datasetVisualizer;
    public float delayTime = 0.2f;

    public IEnumerator Sort()
    {
        int[] dataset = datasetGenerator.dataset;

        for (int i = 0; i < dataset.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < dataset.Length; j++)
            {
                if (dataset[j] < dataset[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                int temp = dataset[i];
                dataset[i] = dataset[minIndex];
                dataset[minIndex] = temp;

                // Update UI
                yield return StartCoroutine(datasetVisualizer.SwapNumbers(i, minIndex));
                yield return new WaitForSeconds(delayTime);
            }
        }
    }
}
