using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloude : MonoBehaviour {

	int speed;

	void Start()
	{
		speed = Random.Range (50, 10);
	}

	void Update () {
		transform.Translate (Time.deltaTime * speed, 0, 0);
	}
}
