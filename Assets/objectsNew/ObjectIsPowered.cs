using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIsPowered : MonoBehaviour {
	public bool getPowered;
	public MonoBehaviour[] scripts;


	// Use this for initialization
	void Start () {
		scripts = gameObject.GetComponents<MonoBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (getPowered);
		if (getPowered == true) {
			foreach (MonoBehaviour mb in scripts)
			{
				
			}

		}
	}
}
