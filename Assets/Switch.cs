using UnityEngine;

public class Switch : Logic_element
{
    public Connect contact; 
    public bool state = false;
    void Start()
    {
        name = "SWITCH";
    }

    // Update is called once per frame

    void Update()
    {
        if (contact == null) return;

        contact.state = state;
    }
}
