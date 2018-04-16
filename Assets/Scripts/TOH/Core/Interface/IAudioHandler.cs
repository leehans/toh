using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Audio handler interface for serving simple audio requests
// By: Lee
public interface IAudioHandler
{
	// Plays the specified audio clip one-time
	void PlayOneShot(AudioClip clip);

	void MuteBGM();

	void UnmuteBGM();

	void MuteSFX();

	void UnmuteSFX();
}
