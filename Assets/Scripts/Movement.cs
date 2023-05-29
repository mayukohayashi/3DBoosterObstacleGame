using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 1000f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
        {
            if(Input.GetKey(KeyCode.Space))
            {
                // Debug.Log("Space pressed");

                rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            }
        }

        void ProcessRotation()
        {
            // if (Input.GetKey(KeyCode.W))
            // {
            //     transform.Translate(Vector3.forward * Time.deltaTime);
            // }
            // if (Input.GetKey(KeyCode.S))
            // {
            //     transform.Translate(Vector3.back * Time.deltaTime);
            // }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // Debug.Log("Left Arrow pressed");
                ApplyRotation(rotationThrust);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                // Debug.Log("Right Arrow pressed");
                ApplyRotation(- rotationThrust);
            }

            void ApplyRotation(float rotationFrame)
            {
                transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
            }

        }
}
