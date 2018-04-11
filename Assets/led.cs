using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class led : MonoBehaviour {
    public Component[] pinsShow;
    public Component[] namesShow;
    public GameObject uno;
    public bool pinCheck, GndCheck;
    public int pin;
    public int isPowered; 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(isPowered);

        uno = gameObject.transform.parent.Find("ArduinoSprite(Clone)").gameObject;
        pinsShow = GetComponentsInChildren<node>();
        
        foreach (node nodePref in pinsShow)
        {
            if ((nodePref.objA.name == "NodeNeg") && (nodePref.objB != null))
            {
                if (nodePref.objB.name == "NodeGnd")
                {
                   // Debug.Log(nodePref.objA.name + nodePref.objB.name);
                    GndCheck = true;
                }
            }

            else if ((nodePref.objA.name == "NodePin") && (nodePref.objB != null))
            {
                for (int i = 0; i < 14; i++)
                {
                    if (i+"Pin" == nodePref.objB.name)
                    {
                        pinCheck = true;
                        pin = i;

                    }
                }
                
                if (pinCheck)
                {
                   // Debug.Log(nodePref.objA.name + nodePref.objB.name);
                  //  Debug.Log(pin);
                   
                }
            }
        }

        if((GndCheck == true)&&(pinCheck == true))
        {
            uno.GetComponent<brain>().pins.Add(pin, gameObject);
            Debug.Log("Izmenil");

        }

    }

	public void isPower(bool get){
		if (get){
			Debug.Log ("true");
			get = false;
		}
	} 
}
