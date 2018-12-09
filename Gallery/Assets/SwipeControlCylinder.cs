using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine;
using UnityEngine.UI;

public class SwipeControlCylinder : MonoBehaviour
{
    public GameObject imagePanel;

    public GameObject debugText;

    public GameObject imageTarget;

    //public GameObject[] images;

    private Vector3 touchPosition;
    private float delta = 45f;
    float direction = 1.0f;
    int steps = 30;
    private Vector3 lastTouchPosition;

    private Vector2 swipeDistance;
    private float MIN_DISTANCE = 0.05f;


    //private void Update()
    //{
    //    if (Input.touches.Length == 0)
    //        return;

    //    Touch t = Input.GetTouch(0);

    //    if (t.phase == TouchPhase.Began)
    //        lastTouchPosition = new Vector2(t.position.x, t.position.y);

    //    if (t.phase == TouchPhase.Ended)
    //    {
    //        swipeDistance = new Vector2(t.position.x - lastTouchPosition.x, t.position.y - lastTouchPosition.y);
    //        swipeDistance.Normalize();

    //        if ((swipeDistance.x < 0) && (swipeDistance.y > -tweakDistance) && (swipeDistance.y < tweakDistance))
    //            direction = -1.0f;
    //        else if ((swipeDistance.x > 0) && (swipeDistance.y > -tweakDistance) && (swipeDistance.y < tweakDistance))
    //            direction = 1.0f;
    //        else
    //            direction = 0; // свайп куда-то вниз или вверх

    //        if ((imageTarget.transform.eulerAngles.y >= 90f) && (imageTarget.transform.eulerAngles.y <= 270f))
    //        {
    //            direction = -direction;
    //            Debug.Log("Changed direction");
    //        }

    //        if (Mathf.Abs(direction) > 0) // если это НЕ свайп куда-то вниз или вверх, тогда запускаем вращение
    //            StartCoroutine(RotateCylinder());
    //    }
    //}    



    private void Update()
    {


        debugText.GetComponent<Text>().text = imageTarget.transform.eulerAngles.ToString();
        if (!imagePanel.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {


                lastTouchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }


            if (Input.GetMouseButtonUp(0))
            {
                //Debug.Log("PrivetUUUUUUUPPPP");
                swipeDistance = new Vector2(Input.mousePosition.x - lastTouchPosition.x, Input.mousePosition.y - lastTouchPosition.y);
                swipeDistance.x /= Screen.width;
                swipeDistance.y /= Screen.height;

                debugText.GetComponent<Text>().text = swipeDistance.x + "   " + swipeDistance.y;
                //if (((imageTarget.transform.eulerAngles.y >= 45f) && (imageTarget.transform.eulerAngles.y <= 135f))) //|| ((imageTarget.transform.eulerAngles.y >= 225f) && (imageTarget.transform.eulerAngles.y <= 315f)))
                //{
                //    float tmp = swipeDistance.x;
                //    swipeDistance.x = swipeDistance.y;
                //    swipeDistance.y = tmp;
                //}
                
                if ((swipeDistance.x < -MIN_DISTANCE))// && (swipeDistance.y > -MIN_DISTANCE) && (swipeDistance.y < MIN_DISTANCE))
                    direction = 1.0f;
                
                else if ((swipeDistance.x > MIN_DISTANCE))// && (swipeDistance.y > -MIN_DISTANCE) && (swipeDistance.y < MIN_DISTANCE))
                    direction = -1.0f;
                else
                    direction = 0; // свайп куда-то вниз или вверх

                if ((imageTarget.transform.eulerAngles.y >= 90f) && (imageTarget.transform.eulerAngles.y <= 270f))
                {
                    direction = -direction;
                    //Debug.Log("Changed direction");
                }

                if (Mathf.Abs(direction) > 0) // если это НЕ свайп куда-то вниз или вверх, тогда запускаем вращение
                    StartCoroutine(RotateCylinder());
            }
        }

        
    }

    IEnumerator RotateCylinder()
    {
        for (int i = 0; i < steps; i++)
        {
            transform.Rotate(Vector3.up, delta * direction / steps);
            yield return new WaitForSeconds(.01f);
        }
    }




    /*

    private void Update()
    {
        //lastTouchPosition = new Vector3(imageTarget.transform.eulerAngles.x, imageTarget.transform.eulerAngles.y, imageTarget.transform.eulerAngles.z);
        //Debug.Log(lastTouchPosition);

        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            if ((touchPosition - Input.mousePosition).x < 0)
            {
                direction = -1.0f;
            }

            else
            {
                direction = 1.0f;
            }

            if(imageTarget.transform.eulerAngles.y >= 90f && imageTarget.transform.eulerAngles.y <= 270f)
            {
                direction = -direction;
                Debug.Log("Changed direction");
            }

            StartCoroutine(RotateCylinder());
        }
        

    }/*

    IEnumerator RotateCylinder()
    {
        for (int i = 0; i < steps; i++)
        {
            transform.Rotate(Vector3.up, delta * direction / steps);
            yield return new WaitForSeconds(.01f);
        }
    }*/




}

