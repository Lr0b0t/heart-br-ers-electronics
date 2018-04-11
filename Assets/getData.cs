using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getData : MonoBehaviour {

	// Use this for initialization
	void Start () {
       Debug.Log( PlayerPrefs.GetInt("blabla"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
