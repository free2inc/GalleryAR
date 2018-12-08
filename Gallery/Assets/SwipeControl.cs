using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour {

    public GameObject[] images;

    private Vector3 touchPosition;
    private float phi;
    private float oldphi;
    private int redrawCycle;
    private int redrawCycleCount = 20;
    private bool redrawInProgress;
    private bool swipe;
    private float delta;
    private int updateCycle;
    int turn = 0;

    float direction;

    const float RADIUS = 0.1f; 

    float swipeVelocity = 1;
    private Vector3 lastTouchPosition;

    private void Redraw()
    {
        for (int i = 0; i < images.Length; i++)
        {
            //images[i].transform.position = new Vector3(
            //    RADIUS * Mathf.Sin(2 * Mathf.PI * (float)i / (float)images.Length + phi), images[i].transform.position.y, 0);
            //if (Mathf.Cos(phi - delta * (i - 2*turn)) > 0)
            //    images[i].SetActive(false);
            //else images[i].SetActive(true);
            
        }
            
    }

    private void Start()
    {
        redrawInProgress = false;
        redrawCycle = 0;
        phi = 0;
        delta = 2 * Mathf.PI / (float)images.Length;
        Redraw();
    }

    //private void FixedUpdate()
    //{
    //    if (swipe)
    //    {
    //        if (updateCycle == 0)
    //        {
    //            swipeVelocity = (Input.mousePosition - lastTouchPosition).x;
    //            lastTouchPosition = Input.mousePosition;
    //            updateCycle = 5;
    //        }
    //        else
    //            updateCycle--;
    //    }

    //    if (redrawInProgress)
    //    {
    //        if (redrawCycle > 0)
    //        {
    //            float deltaPhi = -(swipeVelocity * 0.2f) * delta / (float) (100 * (redrawCycleCount - redrawCycle + 1));
    //            phi += deltaPhi;
    //            Redraw();
    //            redrawCycle--;
    //        }
    //        else
    //        {
    //            redrawInProgress = false;
    //            Redraw();
    //        }
    //    }
    //}


    private void FixedUpdate()
    {
       
        if (redrawInProgress)
        {
            if (redrawCycle > 0)
            {
                float deltaPhi = direction * delta / redrawCycleCount;
                phi += deltaPhi;
                Redraw();
                redrawCycle--;
            }
            else
            {
                redrawInProgress = false;
                phi = oldphi + direction * delta;
                Redraw();                
            }
        }
    }



    //private void Update()
    //{

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        touchPosition = Input.mousePosition;
    //        oldphi = phi;
    //        swipe = true;
    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        swipe = false;
    //        Debug.Log(swipeVelocity * delta);
    //        redrawCycle = redrawCycleCount;
    //        redrawInProgress = true;
    //    }
            

    //    if (swipe)
    //    {
    //        Vector2 deltaSwipe = touchPosition - Input.mousePosition;
    //        float deltaPhi = deltaSwipe.x / 2000;

    //        phi = oldphi + deltaPhi;
    //        Redraw();
    //    }
    //}




    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
            oldphi = phi;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if ((touchPosition - Input.mousePosition).x < 0)
            {
                direction = -1.0f;
                turn++;
            }

            else
            {
                direction = 1.0f;
                turn--;
            }
            redrawCycle = redrawCycleCount;
            redrawInProgress = true;
        }

        

    }




    /*
    private bool swiping = false;
    private bool eventSent = false;
    private Vector2 lastPosition;

    // Use this for initialization
    void Start () {
        Debug.Log("HELLOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOo");
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.touchCount == 0)
            return;
        Debug.Log("11");
        if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0)
        {
            if (swiping == false)
            {
                swiping = true;
                lastPosition = Input.GetTouch(0).position;
                return;
            }
            else
            {
                if (!eventSent)
                {
                    Vector2 direction = Input.GetTouch(0).position - lastPosition;

                    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                    {
                        if (direction.x > 0)
                            Debug.Log("Right");
                        else
                            Debug.Log("Left");
                    }
                    eventSent = true;
                }
            }
        }
        else
        {
            swiping = false;
            eventSent = false;
        }
    }*/
}

