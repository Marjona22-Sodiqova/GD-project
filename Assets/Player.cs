
using UnityEngine;
public class Player: MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180; 
    public Transform cameraTransform;
    private Rigidbody rb;
    public float jumpForce = 5f; 
    public float force = 3f;
    private bool isGrounded;
    public float health = 100f;
    private bool create = true;
    public GameManager gm;
    private bool can_move = true;


    public void can_move_set(bool state)
    {
        can_move = state;
    }
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (can_move)
        {
            Move();
            Turn();
            Jump();
        }
        // else
        // {
        //     if (Input.GetKeyDown(KeyCode.Escape))
        //     {
        //         can_move = true;
        //     }
        // }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && create)
        {
            gm.Create_element();
            create = false;
        }
        create = !gm.is_available();
        after_damage();
    }

    void Move()
    {
        float moveDirection = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * moveDirection * moveSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + move);

        // // Vector3 move = input.normalized * speed * Time.fixedDeltaTime;

        // rb.MovePosition(rb.position + new Vector3(move.x, 0, 0));

        // rb.MovePosition(rb.position + new Vector3(0, 0, move.z));
    }

    void Turn()
    {
        float turnDirection = Input.GetAxis("Horizontal");
        float turn = 0;
        if(turnDirection != 0)
        {
            turn = turnDirection * turnSpeed * Time.deltaTime;
            
            
            //cameraTransform.;
        }
        Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
        
    }
    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded=false;
            // Debug.Log("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision  other)
    {
        if (other.gameObject.tag == "Plane")
        {
        isGrounded=true;
        }

    }
    private float invincible_time = 0.5f;
    private bool invincible = false;

    private void after_damage()
    {
        if(invincible && invincible_time > 0)
        {
            invincible_time -= Time.deltaTime;
            // Debug.Log(invincible_time);
        }
        else if (invincible_time <= 0)
        {
            invincible=false;
            invincible_time = 0.5f;
        }
    }

    
    void OnCollisionStay(Collision  other)
    {
        
  
        if (other.gameObject.tag == "Object" && Input.GetKey(KeyCode.Q))
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * force, ForceMode.Impulse);
            }
        else if (other.gameObject.tag == "Enemy")
        {
            if (!invincible)
            {
                health -= other.gameObject.GetComponent<Enemy>().damage;
                // Debug.Log(health);
                invincible = true;
            }

            
        }
    }

}