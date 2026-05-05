using UnityEngine;

public class Connect : MonoBehaviour
{
    public bool state = false;
    public bool isInput = true;
    public Renderer rend;
    public Material onMat;
    public Material offMat;

    public Light lightComp;
    // public bool isWire = false;
    // public bool isConnected = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightComp.enabled = false;
        // set_tag();
        // Name = "Source";
        
    }

    public void changeColor()
    {
        rend.material = isInput ? onMat : offMat;
        if (isInput)
        {
            
            //rend.material.SetColor("_BaseColor", Color.red);
            //Debug.Log("Change");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //lightComp.enabled = state; 
        changeColor();
    }

    // bool IsTouching()
    // {
    //     return Physics.CheckSphere(transform.position, 1f);
    // }



    // IEnumerator CheckContact()
    // {
    //     while (true)
    //     {
    //         if (IsTouching())
    //         {
    //             Debug.Log("Контакт есть");
    //         }

    //     yield return null;
    //     }
    // }

    // void OnTriggerStay(Collider other)
    // {
    //     Connect otherConnect;
    //     Wire3 otherConnect2;
    //     otherConnect = other.GetComponentInParent<Connect>();

    //     if (otherConnect != null)
    //     {
            
    //         // if (!isWire)
    //         // {
                
    //         //     if ((!otherConnect.isInput || !otherConnect.isWire) && isInput)
    //         //     {
    //         //         state = otherConnect.state;
    //         //         //return;
    //         //     }
    //         // }
    //         // else
    //         // {
    //         //     if (otherConnect.isWire && otherConnect.isConnected)
    //         //     {
    //         //         state = otherConnect.state && otherConnect.state;
    //         //         //return;
    //         //     }
    //         //     else if (!otherConnect.isWire)
    //         //     {
    //         //         isConnected = true;
    //         //         state = otherConnect.state && otherConnect.state;
    //         //     }
    //         // }
    //         if (!otherConnect.isInput && isInput)
    //         {
    //             state = otherConnect.state;
    //             //return;
    //         }
            
    //        // Debug.Log("Connect");
    //     }
    //     else if ((otherConnect2 = other.GetComponent<Wire3>()) != null)
    //     {
    //         if (isInput)
    //         {
    //             state = otherConnect2.getState().state;
    //             //return;
    //         }
    //     }
    //     //else isConnected = false;
    // }

    // void OnTriggerExit(Collider other)
    // {
    //     Connect otherConnect = other.GetComponentInParent<Connect>();

    //     if (otherConnect != null && !otherConnect.isWire)
    //     {
    //         isConnected = false;
    //     }
    // }

    // void OnTriggerStay(Collider other)
    // {
    //     Connect otherConnect = other.GetComponentInParent<Connect>();
    //     Wire3 wire = other.GetComponent<Wire3>();

    //     // от другого контакта
    //     if (otherConnect != null)
    //     {
    //         if (!otherConnect.isInput && isInput)
    //         {
    //             state = otherConnect.state;
    //         }
    //     }
    //     // от провода
    //     else if (wire != null && isInput)
    //     {
    //         state = wire.GetSignal();
    //     }
    // }
    void OnTriggerStay(Collider other)
    {
    Connect otherConnect = other.GetComponentInParent<Connect>();

        if (otherConnect != null)
        {
            if (!otherConnect.isInput && isInput)
            {
                state = otherConnect.state;
            
            }
           // Debug.Log("Connect");
        }
    }
    void OnTriggerExit(Collider other)
    {
        Connect otherConnect = other.GetComponentInParent<Connect>();

        if (otherConnect != null)
        {
            state = false;
        }
    }
}
