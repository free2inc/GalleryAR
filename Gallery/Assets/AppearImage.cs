
using UnityEngine;

public class AppearImage : MonoBehaviour {

    

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        Color tmp;
        tmp = other.GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        other.GetComponent<SpriteRenderer>().color = tmp;

    }

    private void OnTriggerExit(Collider other)
    {
        

        Color tmp;
        tmp = other.GetComponent<SpriteRenderer>().color;
        tmp.a = 100f;
        other.GetComponent<SpriteRenderer>().color = tmp;
    }
}
