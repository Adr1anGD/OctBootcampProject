using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float sprintSpeed = 20.0f;
    public bool isSprintSpeedActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForSprint();
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(transform.forward * -1 * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
    }

    private void CheckForSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprintSpeedActive = true;
        }
        else
        {
            isSprintSpeedActive = false;
        }

        if (isSprintSpeedActive == true)
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = 10.0f;
        }
    }
}