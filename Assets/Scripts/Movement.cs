using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbodyRocket;
    AudioSource audioSource;
    
    [SerializeField]
    float mainThrust = 1000;
    [SerializeField]
    float rotationSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyRocket = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbodyRocket.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

            if(!audioSource.isPlaying){
            audioSource.Play();
            }
            
        } else {
            audioSource.Stop();
        }
    }
    

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rigidbodyRocket.freezeRotation = true; // freezing rotation so the object can be manually rotated
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidbodyRocket.freezeRotation = false; // unfreezing rotation so the physics system can take over 
    }
}
