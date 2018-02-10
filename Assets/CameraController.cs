using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;
	

	public enum Direction
	{
		Left,
		Right,
		Up,
		Down,
		None
	}

	void Update () {
		Direction swaipeDirection = Swipe ();
		if (swaipeDirection == Direction.Left) {
			print ("Left");
		} else if (swaipeDirection == Direction.Right)
			print ("Right");
	}

	IEnumerator MoveCamera(Vector2 pos)
	{
		yield return null;
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
