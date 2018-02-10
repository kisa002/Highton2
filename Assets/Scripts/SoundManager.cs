using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	private static SoundManager _instance;

	public enum AudioType {
		Alert,
		Button1,
		Button2,
		Buy,
		Popup,
		Sell,
		Sell2,
		Upgrade
	}

	public AudioClip[] audioClips = new AudioClip[8];
	public AudioSource audioSource;
	public AudioSource BGM;
	public AudioClip inGameBgmClip;

	public static SoundManager Instance
	{
		get
		{
			return _instance;
		}
	}

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

	public void PlaySound(AudioType type)
	{
		audioSource.PlayOneShot (audioClips [(int)type], 1);
	}
}
