using UnityEngine;

public class FullSum : Logic_element
{
    public Connect contact1; 
    public Connect contact2; 
    public Connect contact3; 
    
    public Connect contact4;
    public Connect contact5; 

    void Start()
    {
        set_tag();
        Name = "FullSum";
        contact1.isInput = true;
        contact2.isInput = true;
        contact3.isInput = false;
        contact4.isInput = true;
        contact5.isInput = false;
        
    }

    // Update is called once per frame

    void Update()
    {
        // if (contact1 == null || contact2 == null || contact3 == null) return;

        // if (contact1.isInput && contact2.isInput && !contact3.isInput)
        // {
        //     contact3.state = contact1.state && contact2.state;
        // }
        state = !(contact1.state && contact2.state) && (contact1.state || contact2.state);
        bool c = state && contact4.state;
        state = !(state && contact4.state) && (state || contact4.state);
        contact3.state = state;
        contact5.state = (contact1.state && contact2.state) || c;
    }
}
