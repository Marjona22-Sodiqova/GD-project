using UnityEngine;

public class Button : MonoBehaviour
{
    public bool isPushable = true;
    public bool state = false;
    public string Name = "Button";


    // Update is called once per frame
    public void push()
    {
        if(isPushable) state = !state;
    }
    void Update()
    {
        
    }
}
