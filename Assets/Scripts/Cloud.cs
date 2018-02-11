using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	int speed;

	void Start()
	{
		speed = Random.Range (50, 100);
	}

	void Update () {
		if (transform.position.x < -950) {
			BuildingManager.Instance.cloudList.Remove (GetComponent<Cloud>());
			Destroy (gameObject);
		}

		if (transform.position.y < -1200)
			transform.position = new Vector2 (transform.position.x, 3500);
		if (transform.position.y > 3500)
			transform.position = new Vector2 (transform.position.x, -1200);

		transform.Translate (-Time.deltaTime * speed, 0, 0);
	}
}
