namespace FulCode.IconLoader
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	[Serializable]
	public class IconLoader : MonoBehaviour {

		public List<string> keys = new List<string>();
		public List<Sprite> data = new List<Sprite>();

		public Sprite GetSprite(string key)
		{
			for (int i = 0; i < keys.Count; i++)
			{
				if (keys[i] == key)
				{
					return data[i];
				}
			}

			return null;
		}
		
	}
}