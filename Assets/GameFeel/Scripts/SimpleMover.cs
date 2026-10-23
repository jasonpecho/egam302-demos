using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleMover : MonoBehaviour
{
    public float speed = 6f;
    public float jumpHeight = 1.5f;
    public float gravity = -20f;

    CharacterController controller;
    float yVelocity;
    float lastGroundedTime = -1f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = Vector3.ClampMagnitude(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")), 1.0f) * speed;

        Camera mainCam = Camera.main;

        //move = (mainCam.transform.right * move.x) + (mainCam.transform.forward * move.z);
        //move = mainCam.transform.rotation * move;
        //move = mainCam.transform.TransformDirection(move);
        move = Quaternion.Euler(0f,mainCam.transform.eulerAngles.y,0f) * move;

        if (controller.isGrounded)
        {
            lastGroundedTime = Time.time;
            if (yVelocity < 0f) yVelocity = -2f;
        }

        if (Input.GetButtonDown("Jump") && Time.time - lastGroundedTime < 0.1f)
        {
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            lastGroundedTime = -1f;
        }

        yVelocity += gravity * Time.deltaTime;
        move.y = yVelocity;
        controller.Move(move * Time.deltaTime);
    }
}