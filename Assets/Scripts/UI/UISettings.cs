using System.Collections;
using System.Collections.Generic;
using TOH.Core;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour 
{
	void Start()
	{
		EventBroadcaster.AddObserver(EventNames.ToggleBGM, HandleOnToggleBGM);
		EventBroadcaster.AddObserver(EventNames.ToggleSFX, HandleOnToggleSFX);
	}

	void OnDestroy()
	{
		EventBroadcaster.RemoveActionAtObserver(EventNames.ToggleBGM, HandleOnToggleBGM);
		EventBroadcaster.RemoveActionAtObserver(EventNames.ToggleSFX, HandleOnToggleSFX);
	}
	
	#region Event handlers
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
}
