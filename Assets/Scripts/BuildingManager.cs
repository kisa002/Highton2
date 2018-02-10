using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {
	enum BuildingType
	{
		White,
		Blue,
		Yellow
	}

	List<BuildingType> buildingTypeList = new List<BuildingType>();

	public GameObject building;
	public GameObject floor;
	public Sprite[] floorSprite = new Sprite[3];

	public float floorHeight = 2.2f;

	public void StringToBuildingType(string data)
	{
		buildingTypeList.Clear ();
		string[] buildingTypeData = data.Split ('|');
		for (int i = 0; i < buildingTypeData.Length - 1; i++) {
			print ((BuildingType)int.Parse (buildingTypeData [i]));
			buildingTypeList.Add ((BuildingType)int.Parse(buildingTypeData [i]));
		}
	}

	public string BuildingTypeToString()
	{
		string data = "";

		for(int i = 0; i < buildingTypeList.Count; i++)
			data += ((int)buildingTypeList[i]).ToString() + "|";
		
		return data;
	}

	public void MakeFloor()
	{
		int floorSpriteType = Random.Range (0, 3);
		GameObject floorObj = Instantiate (floor, building.transform);
		floorObj.transform.Translate (new Vector2 (0, buildingTypeList.Count * floorHeight));
		floorObj.GetComponent<SpriteRenderer> ().sprite = floorSprite [floorSpriteType];
		buildingTypeList.Add ((BuildingType)floorSpriteType);
	}

	void Update () 
	{
		MoveBuilding ();
		if (Input.GetKeyDown (KeyCode.Space))
			MakeFloor ();
	}

	void MoveBuilding()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			transform.Translate(0, -touchDeltaPosition.y * 0.1f, 0);
			transform.position = new Vector2(0, Mathf.Clamp (transform.position.y, 0, buildingTypeList.Count * floorHeight));
		}
	}
}
