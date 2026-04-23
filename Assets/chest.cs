using UnityEngine;
using DG.Tweening;

public class chest : MonoBehaviour
{
    public Transform open1;
    public Transform open2;
    public bool close=true;
    private bool state = false;
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
        // if (!close && !state)
        // {
        //     Open();
        //     state = true;
        // }
        // else if (close && state)
        // {
        //     Close();
        //     state = false;
        // }
    }
    public void Open()
    {
        Vector3 move = new Vector3(0, 0, 90);
        Vector3 angle1 = open1.eulerAngles + move;
        Vector3 angle2 = open2.eulerAngles + move;
        open1.DORotate(angle1, 2f);
        open2.DORotate(angle2, 2f);

    }
    public void Close()
    {
        Vector3 move = new Vector3(0, 0, -90);
        Vector3 angle1 = open1.eulerAngles + move;
        Vector3 angle2 = open2.eulerAngles + move;
        open1.DORotate(angle1, 2f);
        open2.DORotate(angle2, 2f);

    }
}
