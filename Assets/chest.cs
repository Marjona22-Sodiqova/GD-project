using UnityEngine;
using DG.Tweening;

public class chest : MonoBehaviour
{
    public Transform open1;
    public Transform open2;
    public bool close=true;
    private bool state = false;
    public Inventory inventory = new Inventory();
    private bool isAnimating = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inventory.RandamLoot();
    }

    // Update is called once per frame
    void Update()
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
        // if (rotateTween1 != null) stop = rotateTween1.IsComplete();
    }
    Tween rotateTween1;
    // private Tween rotateTween2;
    public void changeState()
    {
        if (isAnimating) return;

        close = !close;

        if (!close)
            Open();
        else
            Close();
        
    }
    void FixedUpdate()
    {
        
        
    }
    public void Open()
    {
        isAnimating = true;

        Vector3 move = new Vector3(0, 0, 90);

        open1.DORotate(open1.eulerAngles + move, 2f);
        open2.DORotate(open2.eulerAngles + move, 2f)
            .OnComplete(() =>
            {
                isAnimating = false;
                state = true;
            });

    }
    public void Close()
    {
        isAnimating = true;

        Vector3 move = new Vector3(0, 0, -90);

        open1.DORotate(open1.eulerAngles + move, 2f);
        open2.DORotate(open2.eulerAngles + move, 2f)
            .OnComplete(() =>
            {
                isAnimating = false;
                state = false;
            });
    }
}
