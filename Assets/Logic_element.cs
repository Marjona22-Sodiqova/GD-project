using UnityEngine;

public class Logic_element : MonoBehaviour
{
    private TextMesh textMesh = new TextMesh();
    public bool state = false;
    public  string Name = "Logic Gate";
    public bool isChangable = true;
    private BoxCollider box;
    void Awake()
    {
       box = GetComponent<BoxCollider>();
        box.isTrigger = true;
    }
    public void set_tag()
    {
         GameObject textObj = new GameObject("StateText");
        textObj.transform.SetParent(transform);
        textObj.transform.localPosition = new Vector3(0, 1f, 0);
        
        textObj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        textMesh = textObj.AddComponent<TextMesh>();
        textMesh.color = Color.black;
        textMesh.text = "";
        //textMesh.gameObject.SetActive(false);
        gameObject.tag = "Logic Element";
        // for (int i = transform.childCount - 1; i >= 0; i--)
        // {
        //     transform.GetChild(i).gameObject.tag = 
        // }
    }
    // public string get_name()
    // {
    //     return name;
    // }
    public bool IsPlaced = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        set_tag();
    }

    private float set_pos(float x)
    {
        return Mathf.Round(x);
    }


    public void Replace(Vector3 pos, float angle)
    {
        // Vector3 pos = new Vector3(set_pos(transform.position.x), set_pos(transform.position.y), set_pos(transform.position.z));
        transform.position = pos;
        transform.rotation *= Quaternion.Euler(0, angle, 0);
    }
    public void showState(Transform to)
    {
        // textMesh.gameObject.SetActive(true);
        textMesh.text = state.ToString();
        textMesh.transform.LookAt(to);
        textMesh.transform.Rotate(0, 180, 0);
        //Debug.Log("on top");
        // textMesh.gameObject.SetActive(false);
    }
    void FixedUpdate()
    {
        showState(Camera.main.transform);
    }
    // public IEnumerator ShowRoutine(Transform to)
    // {
    //     textMesh.gameObject.SetActive(true);
    //     textMesh.text = state.ToString();

    //     textMesh.transform.LookAt(to);

    //     yield return new WaitForSeconds(2f);

    //     textMesh.gameObject.SetActive(false);
    // }
}