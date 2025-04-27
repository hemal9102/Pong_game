    using JetBrains.Annotations;
    using UnityEngine;
    //using UnityEngine.Windows;

    public class Paddle1 : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public float speed = 5f;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {

            float move = 0;
            if (Input.GetKey(KeyCode.W))
            {
                move = speed * Time.deltaTime;
                transform.Translate(0, move, 0);

            }
            if (Input.GetKey(KeyCode.S))
            {
                move = -speed * Time.deltaTime;
                transform.Translate(0, move, 0);
            }

        }
    }
