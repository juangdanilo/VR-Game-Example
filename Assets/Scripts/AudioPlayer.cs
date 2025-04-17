using UnityEngine;
using System.Collections.Generic;

public class AudioPlayer : IAudioPlayer
{
	private readonly Dictionary<string, Sound> _soundDictionary;

	public AudioPlayer(IEnumerable<Sound> sounds, GameObject gameObject)
	{
		_soundDictionary = new Dictionary<string, Sound>();

		foreach (var sound in sounds)
		{
			if (sound.Source == null)
				sound.Source = gameObject.AddComponent<AudioSource>();

			sound.Source.clip = sound.Clip;
			sound.Source.volume = sound.Volume;
			sound.Source.pitch = sound.Pitch;
			sound.Source.loop = sound.Loop;

			_soundDictionary[sound.Name] = sound;
		}
	}

	public void Play(string name)
	{
		if (_soundDictionary.TryGetValue(name, out var sound))
		{
			sound.Source.Play();
		}
		else
		{
			Debug.LogWarning($"Sound: {name} not found");
		}
	}

	public void Stop(string name)
	{
		if (_soundDictionary.TryGetValue(name, out var sound))
		{
			sound.Source.Stop();
		}
	}
}
