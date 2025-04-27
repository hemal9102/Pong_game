using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public static Ball  Instance{get;private set;}
    private void Awake()
    {

        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private GameManager GameManager;
    public float speed;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    // Update is called once per frame
    void Launch()
    {
        float x = Random.Range(-7, 7);
        float y = Random.Range(4, -4);
        Vector2 direction = new Vector2(x, y).normalized;
        rb.linearVelocity = direction*speed;
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") && collision.gameObject.CompareTag("Board")
            )
        {
            
                //to make bouce back i have to add speed
                speed += 0.22f;
                rb.linearVelocity = rb.linearVelocity.normalized * speed;
            
        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftGoal")  )
        {
            GameManager.Instance.AddScore("Left");
            ResetBall();
        }
        if (collision.gameObject.CompareTag("RightGoal"))
        {
            GameManager.Instance.AddScore("Right");
            ResetBall();
        }
     }
    public void ResetBall()
    {
        transform.position = Vector2.zero;
        Invoke(nameof(Launch), 3f);
    }
    
}
