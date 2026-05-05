using System.Collections.Generic;
using UnityEngine;

public class Wire3 : Logic_element
{
    private List<Connect> contacts = new List<Connect>();

    public bool showSignal = false;

    void Start()
    {
        set_tag();
        Name = "WIRE";
    }

    void Update()
    {
        bool hasSignal = false;

        foreach (var c in contacts)
        {
            if (c == null) continue;

            // только выходы дают сигнал
            if (!c.isInput && c.state)
            {
                hasSignal = true;
                break;
            }
        }

        showSignal = hasSignal;
    }

    public bool GetSignal()
    {
        return showSignal;
    }

    void OnTriggerEnter(Collider other)
    {
        Connect c = other.GetComponentInParent<Connect>();

        if (c != null && !contacts.Contains(c))
        {
            contacts.Add(c);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Connect c = other.GetComponentInParent<Connect>();

        if (c != null)
        {
            contacts.Remove(c);
        }
    }
}