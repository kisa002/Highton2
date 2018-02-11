using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{

    private static EventManager _instance;

    public static EventManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public List<Event> eventList;

    public Canvas eventCanvas;
    public GameObject content;
    public Image blackImg;
    public Text title;
    public Text contentText;
    public Text resultText;

    private Coroutine scaleCoroutine;

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

    public void MakeEvent(int _index)
    {
        int eventIndex = _index;

        title.text = eventList[eventIndex].title;
        contentText.text = eventList[eventIndex].content;
        resultText.text = eventList[eventIndex].result;

        blackImg.color = new Color(0, 0, 0, 0);
        StartCoroutine(Tween2D.TweenSprite.TweenAlpha(blackImg, 120.0f / 255, 0.5f));

        eventCanvas.gameObject.SetActive(true);
    }

    public void CloseEventUI()
    {
        eventCanvas.gameObject.SetActive(false);

        //scaleCoroutine = StartCoroutine (ScaleDownCanvas ());
        //StartCoroutine(Tween2D.TweenSprite.TweenAlpha(blackImg, 0, 0.5f));
    }
}
