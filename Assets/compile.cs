using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class compile : MonoBehaviour {
    public InputField variableField, setupField, loopField;
    public Button compButton;
    public List<VarDec> pinDecs = new List<VarDec>();
    public Dictionary<string, int> pins = new Dictionary<string, int>();
    public string[] strVarArray, strSetupArray, strLoopArray;
    void Start () {
        Button btn = compButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	void Update () {
		
	}

    void TaskOnClick()
    {

        pins.Clear();
        strVarArray = variableField.text.Split(';');
        strSetupArray = setupField.text.Split(';');
        strLoopArray = loopField.text.Split(';');
        Debug.Log(strLoopArray.Length);
        string[] pin, devideSetup1, devideSetup2;
        for(int i = 0; i<strVarArray.Length-1; i++)
        {
            pin = strVarArray[i].Split(' ');
            pins.Add(pin[0],Convert.ToInt32(pin[1]));

        
            pinDecs.Add(new VarDec(pin[0], pins[pin[0]], "none"));


            Debug.Log(strVarArray[i]);
            Debug.Log(pins[pin[0]]);
            Debug.Log(Convert.ToInt32("1")+1);

            foreach (VarDec var in pinDecs)
            {
                Debug.Log(var.name + " " + var.pinD + " " + var.state);
            }

        }
        Debug.Log("strSetupArray.Length" + strSetupArray.Length);
        for (int i = 0; i < strSetupArray.Length - 1; i++)
        {
            devideSetup1 = strSetupArray[i].Split('(');
            devideSetup2 = devideSetup1[1].Split(',');
            devideSetup2[1] = devideSetup2[1].Remove(devideSetup2[1].Length - 1);
            Debug.Log(devideSetup1[0] + " " + devideSetup2[0] + " " + devideSetup2[1]);
            if (devideSetup1[0] == "pinMode")
                foreach (VarDec var in pinDecs) { 
                {


                    if (var.name == devideSetup2[0])
                    {
                        var.state = devideSetup2[1];
                    }
                    else if (var.pinD.ToString() == devideSetup2[0]) {
                        var.state = devideSetup2[1];
                    }

                }
        }
            }
        foreach (VarDec var in pinDecs)
        {
            Debug.Log("KONEZ" + var.name + " " + var.pinD + " " + var.state);
        }


    }
}
