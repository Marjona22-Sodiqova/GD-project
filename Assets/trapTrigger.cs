using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public bool triggered = false;
    public bool MathTrap = false;
    private Screen_Manager SM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void set_SM(Screen_Manager s)
    {
        SM = s;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !triggered)
        {
            triggered = true;
            if (MathTrap && SM != null)
            {
                Debug.Log("Math task");
                SM.OpenTask();
            }
        }
    }
}
