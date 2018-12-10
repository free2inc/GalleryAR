using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnClickImage : MonoBehaviour
{
    //static bool isPanelActive = false;

    public GameObject imagePanel;
    public GameObject image;

    DefaultTrackableEventHandler holder;

    Vector2 lastTouchPosition;
    Vector2 swipeDistance;

    private void Start()
    {
        //isPanelActive = false;
        imagePanel.SetActive(false);

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastTouchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }


        if (Input.GetMouseButtonUp(0))
        {
            if (imagePanel.activeSelf)
                imagePanel.SetActive(false);
            else
            {
                swipeDistance = new Vector2(Input.mousePosition.x - lastTouchPosition.x, Input.mousePosition.y - lastTouchPosition.y);
                swipeDistance.Normalize();
                if (swipeDistance.magnitude < 0.1)
                {                
                    Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {                    
                        //Debug.Log(hit.transform.GetComponent<SpriteRenderer>().color.a);
                        if ((!imagePanel.activeSelf) && (hit.transform.tag == "Image") && (hit.transform.GetComponent<SpriteRenderer>().color.a > 0.9f))
                        {                        
                            //isPanelActive = true;
                            imagePanel.SetActive(true);
                            //FadeInPanel(imagePanel);
                            image.GetComponent<Image>().sprite = hit.transform.GetComponent<SpriteRenderer>().sprite;
                        }
                    }
                }
            }
            

        }

        

        

    }

    //public void onClickToImage()
    //{
    //    Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        //Debug.Log(hit.transform.GetComponent<SpriteRenderer>().color.a);
    //        if ((!imagePanel.activeSelf) && (hit.transform.tag == "Image") && (hit.transform.GetComponent<SpriteRenderer>().color.a > 0.9f))
    //        {
    //            //isPanelActive = true;
    //            imagePanel.SetActive(true);
    //            //FadeInPanel(imagePanel);
    //            image.GetComponent<Image>().sprite = hit.transform.GetComponent<SpriteRenderer>().sprite;
    //        }
    //    }
    //}




    //public void SetBoolPanelFalse()
    //{
    //    isPanelActive = false;
    //    Debug.Log("isPanelActive: " + isPanelActive);
    //}

    //private void OnMouseUp()
    //{

    //}

    //public static bool GetBoolPanelFalse()
    //{
    //    return isPanelActive;
    //}

}
