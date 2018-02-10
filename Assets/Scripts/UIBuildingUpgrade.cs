using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIBuildingUpgrade : MonoBehaviour
{
    BuildingManager buildingManager;

    public GameObject buildingUpgradePannel;

    public Text requireGoldText;
    public Text currentFloorText;
    public Text nextFloorText;

    public GameObject failGold;

    public float floorHeight = 2.2f;

    public UnityEvent viewEvent, hideEvent;

    private void Start()
    {
        buildingManager = BuildingManager.Instance;
    }

    public void View()
    {
        int currentFloor = buildingManager.buildingTypeList.Count;

        requireGoldText.text = 1000 * (buildingManager.currentFloor + 1) * 3 + "<color=yellow>G</color>";
        currentFloorText.text = currentFloor.ToString() + "층";
        nextFloorText.text = (currentFloor + 1).ToString() + "층";

        if (viewEvent == null)
            return;

        viewEvent.Invoke();
    }

    public void Build()
    {
        int price = 1000 * (buildingManager.currentFloor + 1) * 3;
        if (PlayDataManager.Instance.EnoughGold(price))
        {
            PlayDataManager.Instance.AddGold(-price);
            buildingManager.MakeFloor();
            failGold.SetActive(false);
        }
        else
        {
            failGold.SetActive(true);
        }
    }

    public void UpdateFloor()
    {
        currentFloorText.text = buildingManager.currentFloor.ToString() + "층";
        nextFloorText.text = (buildingManager.currentFloor + 1).ToString() + "층";
        requireGoldText.text = 1000 * (buildingManager.currentFloor + 1) * 3 + "<color=yellow>G</color>";
    }

    public void Hide()
    {
        if (hideEvent == null)
            return;

        hideEvent.Invoke();
    }
}
