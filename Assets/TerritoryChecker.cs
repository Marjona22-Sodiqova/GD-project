
using UnityEngine;
public class TerritoryChecker: MonoBehaviour
{
    public float radius = 5f;
    public bool hunt = false;

    public Vector3 target = Vector3.zero;

    private float minRad;
    
    void Awake()
    {
        minRad = radius+1;
        
    }
    void OnDrawGizmos(){
        transform.localScale = new Vector3(radius, radius, radius);
    }

    void OnTriggerStay(Collider other)
    {
        GameObject newtarget = other.gameObject;
        Vector3 direct = newtarget.transform.position-transform.position;
        if (newtarget.tag == "Player") // && direct.magnitude <= radius
        {
            // if (direct.magnitude < minRad)
            // {
                
            // }
            // else
            // {
                
            // }
            minRad = direct.magnitude;
            target = direct;
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        GameObject newtarget = other.gameObject;
        if (newtarget.tag == "Player")
        {
            hunt = false;
            minRad = radius + 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject newtarget = other.gameObject;
        Vector3 direct = newtarget.transform.position-transform.position;
        if (newtarget.tag == "Player")
        {
            hunt = true;
            target = direct;
        }
    }
}