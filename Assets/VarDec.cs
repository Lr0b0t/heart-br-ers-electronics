using UnityEngine;
using System.Collections;
using System;

public class VarDec {
    public string name, state;
    public int pinD;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public VarDec(string newName, int newPinD, string newState)
    {
        name = newName;
        pinD = newPinD;
        state = newState;
    }
}
