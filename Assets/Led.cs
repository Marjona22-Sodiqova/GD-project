using UnityEngine;

public class Led : Logic_element
{
    public Light lightComp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        set_tag();
        Name = "LED";
    }

    // Update is called once per frame
    void Update()
    {
        lightComp.enabled = state; 
    }

    // bool IsTouching()
    // {
    //     return Physics.CheckSphere(transform.position, 1f);
    // }



    // IEnumerator CheckContact()
    // {
    //     while (true)
    //     {
    //         if (IsTouching())
    //         {
    //             Debug.Log("Контакт есть");
    //         }

    //     yield return null;
    //     }
    // }

    void OnTriggerStay(Collider other)
    {
    Connect otherConnect = other.GetComponentInParent<Connect>();

        if (otherConnect != null)
        {
            if (!otherConnect.isInput)
            {
                state = otherConnect.state;
            
            }
           // Debug.Log("Connect");
        }
    }
    void OnTriggerExit(Collider other)
    {
        Connect otherConnect = other.GetComponentInParent<Connect>();

        if (otherConnect != null)
        {
            state = false;
        }
    }
}
