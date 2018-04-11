using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryScr : MonoBehaviour {
    public Component[] pinsShow;
    public GameObject posVoltGO, negVoltGO, uno ;
	public bool negativeVolt, positiveVolt;

    // Use this for initialization
    void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		positiveVolt = false; 
		negativeVolt = false;
        uno = GameObject.Find("ArduinoSprite(Clone)");
        pinsShow = GetComponentsInChildren<node>();
        foreach (node nodePref in pinsShow)
        {
			if ((nodePref.objA.name == "NodeNeg") && (nodePref.objB != null)) { //node of battery 
				if ((nodePref.objB.name == "NodeGnd" )|| (nodePref.objB.name == "NodeNeg") ){							//arduino node
					Debug.Log (nodePref.objA.name + nodePref.objB.name);
					negativeVolt = true;
					negVoltGO = nodePref.objB.transform.parent.gameObject;
					//uno.GetComponent<brain>().negVolt = true;
				}
			
			} else if ((nodePref.objA.name == "NodePos") && (nodePref.objB != null)) {
				if ((nodePref.objB.name == "NodeVin") || (nodePref.objB.name == "NodePin") || (nodePref.objB.name == "NodePos")) {
					Debug.Log (nodePref.objA.name + nodePref.objB.name);
					positiveVolt = true;
					posVoltGO = nodePref.objB.transform.parent.gameObject;
			
					// uno.GetComponent<brain>().posVolt = true;
				}
			}

        }

		if (negVoltGO == posVoltGO) {
			negVoltGO.GetComponent<ObjectIsPowered> ().getPowered = true;
		}
    }
}
