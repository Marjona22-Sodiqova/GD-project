using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BinaryPanel : MonoBehaviour
{
    public Text textA;
    public Text textB;
    public Text textOp;
    public InputField input;
    public Inventory receiver;
    public bool isDone = true;
    
    // public void setreseiver(Inventory player)
    // {
    //     receiver = player;
    // }

    BinaryTask task = new BinaryTask();

    // void Start()
    // {
    //     NewTask();
    // }
    void OnEnable()
    {
        isDone = false;
        NewTask();
    }

    public void NewTask()
    {
        task.Generate(4);

        textA.text = task.GetBinary(task.A);
        textB.text = task.GetBinary(task.B);
        textOp.text = task.isAdd ? "+" : "-";

        input.text = "";
    }
    public void Check()
    {
    string user = input.text;

    int userValue;

    try
    {
        userValue = System.Convert.ToInt32(user, 2);
    }
    catch
    {
        Debug.Log("Error");
        return;
    }

    if (userValue == task.result)
    {
        Debug.Log("Correct!");
        //NewTask();
        Inventory prise = new Inventory(); 
        prise.RandamLoot();
        prise.Transact(receiver);
        isDone = true;
        gameObject.SetActive(false);
    }
    else
    {
        Debug.Log("Incorrect!");
    }
}
}