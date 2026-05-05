using UnityEngine;

public class Switch : Logic_element
{
    public bool isLever = true;
    public Connect contact; 
    public Button button;
    void Start()
    {
        set_tag();
        Name = "SWITCH";
        contact.isInput = false;
    }

    // Update is called once per frame

    void Update()
    {
        if (isLever) state = button.state;

        contact.state = state;
    }
}
