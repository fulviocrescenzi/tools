using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Extractor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void Extract()
	{
		int filenum = 0;
		Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites");
		Debug.Log("sprites count: " + sprites.Length);
		
		foreach (Sprite sprite in sprites)
		{
			Texture2D texture = sprite.texture;
			Rect textureRect = sprite.textureRect;
			Color[] pixels = texture.GetPixels((int)textureRect.x, (int)textureRect.y, (int)textureRect.width, (int)textureRect.height);
			
			Texture2D newTexture = new Texture2D((int)textureRect.width, (int)textureRect.height, TextureFormat.ARGB32, false);
			newTexture.SetPixels(pixels);

			byte[] bytes = newTexture.EncodeToPNG();
			string filePath = Application.dataPath + "/Extracted/file_" + filenum.ToString() + ".png";
			Debug.Log("File saved in " + filePath);
			File.WriteAllBytes(filePath, bytes);
			filenum++;
		}
		
	}
}
