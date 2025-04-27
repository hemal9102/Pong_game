using UnityEngine;

public class Paddle2 : MonoBehaviour
{
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move = speed * Time.deltaTime;
            transform.Translate(0, move, 0);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move = -speed * Time.deltaTime;
            transform.Translate(0, move, 0);
        }

    }
}
