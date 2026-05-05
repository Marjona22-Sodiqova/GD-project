using UnityEngine;

public class Wire : Logic_element
{
    public Connect contact1; 
    public Connect contact2; 
    void Start()
    {
        set_tag();
        Name = "WIRE";
        contact1.isInput = true;
        contact1.state = false;
        contact2.isInput = false;
        contact2.state = false;
        // contact1.changeColor();
        // contact2.changeColor();
    }

    void Update()
    {
        // if(contact2.isConnected || contact1.isConnected)
        // {
        //     if (contact2.isInput && contact1.isInput)
        //     {
        //         //contact1.state = contact2.state;
        //         if(contact1.state && contact2.state) return;
        //         else if (contact2.state || contact1.state)
        //         {
        //             contact2.isInput = contact2.state;
        //             contact1.isInput = contact1.state;
        //         }
        //     }
            
        //     if (contact1.isInput && !contact2.isInput) contact2.state = contact1.state;
        //     else if (contact2.isInput && !contact1.isInput) contact1.state = contact2.state;  
            
        // }
        // else if (!contact2.isConnected && !contact1.isConnected) 
        // {
        //     contact2.isInput = true;
        //     contact1.isInput = true;
        // }  
        // if (contact1.isConnected && !contact2.isConnected)
        // {
        //     contact1.isInput = true;
        //     contact2.isInput = false;
        //     contact2.state = contact1.state;
        // }
        
        // else if (contact2.isConnected && !contact1.isConnected)
        // {
        //     contact2.isInput = true;
        //     contact1.isInput = false;
        //     contact1.state = contact2.state;
        // } 
        
        // else if (contact1.isConnected && contact2.isConnected)
        // {
        //     bool signal = contact1.state || contact2.state;
        //     contact1.state = signal;
        //     contact2.state = signal;
        // }
        // else
        // {
        //     contact1.state = false;
        //     contact2.state = false;
        // }
        state = contact1.state; 
        contact2.state = state;

    }
    //public bool state=false;

    // void OnTriggerStay(Collider other)
    // {
    //     Connect otherConnect = other.GetComponentInParent<Connect>();

    //     if (otherConnect != null)
    //     {
    //         if (!otherConnect.isInput)
    //         {
    //             state = otherConnect.state;
    //             //return;
    //         }
    //        // Debug.Log("Connect");
    //     }
    //     //else isConnected = false;
    // }
}
