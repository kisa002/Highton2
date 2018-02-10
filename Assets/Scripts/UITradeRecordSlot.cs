using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITradeRecordSlot : MonoBehaviour
{

    public Text content;

    public void SetContent(string _content)
    {
        content.text = _content;
    }

}
