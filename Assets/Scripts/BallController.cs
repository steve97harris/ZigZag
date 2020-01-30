using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public bool started;
    public bool gameOver;
    
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        started = false;
        gameOver = false;
    }

    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed,0,0);
                started = true;
            }
        }
        
        // Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0,-25f,0);

            Camera.main.GetComponent<CameraController>().gameOver = true;
        }
        
        if (Input.GetMouseButtonDown(0) && !gameOver) 
        {
                SwitchDirection(); 
        }
        
    }

    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);        // If moving in z direction, switch to x direction. 
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0,0, speed);        // If moving in x direction, switch to z direction. 
        }
    }
}
