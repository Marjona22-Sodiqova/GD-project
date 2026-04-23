
using UnityEngine;
public class Enemy: MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 360; 
    private Rigidbody rb;
    public TerritoryChecker territoryChecker ;
    private float health = 200f;
    public float damage = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (territoryChecker.hunt)
        {
            Move(1f);
            Turn(Vector3.Angle(transform.forward, territoryChecker.target));
        }
        
    }

    void Move(float direct)
    {
        Vector3 move = transform.forward * direct * moveSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + move);

        // // Vector3 move = input.normalized * speed * Time.fixedDeltaTime;

        // rb.MovePosition(rb.position + new Vector3(move.x, 0, 0));

        // rb.MovePosition(rb.position + new Vector3(0, 0, move.z));
    }

    void Turn(float direct)
    {
        Quaternion turnRotation = Quaternion.Euler (0f, direct, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
        //cameraTransform.;
    }
    // void Jump()
    // {
    //     if (isGrounded && Input.GetKeyDown(KeyCode.Space))
    //     {
    //         isGrounded=false;
    //         // Debug.Log("Jump");
    //         rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //     }
    // }

    
    

}