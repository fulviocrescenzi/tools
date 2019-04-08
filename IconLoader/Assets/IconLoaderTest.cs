using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FulCode.IconLoader;

public class IconLoaderTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		IconLoader iconLoader = GameObject.FindObjectOfType(typeof(IconLoader)) as IconLoader;
		GetComponent<SpriteRenderer>().sprite = iconLoader.GetSprite("packGold3");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
