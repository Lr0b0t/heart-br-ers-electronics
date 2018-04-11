using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brain : MonoBehaviour {
    public bool posVolt, negVolt;
    public int a;
    public Dictionary<int, GameObject> pins = new Dictionary<int, GameObject>();
    public Dictionary<int, string> chto = new Dictionary<int, string>();
    public GameObject compileBtn;
    public Transform compBtn1;
    public string[] loopAr;

    public GameObject led;
	// Use this for initialization
	void Start () {
        compileBtn = GameObject.Find("ButtonCompile");
      //  compBtn1 =  compileBtn.GetComponent<Transform>().Find("Canvas").GetComponent<Transform>().Find("Canvas").GetComponent<Transform>().Find("ButtonCompile") ;


        led = gameObject.transform.Find("WorkLed").gameObject;
        
    }
	
	// Update is called once per frame
	void Update () {
       
		if (posVolt && negVolt)
        {
            led.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (compileBtn.GetComponent<compile>() != null)
        {
            loopAr = compileBtn.GetComponent<compile>().strLoopArray;
        }
       
        string[] devideLoop1, devideLoop2;
        for (int i = 0; i < loopAr.Length - 1; i++)
        {
            devideLoop1 = loopAr[i].Split('(');
            devideLoop2 = devideLoop1[1].Split(',');
            devideLoop2[1] = devideLoop2[1].Remove(devideLoop2[1].Length - 1);
            //Debug.Log(devideLoop1[0] + " " + devideLoop2[0] + " " + devideLoop2[1]);
            if (devideLoop1[0] == "digitalWrite")
            {

                foreach (VarDec var in compileBtn.GetComponent<compile>().pinDecs)
                {
                    if (var.pinD != null && var.state != null)
                        if (((var.name == devideLoop2[0]) || (var.pinD.ToString() == devideLoop2[0])) && (var.state == "OUTPUT"))
                        {
                            Debug.Log(devideLoop2[1]);
                            if (devideLoop2[1] == "HIGH")
                            {
                                a = 1;

                            }
                            else if (devideLoop2[1] == "LOW")
                            {
                                a = 0;
                            }
                            Debug.Log(a);
                            Debug.Log(var.pinD);
                            if (gameObject.transform.Find("Node" + var.pinD) != null) {
                                GameObject pinObject = gameObject.transform.Find("Node" + var.pinD).GetComponent<node>().objB.transform.parent.gameObject;

                                Debug.Log(pinObject.name);
                            if (pinObject.name == "LedSprite(Clone)")
                                {
								pinObject.GetComponent<led>().isPowered = a;
                                    Debug.Log("getCompile " + a);
                                }
                            }

                        }
                
                
                }

            }
            else if (devideLoop1[0] == "delay")
            {
                Component[] programmingObj = gameObject.GetComponent<Transform>().parent.GetComponentsInChildren<Transform>();
                foreach (Transform trans in programmingObj)
                {
                    if (trans.name == "LedObj(Clone)")
                    {

                      //  trans.gameObject.GetComponent<led>().getCompile = "delay " + devideLoop2[1];

                    }
                }
            }
            for (int c = 0; c < devideLoop1.Length;c++)
            {
                devideLoop1[c] = null;
            }
            for (int d = 0; d < devideLoop2.Length; d++)
            {
                devideLoop1[d] = null;
            }


        }
        

        if (pins[10] != null)
        {
            Debug.Log(pins[10].GetComponent<Transform>().name);
            Debug.Log("HI");
        }
    }
}
