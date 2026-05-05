using UnityEngine;

public class DMUX_logic : Logic_element
{
    public Connect contact1; 
    public Connect contact2; 
    public Connect contact3; 
    
    public Connect contact4; 

    void Start()
    {
        set_tag();
        Name = "DMUX";
        contact1.isInput = false;
        contact2.isInput = false;
        contact3.isInput = true;
        contact4.isInput = true;
        
    }

    // Update is called once per frame

    void Update()
    {
        // if (contact1 == null || contact2 == null || contact3 == null) return;

        // if (contact1.isInput && contact2.isInput && !contact3.isInput)
        // {
        //     contact3.state = contact1.state && contact2.state;
        // }
        state = contact3.state;
        contact1.state = contact4.state && !state;
        contact2.state = contact4.state && state;
    }
}
