using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CEvent {

	public enum EventType {
		Up, 
		Down
	}
	public EventType type;
	public float rateOfChange;
	public string title;
	public string content;
	public string result;
}
