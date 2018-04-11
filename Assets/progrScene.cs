using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class progrScene : MonoBehaviour
{
    public Button progButton;
    public GameObject electrBtn, progrBtn, buildBtn, compileBtn;
    public GameObject elektr, programm, build, electrdPar;
    public Material btnSelected, btnNotSelected;
    public string state = "el";
    public List<GameObject> objs = new List<GameObject>();
    void Start()
    {
        Button btn = progButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void Update()
    {

    }

    public void TaskOnClick()
    {
        if (gameObject == progrBtn)
        {
            elektr.SetActive(false);
            programm.SetActive(true);
            build.SetActive(false);

            compileBtn.GetComponent<Image>().enabled = true;
            compileBtn.GetComponent<Button>().enabled = true;
            compileBtn.GetComponent<compile>().enabled = true;
            for (int i = 0; i < compileBtn.transform.GetChildCount(); i++)
            {
                compileBtn.transform.GetChild(i).gameObject.GetComponent<Text>().enabled = true;
            }

            for (int i = 0; i < electrdPar.transform.GetChildCount(); i++)
            {
                electrdPar.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                electrdPar.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
                for (int b = 0; b < electrdPar.transform.GetChild(i).gameObject.transform.GetChildCount(); b++)
                {
                    electrdPar.transform.GetChild(i).gameObject.transform.GetChild(b).gameObject.GetComponent<BoxCollider2D>().enabled = false ;
                    electrdPar.transform.GetChild(i).gameObject.transform.GetChild(b).gameObject.GetComponent<Button>().enabled = false;
                }

            }
           
       
           


            //foreach (GameObject i in GameObject.FindGameObjectsWithTag("LedEl"))
            //{
            //    objs.Add(i);
            //}
            //foreach (GameObject i in GameObject.FindGameObjectsWithTag("ArduinoEl"))
            //{
            //    objs.Add(i);
            //}
            //foreach (GameObject i in GameObject.FindGameObjectsWithTag("MotorEl"))
            //{
            //    objs.Add(i);
            //}
            //foreach (GameObject i in GameObject.FindGameObjectsWithTag("BatteryEl"))
            //{
            //    objs.Add(i);
            //}

            //foreach (GameObject a in objs)
            //{

            //    a.GetComponent<SpriteRenderer>().enabled = false;
            //    a.GetComponent<BoxCollider2D>().enabled = false;
            //    for (int b = 0; b < a.GetComponent<Transform>().GetChildCount(); b++)
            //    {
            //        Transform c = a.GetComponent<Transform>().GetChild(b);
            //        c.GetComponent<SpriteRenderer>().enabled = false;
            //        c.GetComponent<BoxCollider2D>().enabled = false;

            //    }

            //}


            gameObject.GetComponent<progrScene>().state = "prog";
            electrBtn.GetComponent<progrScene>().state = "prog";
            buildBtn.GetComponent<progrScene>().state = "prog";
        }

        if (gameObject == electrBtn)
        {
            elektr.SetActive(true);
            programm.SetActive(false);
            build.SetActive(false);
            GameObject.Find("ButtonCompile").GetComponent<Image>().enabled = false;
            GameObject.Find("ButtonCompile").GetComponent<Button>().enabled = false;
            for (int i = 0; i < GameObject.Find("ButtonCompile").transform.GetChildCount(); i++)
            {
                GameObject.Find("ButtonCompile").transform.GetChild(i).gameObject.GetComponent<Text>().enabled = false;
            }
            for (int i = 0; i < electrdPar.transform.GetChildCount(); i++)
            {
                electrdPar.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                electrdPar.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = true;
                for (int b = 0; b < electrdPar.transform.GetChild(i).gameObject.transform.GetChildCount(); b++)
                {
                    electrdPar.transform.GetChild(i).gameObject.transform.GetChild(b).gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    electrdPar.transform.GetChild(i).gameObject.transform.GetChild(b).gameObject.GetComponent<Button>().enabled = true;
                }

            }

         
            //foreach (GameObject i in GameObject.FindGameObjectsWithTag("LedEl"))
            //{
            //    objs.Add(i);
            //}
            //foreach (GameObject i in GameObject.FindGameObjectsWithTag("ArduinoEl"))
            //{
            //    objs.Add(i);
            //}
            //foreach (GameObject i in GameObject.FindGameObjectsWithTag("MotorEl"))
            //{
            //    objs.Add(i);
            //}
            //foreach (GameObject i in GameObject.FindGameObjectsWithTag("BatteryEl"))
            //{
            //    objs.Add(i);
            //}

            //foreach (GameObject a in objs)
            //{

            //    a.GetComponent<SpriteRenderer>().enabled = true;
            //    a.GetComponent<BoxCollider2D>().enabled = true;
            //    for (int b = 0; b < a.GetComponent<Transform>().GetChildCount(); b++)
            //    {
            //        Transform c = a.GetComponent<Transform>().GetChild(b);
            //        c.GetComponent<SpriteRenderer>().enabled = true;
            //        c.GetComponent<BoxCollider2D>().enabled = true;

            //    }



            //}
       
            gameObject.GetComponent<progrScene>().state = "el";
            electrBtn.GetComponent<progrScene>().state = "el";
            buildBtn.GetComponent<progrScene>().state = "el";

        }
        if (gameObject == buildBtn)
        {
            elektr.SetActive(false);
            programm.SetActive(false);
            build.SetActive(true);

            GameObject.Find("ButtonCompile").GetComponent<Image>().enabled = false;
            GameObject.Find("ButtonCompile").GetComponent<Button>().enabled = false;
            for (int i = 0; i < GameObject.Find("ButtonCompile").transform.GetChildCount(); i++)
            {
                GameObject.Find("ButtonCompile").transform.GetChild(i).gameObject.GetComponent<Text>().enabled = false;
            }
            for (int i = 0; i < electrdPar.transform.GetChildCount(); i++)
            {
                electrdPar.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                electrdPar.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
                for (int b = 0; b < electrdPar.transform.GetChild(i).gameObject.transform.GetChildCount(); b++)
                {
                    electrdPar.transform.GetChild(i).gameObject.transform.GetChild(b).gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    electrdPar.transform.GetChild(i).gameObject.transform.GetChild(b).gameObject.GetComponent<Button>().enabled = false;
                }

            }

        
            //foreach (GameObject i in GameObject.FindGameObjectsWithTag("LedEl"))
            //{
            //    objs.Add(i);
            //}
            //foreach (GameObject i in GameObject.FindGameObjectsWithTag("ArduinoEl"))
            //{
            //    objs.Add(i);
            //}
            //foreach (GameObject i in GameObject.FindGameObjectsWithTag("MotorEl"))
            //{
            //    objs.Add(i);
            //}
            //foreach (GameObject i in GameObject.FindGameObjectsWithTag("BatteryEl"))
            //{
            //    objs.Add(i);
            //}

            //foreach (GameObject a in objs)
            //{

            //    a.GetComponent<SpriteRenderer>().enabled = false;
            //    a.GetComponent<BoxCollider2D>().enabled = false;
            //    for (int b = 0; b < a.GetComponent<Transform>().GetChildCount(); b++)
            //    {
            //        Transform c = a.GetComponent<Transform>().GetChild(b);
            //        c.GetComponent<SpriteRenderer>().enabled = false;
            //        c.GetComponent<BoxCollider2D>().enabled = false;

            //    }

            //}

            gameObject.GetComponent<progrScene>().state = "prog";
            electrBtn.GetComponent<progrScene>().state = "prog";
            buildBtn.GetComponent<progrScene>().state = "prog";
        }

    }
}
