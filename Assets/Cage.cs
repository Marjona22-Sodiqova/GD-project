using UnityEngine;

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class Cage : MonoBehaviour
{
    public Transform door;
    //public bool open=false;
    public bool close=true;
    public TrapTrigger trigger = null;
    // public string text = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (trigger != null)
        {
            // open = trigger.triggered;
            if (trigger.triggered)
            {
                Open();
                // open = false;
                trigger.triggered = false;
            }
            else if (close)
            {
                Close();
                close = false;
            }
        }
        

    }

    public void Open()
    {
        Vector3 move = new Vector3(0, 1, 0);
        Vector3 pos = door.transform.position + move;
        door.DOMove(pos, 2f);

    }
    public void Close()
    {
        Vector3 move = new Vector3(0, -1, 0);
        Vector3 pos = door.transform.position + move;
        door.DOMove(pos, 2f);

    }
}
