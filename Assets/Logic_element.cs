using UnityEngine;
public class Logic_element : MonoBehaviour
{
    protected  string name = "Logic Gate";
    public string get_name()
    {
        return name;
    }    public bool IsPlaced = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private float set_pos(float x)
    {
        return Mathf.Round(x);
    }

    // Update is called once per frame
    public void Replace(Vector3 pos, float angle)
    {
        // Vector3 pos = new Vector3(set_pos(transform.position.x), set_pos(transform.position.y), set_pos(transform.position.z));
        transform.position = pos;
        transform.rotation *= Quaternion.Euler(0, angle, 0);
    }
}
