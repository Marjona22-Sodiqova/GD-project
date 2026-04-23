using UnityEngine;

public class NOT_logic : Logic_element
{
    public Connect contact1; 
    public Connect contact2; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        name = "NOT";
    }

    // Update is called once per frame

    void Update()
    {
        if (contact1 == null || contact2 == null) return;

        if (contact1.isInput && !contact2.isInput)
        {
            contact2.state = !contact1.state;
        }
        else if (contact2.isInput && !contact1.isInput)
        {
            contact1.state = !contact2.state;
        }
    }
}
