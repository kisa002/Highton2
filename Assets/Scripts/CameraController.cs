﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour {

	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	private Coroutine moveCoroutine;

	public enum Direction
	{
		Left,
		Right,
		Up,
		Down,
		None
	}

	void Update () {
		Direction swaipeDirection = Direction.None;
		if(!EventSystem.current.IsPointerOverGameObject())
			swaipeDirection = Swipe ();

		if (moveCoroutine == null) {
			if (swaipeDirection == Direction.Left)
				GameManager.instance.sceneFormat--;
			if (swaipeDirection == Direction.Right)
				GameManager.instance.sceneFormat++;

			if (swaipeDirection == Direction.Left || swaipeDirection == Direction.Right) {
				Vector3 targetPos = new Vector3 ((int)GameManager.instance.sceneFormat * 5.68f, 0, -10);

				moveCoroutine = StartCoroutine (MoveCamera (targetPos, swaipeDirection));
			}
		}
	}

	IEnumerator MoveCamera(Vector3 targetPos, Direction direction)
	{
		while(Vector3.SqrMagnitude(transform.position - targetPos) > 0.05f)
		{
			transform.position = Vector3.Lerp(transform.position, targetPos,Time.deltaTime * 6);

			yield return null;
		}
		transform.position = targetPos;
		moveCoroutine = null;
	}

	Direction Swipe()
	{		
		if(Input.GetMouseButtonDown(0))
		{
			firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		}
		if(Input.GetMouseButtonUp(0))
		{
			secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);

			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

			currentSwipe.Normalize();

			if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
			{
				return Direction.Up;
			}
			if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
			{
				return Direction.Down;
			}
			if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
			{
				return Direction.Left;
			}
			if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
			{
				return Direction.Right;
			}
		}
		return Direction.None;
	}
		
	void Swipe2()
	{
		if(Input.touches.Length > 0)
		{
			Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began)
			{
				firstPressPos = new Vector2(t.position.x,t.position.y);
			}
			if(t.phase == TouchPhase.Ended)
			{
				secondPressPos = new Vector2(t.position.x,t.position.y);
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

				currentSwipe.Normalize();

				if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
				{
					Debug.Log("up swipe");
				}
				if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
				{
					Debug.Log("down swipe");
				}
				if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					Debug.Log("left swipe");
				}
				if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					Debug.Log("right swipe");
				}
			}
		}
	}
}