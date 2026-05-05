using UnityEngine;


public class Bullet : MonoBehaviour
{
    private bool starTimer = false;
    private float current = 2.5f;
    public float damage = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DeathTimer();
    }
    void DeathTimer()
    {
        if (starTimer)
        {
            current -= Time.deltaTime;
            if (current <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Enemy")
        {
            other.collider.GetComponent<Enemy>().health -= damage;
            Destroy(gameObject);
        }
        else
        {
            starTimer = true;
        }
    }
}
