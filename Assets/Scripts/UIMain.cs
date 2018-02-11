using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMain : MonoBehaviour
{
    public GameObject touchButton, textTouch, panelRegister, imageTitle;

    public void ShowRegister()
    {
        panelRegister.SetActive(true);
    }

    public void TouchtoStart()
    {
		SoundManager.Instance.PlaySound (SoundManager.AudioType.Upgrade);
		StopAllCoroutines ();
		StartCoroutine (TextEffect ());
    }

	IEnumerator TextEffect()
	{
		Color textColor;
		while((textColor = textTouch.GetComponent<Text>().color).a > 0.2f)
		{
			textColor.a -= Time.deltaTime;
			textTouch.GetComponent<Text>().color = textColor; 
			textTouch.transform.localScale += new Vector3 (Time.deltaTime, Time.deltaTime, 0) * 1.2f;
			yield return null;
		}

		if (PlayDataManager.Instance.GetNickName() != "")
		{
			LoadGame();
		}
		else
			ShowRegister();
	}

    public void LoadGame()
    {
		SoundManager.Instance.BGM.clip = SoundManager.Instance.inGameBgmClip;
		SoundManager.Instance.BGM.Play ();

        SceneManager.LoadScene("InGame");
    }

    public void Register(InputField _input)
    {
        if (_input.text == "")
            return;

        PlayDataManager.Instance.SetNickName(_input.text);
        LoadGame();
    }

	void Start()
	{
		StartCoroutine (SetScaleTitle ());
	}

	IEnumerator SetScaleTitle()
	{
		while(true)
		{
			StartCoroutine (Tween.TweenTransform.LocalScale(imageTitle.transform, new Vector2(1.1f, 1.1f), 0.5f));
			StartCoroutine (Tween.TweenTransform.LocalScale(textTouch.transform, new Vector2(1.1f, 1.1f), 0.5f));
			yield return new WaitForSeconds (0.5f);
			StartCoroutine (Tween.TweenTransform.LocalScale(imageTitle.transform, new Vector2(1, 1), 0.5f));
			StartCoroutine (Tween.TweenTransform.LocalScale(textTouch.transform, new Vector2(1, 1), 0.5f));
			yield return new WaitForSeconds (0.5f);
		}
	}
}
