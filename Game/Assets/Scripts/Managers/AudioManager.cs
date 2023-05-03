using System;
using UnityEngine;
using UnityEngine.Audio;

// Class which manages all the sounds in the game.
public class AudioManager : MonoBehaviour {

	// A static instance of the AudioManager class, which can be accessed from other scripts
	public static AudioManager instance;

	// An array of Sound objects that will be used to store all the sounds in the game.
	public Sound[] sounds;

	void Awake ()
	{
		// Ensure that there is only one instance of the AudioManager class in the game.
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		} else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		// For each sound in the sounds array, add an AudioSource component to the AudioManager game object
		// and set its properties to match the sound object.
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	// Plays a sound with the specified name.
	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Play();
	}

}
