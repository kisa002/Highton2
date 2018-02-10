using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {
	public List<Event> eventList;

	public Canvas eventCanvas;
	public GameObject content;
	public Image blackImg;
	public Text title;
	public Text contentText;
	public Text resultText;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space))
			MakeEvent ();
	}

	void MakeEvent()
	{
		//if(Random.Range (0, 10) == 5)
		//{
			int eventIndex = Random.Range (0, eventList.Count);

			title.text = eventList [eventIndex].title;
			contentText.text = eventList [eventIndex].content;
			resultText.text = eventList [eventIndex].result;
			content.transform.localScale = new Vector2 (0, 0);

			blackImg.color = new Color(0, 0, 0, 0);
			StartCoroutine(Tween2D.TweenSprite.TweenAlpha (blackImg, 120.0f / 255, 0.5f));

			eventCanvas.gameObject.SetActive (true);
			StartCoroutine (ScaleUpCanvas ());
		//}
	}

	public void CloseEventUI()
	{
		StartCoroutine (ScaleDownCanvas ());
		StartCoroutine(Tween2D.TweenSprite.TweenAlpha (blackImg, 0, 0.5f));
	}

	IEnumerator ScaleUpCanvas()
	{
		while(content.transform.localScale.x < 0.99f)
		{
			content.transform.localScale = Vector3.Lerp(content.transform.localScale, new Vector2(1, 1),Time.deltaTime * 7);

			yield return null;
		}
		content.transform.localScale = new Vector2(1, 1);
	}

	IEnumerator ScaleDownCanvas()
	{
		while(content.transform.localScale.x > 0.01f)
		{
			content.transform.localScale = Vector3.Lerp(content.transform.localScale, new Vector2(0, 0),Time.deltaTime * 10);

			yield return null;
		}
		content.transform.localScale = new Vector2(0, 0);
		eventCanvas.gameObject.SetActive (false);
	}
}
