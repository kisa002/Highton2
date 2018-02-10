using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphRenderer : MonoBehaviour
{
    public int minPrice, maxPrice; // Y
    public int minDate, maxDate; // X

    public Vector2 startPos, rangePos; // VECTOR 

    public List<Transform> nodeList;
    public List<int> priceList;

    LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        SetMinMaxPrice();
        InitGraph();
    }

    void InitGraph()
    {
        lineRenderer.positionCount = priceList.Count;
        for (int i = 0; i < priceList.Count; ++i)
        {
            float perNodeX = rangePos.x / priceList.Count;
            float perNodeY = rangePos.y / maxPrice / priceList.Count;

            print("PerNode x  = " + perNodeX + " | " + "PerNode y  = " + perNodeY);
            if (i > nodeList.Count - 1)
            {
                nodeList.Add(Instantiate(new GameObject("Graph Node" + i), this.transform).transform);
            }

            nodeList[i].position = new Vector3(transform.position.x + startPos.x + i * perNodeX, transform.position.y + startPos.y + priceList[i] * perNodeY * 10, 0);
            lineRenderer.SetPosition(i, nodeList[i].position);
        }
    }

    void SetMinMaxPrice()
    {
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
