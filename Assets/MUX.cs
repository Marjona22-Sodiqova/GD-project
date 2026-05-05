using UnityEngine;

public class MUX_logic : Logic_element
{
    public Connect contact1; 
    public Connect contact2; 
    public Connect contact3; 
    
    public Connect contact4; 

    void Start()
    {
        set_tag();
        Name = "MUX";
        contact1.isInput = true;
        contact2.isInput = true;
        contact3.isInput = false;
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
        state = (contact1.state && contact4.state) || (contact2.state && contact4.state);
        contact3.state = state;
    }
}
