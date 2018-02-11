using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private static BuildingManager _instance;

    public static BuildingManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public GameObject building;
    public GameObject floor;
    public Sprite[] floorSprite = new Sprite[3];
    public GameObject[] clouds = new GameObject[3];

    public int currentFloor;

    public List<BuildingType> buildingTypeList = new List<BuildingType>();
    public float floorHeight = 330f;

    public List<Cloud> cloudList = new List<Cloud>();

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void StringToBuildingType(string data)
    {
        buildingTypeList.Clear();
        string[] buildingTypeData = data.Split('|');
        for (int i = 0; i < buildingTypeData.Length - 1; i++)
        {
            BuildingType buildingType = (BuildingType)int.Parse(buildingTypeData[i]);

            GameObject floorObj = Instantiate(floor, building.transform);
            floorObj.transform.Translate(new Vector2(0, -600 + buildingTypeList.Count * floorHeight));

            buildingTypeList.Add(buildingType);

            floorObj.GetComponent<SpriteRenderer>().sprite = floorSprite[(int)buildingType];
            currentFloor = buildingTypeList.Count;
        }
    }

    public string BuildingTypeToString()
    {
        string data = "";

        for (int i = 0; i < buildingTypeList.Count; i++)
            data += ((int)buildingTypeList[i]).ToString() + "|";

        return data;
    }

    void Start()
    {
        StringToBuildingType(PlayDataManager.Instance.GetBuild());
        StartCoroutine(MakeCloud());
    }

    void Update()
    {
        MoveBuilding();
    }

    void MoveBuilding()
    {
        Vector3 buildingPos = building.transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            building.transform.Translate(0, -1000 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            building.transform.Translate(0, 1000 * Time.deltaTime, 0);
        }
        if (buildingTypeList.Count * floorHeight > 800)
            building.transform.position = new Vector2(0, Mathf.Clamp(building.transform.position.y, -buildingTypeList.Count * floorHeight + 800, 0));
        else
            building.transform.position = new Vector2(0, 0);

        for (int i = 0; i < cloudList.Count; i++)
            cloudList[i].transform.Translate(building.transform.position - buildingPos);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            if (buildingTypeList.Count * floorHeight > 800)
            {
                building.transform.Translate(0, touchDeltaPosition.y * 5, 0);
                building.transform.position = new Vector2(0, Mathf.Clamp(building.transform.position.y, -buildingTypeList.Count * floorHeight + 800, 0));
            }
            else
                building.transform.position = new Vector2(0, 0);

            for (int i = 0; i < cloudList.Count; i++)
                cloudList[i].transform.Translate(building.transform.position - buildingPos);
        }
    }

    IEnumerator MakeCloud()
    {
        while (true)
        {
            GameObject cloud = Instantiate(clouds[Random.Range(0, 3)], building.transform);
            cloud.transform.position = new Vector2(950, Random.Range(300, 3500));
            cloudList.Add(cloud.GetComponent<Cloud>());

            yield return new WaitForSeconds(Random.Range(2.5f, 5.0f));
        }
    }

    public void MakeFloor()
    {
        int floorSpriteType = Random.Range(0, 3);
        GameObject floorObj = Instantiate(floor, building.transform);
        floorObj.transform.Translate(new Vector2(0, -600 + buildingTypeList.Count * floorHeight));
        floorObj.GetComponent<SpriteRenderer>().sprite = floorSprite[floorSpriteType];
        buildingTypeList.Add((BuildingType)floorSpriteType);
        currentFloor = buildingTypeList.Count;

        PlayDataManager.Instance.SaveBuild(BuildingTypeToString());
        UIInGame.Instance.buildingUpgrade.UpdateFloor();
    }
}

[System.Serializable]
public enum BuildingType
{
    White,
    Blue,
    Yellow
}