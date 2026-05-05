using UnityEngine;

public class OR_logic : Logic_element
{
    public Connect contact1; 
    public Connect contact2; 
    public Connect contact3; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
    {
        set_tag();
        Name = "OR";
        contact1.isInput = true;
        contact2.isInput = true;
        contact3.isInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (contact1 == null || contact2 == null || contact3 == null) return;

        // if (contact1.isInput && contact2.isInput && !contact3.isInput)
        // {
        //     contact3.state = contact1.state || contact2.state;
        // }
        contact3.state = contact1.state || contact2.state;
    }
}
