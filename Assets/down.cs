using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class down : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    private SpriteRenderer spriteRenderer;
    public int i = 0;
    private bool pointerDown;
    private float pointerDownTimer;
    public Component[] imageShow ;
    public Component[] tagsShow;

    [SerializeField]
    private float requiredHoldTime;
    public GameObject Me;
    public GameObject Second;
    public UnityEvent onLongClick;
   
    RaycastHit hit;
    Ray ray;


    [SerializeField]
    private Image fillImage;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("OnPointerDown");

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("OnPointerUp");
        spriteRenderer = GetComponent<SpriteRenderer>();
     

        //    var line = gameObject.AddComponent<LineRenderer>();
        //    line.SetPosition(0, Me.transform.position);
        //    line.SetPosition(1, Me.transform.position);

        i = 1;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
       
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if (onLongClick != null)
                    onLongClick.Invoke();
                
                Debug.Log("hold");
                imageShow = GetComponentsInChildren<Image>();
                Debug.Log(imageShow[0].gameObject.name);
                foreach (Image enabl in imageShow)
                {
                    enabl.enabled = true;
                }
                tagsShow = GetComponentsInChildren<Transform>();
                foreach (Transform trans in tagsShow)
                {
                    gameObject.GetComponent<Transform>().tag = "Selected";
                }
                gameObject.GetComponent<Image>().enabled = true;
                Reset();
                }
            }
        

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && Input.GetMouseButtonDown(0))
        { 
            if (hit.collider == GetComponent<Collider>())
            {
                Debug.Log("HIT!");
            }
        }

     
        }
    

    }



