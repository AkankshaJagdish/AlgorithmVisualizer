using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatasetVisualizer : MonoBehaviour
{
    public DatasetGenerator datasetGenerator;
    public GameObject textPrefab;
    public float moveDuration = 0.5f;
    private GameObject[] numbers;

    public void UpdateVisualization()
    {
        // Clear old visualization
        if (numbers != null)
        {
            foreach (GameObject number in numbers)
            {
                Destroy(number);
            }
        }

        // Create new visualization
        numbers = new GameObject[datasetGenerator.dataset.Length];
        for (int i = 0; i < datasetGenerator.dataset.Length; i++)
        {
            numbers[i] = Instantiate(textPrefab, transform);
            numbers[i].GetComponent<Text>().text = datasetGenerator.dataset[i].ToString();
            numbers[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(20 * i, 0);
        }
    }

    public IEnumerator SwapNumbers(int index1, int index2)
    {
        Vector2 startPos1 = numbers[index1].GetComponent<RectTransform>().anchoredPosition;
        Vector2 startPos2 = numbers[index2].GetComponent<RectTransform>().anchoredPosition;

        float startTime = Time.time;
        while (Time.time < startTime + moveDuration)
        {
            float t = (Time.time - startTime) / moveDuration;

            numbers[index1].GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(startPos1, startPos2, t);
            numbers[index2].GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(startPos2, startPos1, t);

            yield return null;
        }

        numbers[index1].GetComponent<RectTransform>().anchoredPosition = startPos2;
        numbers[index2].GetComponent<RectTransform>().anchoredPosition = startPos1;

        GameObject temp = numbers[index1];
        numbers[index1] = numbers[index2];
        numbers[index2] = temp;
    }
}
