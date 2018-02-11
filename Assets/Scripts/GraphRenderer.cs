using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphRenderer : MonoBehaviour
{
    public int minPrice, maxPrice; // Y
    public int minDate, maxDate; // X

    public Vector2 startPos = new Vector2(0.25f, 0.3f), rangePos = new Vector2(5.7f, 2); // VECTOR 

    public GameObject coinPrefab;

    public List<Transform> nodeList;
    public List<int> priceList;

    LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        ChangeChart();
    }

    private void Update()
    {
        ChangeChart();
    }

    void InitGraph()
    {
        if (priceList.Count < 2)
            return;

        lineRenderer.positionCount = priceList.Count;
        for (int i = 0; i < priceList.Count; ++i)
        {
            float perNodeX = (rangePos.x - startPos.x) / (priceList.Count - 1);
            float perNodeY = (rangePos.y - startPos.y) / (maxPrice - minPrice);

//            print(perNodeX + " / " + perNodeY);

            if (i > nodeList.Count - 1)
            {
                GameObject g = Instantiate(coinPrefab, transform);
                g.name = "Graph Node" + i;
                nodeList.Add(g.transform);
            }

            nodeList[i].position = new Vector3(transform.position.x + startPos.x + i * perNodeX, transform.position.y + startPos.y + (priceList[i] - minPrice) * perNodeY, -10);
            nodeList[i].GetComponent<UICoinHover>().price = priceList[i];
            lineRenderer.SetPosition(i, nodeList[i].position);
        }
    }

    void SetMinMaxPrice()
    {
        if (priceList.Count < 2)
            return;

        List<int> list = new List<int>(priceList);
        list.Sort();
        minPrice = list[0];
        maxPrice = list[list.Count - 1];

    }

    public void ChangeChart()
    {
        SetMinMaxPrice();
        InitGraph();
    }

}
