using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class third_person_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float speed = 6;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;

    float turnSmoothVelocity;
    bool isGrounded;
    Vector3 velocity;
    // Update is called once per frame
    public void Start()
    {
        Debug.Log ("fuck");
        FindObjectOfType<Timer>().StartTimer();
    }
    void OnCollisionEnter (Collision collisionInfo)
    {   
        if (collisionInfo.collider.tag =="End")
        {
            Debug.Log("FUCK3");
            FindObjectOfType<Timer>().StopTimer();
        }
           
    }
    void Update()
    {   
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Horizontal, 0, Vertical).normalized;
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized  * speed * Time.deltaTime);

            
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y =Mathf.Sqrt(jumpHeight * -2f * gravity ); 
        }
        
    }
}
