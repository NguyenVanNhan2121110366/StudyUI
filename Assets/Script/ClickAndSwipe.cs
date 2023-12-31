using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer),typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{
    public GameManager gamemanager;
    public Camera cam;
    public Vector3 mousePos;
    public TrailRenderer trail;
    public BoxCollider col;
    public bool swiping = false; 
    // Start is called before the first frame update
    void Awake()
    {
        this.cam=Camera.main;
        this.gamemanager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        this.trail=GetComponent<TrailRenderer>();
        this.col=GetComponent<BoxCollider>();
        trail.enabled=false;
        col.enabled=false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.updateCkeck();
    }
    void updateMousePosition()
    {
        mousePos=cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f));
        transform.position=mousePos;
    }
    void updateComponent()
    {
        trail.enabled=swiping;
        col.enabled=swiping;
    }
    void updateCkeck()
    {
        if(gamemanager.ggameOver)
        {
            if(Input.GetMouseButtonDown(0))
            {
                swiping=true;
                updateComponent();
            }
            else if(Input.GetMouseButtonUp(0))
            {
                swiping=false;
                updateComponent();
            }
            if(swiping)
            {
                updateMousePosition();
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<ClickDestroy>().destroyTarget();
        }
    }

}
