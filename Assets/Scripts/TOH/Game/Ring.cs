using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TOH.Core;

namespace TOH.Game
{
	public class Ring : MonoBehaviour 
	{
		[SerializeField]
		private int size;

		public int Size { get { return size; } }

		void Start()
		{
			// We register this Ring object on Start instead of Awake to
			// ensure that the RingRegistry util has been properly instantiated.
			GameSystems.GetService<RingRegistry>().Register(this);
		}
	}
}
