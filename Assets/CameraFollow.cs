
using UnityEngine;

public class CameraFollow: MonoBehaviour
{
    public Transform target;
    private Vector3[] offsets;
    private int options;
    public int currentOffset = 0;
    public float smoothSpeed = 0.125f;

    void Start()
    {
        offsets = new  Vector3[]{
        new Vector3(0f, 1.5f, -3.5f),
        new Vector3(0f, 0.5f, 0f),
        new Vector3(0f, 2.5f, 0f),
        };
        options = offsets.Length;
    }

    void LateUpdate()
    {

        Vector3 desiredPosition = target.position + offsets[currentOffset];
        // if (currentOffset == 0)
        // {
        //     Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); 
        // //ransform.position= smoothedPosition;
        // }
        
        transform.localPosition = offsets[currentOffset];
        if (currentOffset != 1) transform.LookAt(target);
        else transform.localRotation  = Quaternion.Euler(10, 0, 0);
    }
}