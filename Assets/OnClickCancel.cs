using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickCancel : MonoBehaviour {
    public Button cancelButton;
    private GameObject[] selected;
    public Component[] imageShow;
    public Component[] tagsShow;
    // Use this for initialization
    void Start () {
        Button btn = cancelButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        selected = GameObject.FindGameObjectsWithTag("Selected");

        foreach (GameObject selectObj in selected)
        {
            imageShow = selectObj.GetComponentsInChildren<Image>();
            foreach (Image enabl in imageShow)
                enabl.enabled = false;
            tagsShow = selectObj.GetComponentsInChildren<Transform>();
            foreach (Transform trans in tagsShow)
                trans.tag = "Untagged";
            selectObj.GetComponent<Image>().enabled = true;
        }
    }
}
