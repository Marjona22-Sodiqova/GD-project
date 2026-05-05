using UnityEngine;

public class NOT_logic : Logic_element
{
    public Connect contact1; 
    public Connect contact2; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        set_tag();
        Name = "NOT";
        contact1.isInput = true;
        contact2.isInput = false;

    }

    // Update is called once per frame

    void Update()
    {

        // if (contact1.isInput && !contact2.isInput)
        // {
        //     contact2.state = !contact1.state;
        // }
        // else if (contact2.isInput && !contact1.isInput)
        // {
        //     contact1.state = !contact2.state;
        // }
        state = !contact1.state;
        contact2.state = state;
    }
}
