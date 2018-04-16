using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOH.Core
{
	// Simple handler for game music and sfx
	// by: Lee
	public class AudioHandler : MonoBehaviour, IAudioHandler 
	{
		[SerializeField]
		private AudioSource sfxSource;

		[SerializeField]
		private AudioSource bgmSource;

		private float sfxDefaultVolume;

		void Awake()
		{
			GameSystems.Register(typeof(IAudioHandler), this);
			sfxDefaultVolume = sfxSource.volume;
		}

		void Start()
		{
			EventBroadcaster.AddObserver(EventNames.PlayOneShot, HandleOnPlayOneShotRequest);
		}

		void OnDestroy()
		{
			EventBroadcaster.RemoveActionAtObserver(EventNames.PlayOneShot, HandleOnPlayOneShotRequest);
		}

		#region Event handlers
		private void HandleOnPlayOneShotRequest(Parameters parameters)
		{
			AudioClip clip = parameters.GetObjectExtra("clip") as AudioClip;
			if (clip != null)
				PlayOneShot(clip);
		}
		#endregion // Event handlers

		#region IAudioHandler implementation
		public void PlayOneShot(AudioClip clip)
		{
			if (sfxSource.volume > 0)
				sfxSource.PlayOneShot(clip);
		}

		public void MuteBGM()
		{
			bgmSource.Pause();
		}

		public void UnmuteBGM()
		{
			bgmSource.UnPause();
		}

		public void MuteSFX()
		{
			sfxSource.volume = 0;
		}

		public void UnmuteSFX()
		{
			sfxSource.volume = sfxDefaultVolume;
		}
		#endregion // IAudioHandler implementation
	}
}
