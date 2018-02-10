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

    public int currentFloor;

    public List<BuildingType> buildingTypeList = new List<BuildingType>();
    public float floorHeight = 330f;

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

			buildingTypeList.Add(buildingType);

			GameObject floorObj = Instantiate(floor, building.transform);
			floorObj.transform.Translate(new Vector2(0, buildingTypeList.Count * floorHeight));
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

    void Update()
    {
        MoveBuilding();
    }

    void MoveBuilding()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            transform.Translate(0, -touchDeltaPosition.y * 0.1f, 0);
            transform.position = new Vector2(0, Mathf.Clamp(transform.position.y, 0, buildingTypeList.Count * floorHeight));
        }
    }

    public void MakeFloor()
    {
        int floorSpriteType = Random.Range(0, 3);
        GameObject floorObj = Instantiate(floor, building.transform);
        floorObj.transform.Translate(new Vector2(0, buildingTypeList.Count * floorHeight));
        floorObj.GetComponent<SpriteRenderer>().sprite = floorSprite[floorSpriteType];
        buildingTypeList.Add((BuildingType)floorSpriteType);
        currentFloor = buildingTypeList.Count;

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
