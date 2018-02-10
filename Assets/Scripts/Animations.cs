﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animations : MonoBehaviour {

	public void PlayScaleUpAnimtion(Transform transform)
	{
		StartCoroutine(Tween.TweenTransform.LocalScale (transform, new Vector2(1, 1), 0.3f));
	}
	public void PlayScaleDownAnimtion(Transform transform)
	{
		StartCoroutine(Tween.TweenTransform.LocalScale (transform, new Vector2(0, 0), 0.3f));
	}

	public void PlayTranslateAnimtion(Transform target, Transform end, float time)
	{
		StartCoroutine(Tween.TweenTransform.TweenTrans (target, end, time));
	}

	public void PlayFadeInAnimtion(SpriteRenderer renderer, float end, float time)
	{
		print ("IN");
		StartCoroutine(Tween2D.TweenSprite.TweenAlpha (renderer, 150 / 255.0f, 0.3f));
	}
	public void PlayFadeOutAnimtion(SpriteRenderer renderer, float end, float time)
	{
		StartCoroutine(Tween2D.TweenSprite.TweenAlpha (renderer, 0, 0.3f));
	}

	public void PlayFadeInAnimtion(Image image)
	{
		StartCoroutine(Tween2D.TweenSprite.TweenAlpha (image, 150 / 255.0f, 0.3f));
	}
	public void PlayFadeOutAnimtion(Image image)
	{
		StartCoroutine(Tween2D.TweenSprite.TweenAlpha (image, 0, 0.3f));
	}
}