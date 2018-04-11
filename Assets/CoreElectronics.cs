using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CoreElectronics : MonoBehaviour {

	[SerializeField]
	GameObject[] objects;
	public int currentlySelectedItemIndex;

	List<GameObject> instantiatedObjects = new List<GameObject>();

	public GameObject focusedObject;

	[SerializeField]
	public int SelectedPrefabIndex;
	public GameObject firstGameObjectToLink;
	[SerializeField]
	CameraControl controller;

	[SerializeField]
	GameObject positionWhereToSpawnObjects;

	bool isPausedNow = false;														

	bool IsNowAddingLink = false;

	int[,] map = new int[50, 50];			

	[SerializeField]
	Material linerMaterial;

	public void InstantiateObject(int index) {										//create new obj function
		GameObject spawnedObject = Instantiate(objects[index], Vector2.zero, Quaternion.identity);		//create new obj index of scroll image  

		instantiatedObjects.Add(spawnedObject);										// add created obj to array 
		BoxCollider2D collider = spawnedObject.GetComponent<BoxCollider2D>();		//get collider component 
		Vector2 pos = positionWhereToSpawnObjects.transform.position;				//position where to locate obj
		pos.y += collider.bounds.size.y / 2f;										//put 0.5 of height higher 
		spawnedObject.transform.position = pos;										//set obj position 

		SetObjectAsFocused(spawnedObject);											//set obj as focused 
		Camera.main.transform.position = new Vector3(pos.x, pos.y, -10);			//set camera to created obj
	}

	public void RemoveObject() {													//remove obj function 

	}
		
	public void RotateObject(int direction) {										//rotate obj function 
		if(!focusedObject) {														///if there isn't focuset obj return
			return;
		}
		focusedObject.transform.Rotate(0, 0, 45 * -direction);						//rotate object 
	}

											

	void Start() {

	}

	void SetObjectAsFocused(GameObject toFocus) {									//set obj as foused function 

		focusedObject = toFocus;

	}

	void RoundVector(ref Vector3 toRound) {											//round vector, so that it ill move in cm 
		toRound.x = Mathf.Round(toRound.x * 10f) / 10f;
		toRound.y = Mathf.Round(toRound.y * 10f) / 10f;
		toRound.z = Mathf.Round(toRound.z * 10f) / 10f;
	}
	float startTime = 0f;
	GameObject hitObjectOnStart;
	Vector2 hitAndObjectCenterDelta;
	bool isHitOnFocusedObject = false;

	bool AllowCameraMovement = true;


	void Update() {
		if(Input.touchCount > 0) {													// if something is touched 
			Touch touch = Input.GetTouch(0);										//get touch 
			Vector2 touchPosition = touch.position;									//get touch position 

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touchPosition), Vector2.zero); //send ray to the touched position

			if(touch.phase == TouchPhase.Began) {									
				//If we just started pressing (1 frame when user clicked)
				if (hit && !IsPointerOverUIObject())
				{
					hitObjectOnStart = hit.transform.gameObject;					//get game obj was hit 
					hitAndObjectCenterDelta = hit.transform.position - Camera.main.ScreenToWorldPoint(touchPosition); //delta between touch and obj center position 

					if (focusedObject && focusedObject == hit.transform.gameObject)
					{
						isHitOnFocusedObject = true;
					}
					else
					{
						isHitOnFocusedObject = false;
					}
				}
				else {
					hitObjectOnStart = null;
					isHitOnFocusedObject = false;
					hitAndObjectCenterDelta = Vector2.zero;
				}

				startTime = Time.time;
			}
			else if(touch.phase == TouchPhase.Ended) {
				//If we just ended pressing (1 frame when user releasd his finger)
				if (Time.time - startTime < 0.1f && hit && hitObjectOnStart == hit.transform.gameObject)
				{
					if (hit.transform.gameObject.transform.tag == "node") {
						
					
						if (IsNowAddingLink) {
							hitObjectOnStart = null;
							IsNowAddingLink = false;


							LineBetweenTwoObjects liner = new GameObject ().AddComponent<LineBetweenTwoObjects> ();
							liner.materialToSet = linerMaterial;
							liner.object1 = hit.transform.gameObject;
							liner.object2 = firstGameObjectToLink;
							startTime = 0f;
						} else {
							firstGameObjectToLink = hit.transform.gameObject;
							IsNowAddingLink = true; 
						}
					}
					else
					{
						hitObjectOnStart = null;
						SetObjectAsFocused(hit.transform.gameObject);
						hitAndObjectCenterDelta = Vector2.zero;
						startTime = 0f;
					}
				}
				isHitOnFocusedObject = false;

				AllowCameraMovement = true;
			}
			else
			{
				//If we are moving our finger
				if (isHitOnFocusedObject)
				{
					Vector3 worldPos = Camera.main.ScreenToWorldPoint(touchPosition);
					worldPos += (Vector3)hitAndObjectCenterDelta;

					RoundVector(ref worldPos);
					worldPos.z = 0;
					focusedObject.transform.position = worldPos;
					AllowCameraMovement = false;
				}
			}
		}

		if (AllowCameraMovement && !IsPointerOverUIObject()) {
			controller.UpdateCamera();
		}
	}

	private bool IsPointerOverUIObject()
	{
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}
}
