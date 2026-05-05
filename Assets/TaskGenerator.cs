using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskGenerator : MonoBehaviour
{
    public bool isDone =false;
    public GameObject input;
    public GameObject output;
    public Button btn;
    private List<Switch> inputs = new List<Switch>();
    private List<Led> outputs = new List<Led>();
    private bool[,] given_inputs = {{true, true, true, true, true, true, true, true}};
    private bool[,] given_outputs = {{true, true, true, true}};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float start = -( 0.125f + 3*0.25f);
        for (int i = 0; i<8; i++)
        {
            GameObject gm = Instantiate(input, transform);
            gm.transform.localPosition = new Vector3(0.95f, 0.1f, start); 
            Switch sw = gm.GetComponent<Switch>();
            sw.isLever = false;
            sw.state=false;
            sw.isChangable=false;
            inputs.Add(sw);
            start += 0.25f; 
        }
        start = -(0.2f + 1*0.4f);
        for (int i = 0; i<4; i++)
        {
            GameObject gm = Instantiate(output, transform);
            gm.transform.localPosition = new Vector3(-0.9f, 0.1f, start);
            
            Led ld = gm.GetComponent<Led>();
            ld.isChangable=false;
            outputs.Add(ld);
            start += 0.4f;
        }
    }
    private int j=0;
    private bool result = true;
    // bool Checker()
    // {
    //     for (int j =0; j<=8; j++)
    //     {
    //         for (int i =0; i<=8; i++)
    //         {
    //             inputs[i].state = given_inputs[i];
    //         }
    //     }
    // }

    private bool isfinished = true;
    IEnumerator MyRoutine()
    {
        for(j=0; j< given_inputs.GetLength(0); j++)
        {
            for (int i =0; i<8; i++)
            {
                inputs[i].state = given_inputs[j,i];
            }

            yield return new WaitForSeconds(1f);

            Debug.Log("Прошло 2 секунды");
            for (int i =0; i<4; i++)
                {
                    if (outputs[i].state != given_outputs[j,i]) result = false;
                }
            if (!result)
            {
                
                break;
            }
            
            
        }
        if(result) isDone=true;
        isfinished = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (btn.state && isfinished)
        {
            isfinished = false;
            result = true;
            StartCoroutine(MyRoutine());
            btn.state = false;
        }
    }
}
