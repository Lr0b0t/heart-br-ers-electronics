using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class node : MonoBehaviour, IPointerClickHandler
{
    public Color c1 = Color.black;
    public GameObject objA ;

    public GameObject objB;
    bool con = false;
    LineRenderer lineRenderer;
    public GameObject[] linesCoosenObj;

    
    void Awake()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {

      
     
    }

    void Start()
    {
        objA = gameObject;
        //if (objA == null || objB == null)
        //    throw new System.Exception("You must assign two GameObjects");
    }

    void Update() {
        if (con == true)
        {
            gameObject.GetComponent<LineRenderer>().SetPosition(0, objA.transform.position);
            gameObject.GetComponent<LineRenderer>().SetPosition(1, objB.transform.position);
        }
      
    }

    void OnMouseDown()
    {
        Debug.Log("NodeClick");
        linesCoosenObj = GameObject.FindGameObjectsWithTag("LineChoosen");
        Debug.Log("Line Choose = " + linesCoosenObj.Length);

        if (linesCoosenObj.Length == 0)
        {
            Debug.Log("Zashel");
            if (objA.GetComponent<Transform>().tag == "Untagged")
            {
                objA.GetComponent<Transform>().tag = "LineChoosen";
            }
        }

        else if (linesCoosenObj.Length != 0)
        {
            Debug.Log("Ne tak");
            objB = GameObject.FindWithTag("LineChoosen");
            objB.GetComponent<node>().objB = gameObject;
            var line = gameObject.AddComponent<LineRenderer>();
            line.SetWidth(0.1f, 0.1f);
            line.material.color = Color.black;
            line.SetPosition(0, objA.transform.position);
            line.SetPosition(1, objB.transform.position);
            objA.GetComponent<Transform>().tag = "Untagged";
            objB.GetComponent<Transform>().tag = "Untagged";
            con = true;
        }
    }



    }
