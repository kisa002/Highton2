using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UICoinHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int price = 0;

    public GameObject backgroundImage;
    public Text textPrice;

    public void OnPointerEnter(PointerEventData eventData)
    {
        backgroundImage.SetActive(true);
        textPrice.gameObject.SetActive(true);
        textPrice.text = price + "G";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        backgroundImage.SetActive(false);
        textPrice.gameObject.SetActive(false);
    }
}
