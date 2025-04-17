using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class Sound
{
	public string Name;
	public AudioClip Clip;
	[Range(0, 1)] public float Volume = 1;
	[Range(-3, 3)] public float Pitch = 1;
	public bool Loop = false;
	public AudioSource Source;
}

public interface IAudioPlayer
{
	void Play(string name);
	void Stop(string name);
}

public class AudioManager : MonoBehaviourSingletonPersistent<AudioManager>, IAudioPlayer
{
	[SerializeField] private List<Sound> sounds;

	private IAudioPlayer _audioPlayer;

	public override void Awake()
	{
		base.Awake();
		_audioPlayer = new AudioPlayer(sounds, gameObject);
	}

	public void Play(string name) => _audioPlayer.Play(name);

	public void Stop(string name) => _audioPlayer.Stop(name);
}
