using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    public DatasetGenerator datasetGenerator;
    public DatasetVisualizer datasetVisualizer;
    public float delayTime = 0.2f;

    public IEnumerator Sort()
    {
        int[] dataset = datasetGenerator.dataset;

        for (int i = 0; i < dataset.Length; i++)
        {
            for (int j = 0; j < dataset.Length - i - 1; j++)
            {
                if (dataset[j] > dataset[j + 1])
                {
                    int temp = dataset[j];
                    dataset[j] = dataset[j + 1];
                    dataset[j + 1] = temp;

                // Update UI
                yield return StartCoroutine(datasetVisualizer.SwapNumbers(j, j + 1));
                yield return new WaitForSeconds(delayTime);
                }
            }
        }
    }
}
