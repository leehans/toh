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
			EventBroadcaster.AddObserver(EventNames.ToggleBGM, HandleOnToggleBGM);
			EventBroadcaster.AddObserver(EventNames.ToggleSFX, HandleOnToggleSFX);
		}

		void OnDestroy()
		{
			EventBroadcaster.RemoveActionAtObserver(EventNames.PlayOneShot, HandleOnPlayOneShotRequest);
			EventBroadcaster.RemoveActionAtObserver(EventNames.ToggleBGM, HandleOnToggleBGM);
			EventBroadcaster.RemoveActionAtObserver(EventNames.ToggleSFX, HandleOnToggleSFX);
		}

		#region Event handlers
		private void HandleOnPlayOneShotRequest(Parameters parameters)
		{
			AudioClip clip = parameters.GetObjectExtra("clip") as AudioClip;
			if (clip != null)
				PlayOneShot(clip);
		}

		private void HandleOnToggleBGM(Parameters p)
		{
			bool isOn = p.GetBoolExtra("on", true);
			if (isOn)
			{
				GameSystems.GetService<IAudioHandler>().UnmuteBGM();
			}
			else
			{
				GameSystems.GetService<IAudioHandler>().MuteBGM();
			}
		}

		private void HandleOnToggleSFX(Parameters p)
		{
			bool isOn = p.GetBoolExtra("on", true);
			if (isOn)
			{
				GameSystems.GetService<IAudioHandler>().UnmuteSFX();
			}
			else
			{
				GameSystems.GetService<IAudioHandler>().MuteSFX();
			}
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
