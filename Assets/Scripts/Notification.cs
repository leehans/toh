using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour 
{
	[SerializeField]
	private Text text;

	void OnDestroy()
	{
		StopAllCoroutines();
	}

	public void Display(string message)
	{
		if (text.text.Equals(message) && text.gameObject.activeInHierarchy) return;
		text.text = message;
		StartCoroutine("DelayHide", 3.0f);
	}

	#region  Coroutines
	private IEnumerator DelayHide(float delay)
	{
		yield return new WaitForSeconds(delay);
		text.gameObject.SetActive(false);
		text.text = string.Empty;
	}
	#endregion // Coroutines
}
