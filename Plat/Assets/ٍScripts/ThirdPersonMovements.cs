using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovements : MonoBehaviour
{

    [SerializeField] float speed;
    CharacterController controller;

    [SerializeField] float turnSmooth = 0.1f;

    [SerializeField] Transform camera;

    float turnSmoothVelocity;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"),
            0f, Input.GetAxisRaw("Vertical")).normalized;

        if(direction.magnitude > 0.1f)
        {
            float targetAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref turnSmoothVelocity,turnSmooth);
            transform.rotation = Quaternion.Euler(0f, angel, 0f);


            Vector3 moveDirection = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

    }
}
