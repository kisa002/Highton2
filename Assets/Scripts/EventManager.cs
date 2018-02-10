using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {
	public List<Event> eventList;

	public Canvas eventCanvas;
	public GameObject content;
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
		if(Random.Range (0, 10) == 5)
		{
			int eventIndex = Random.Range (0, eventList.Count);

			title.text = eventList [eventIndex].title;
			contentText.text = eventList [eventIndex].content;
			resultText.text = eventList [eventIndex].result;
			content.transform.localScale = new Vector2 (0, 0);

			eventCanvas.gameObject.SetActive (true);
			StartCoroutine (ScaleCanvas (new Vector2(1, 1)));
		}
	}

	public void CloseEventUI()
	{
		
	}

	IEnumerator ScaleCanvas(Vector2 scale)
	{
		while(content.transform.localScale.x < 0.99f)
		{
			content.transform.localScale = Vector3.Lerp(content.transform.localScale, scale,Time.deltaTime * 5);

			yield return null;
		}
		content.transform.localScale = new Vector2(1, 1);
	}
}
