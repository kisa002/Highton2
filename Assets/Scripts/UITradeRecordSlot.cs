using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITradeRecordSlot : MonoBehaviour
{
	public Text textContent;

    public void SetContent(string _content)
    {
        textContent.text = _content;
    }


}
