using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputHandler ih = null;
    Rigidbody rb = null;
    Animator anim = null;

    Vector2 inputDir;
    
    MovementState movementState;
    
    [SerializeField]
    Camera cam;
    
    [SerializeField]
    float speed, maxSpeed, turnSpeed;


    void Awake() { ih = new InputHandler(); }
    void OnEnable() { ih.Enable(); }
    void OnDisable() { ih.Disable(); }
    
    public enum MovementState
    {
        Standard,
        Target,
        Free,
        FirstPerson
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
    }
    

    void Update()
    {
        inputDir = ih.Standard.Movement.ReadValue<Vector2>();
        Rotate();
    }

    private void FixedUpdate()
    {
        switch(movementState)
        {
            case MovementState.Standard:
                StandardMoveUpdate();
                break;
            case MovementState.Target:
            case MovementState.Free:
            case MovementState.FirstPerson:
                break;                        
        }

        

    }

    //The player only moves forward relative to themselves
    void StandardMoveUpdate()
    {
        Vector3 velocity = Vector3.zero;

        velocity.z = Mathf.Clamp(inputDir.sqrMagnitude, 0.0f, 1.0f) * speed;
        rb.velocity = this.transform.rotation * new Vector3(0.0f, 0.0f, velocity.z) + new Vector3(0.0f, velocity.y, 0.0f);

        //TODO find a better home for animator pieces
        anim.SetFloat("Speed", velocity.sqrMagnitude);
    }

    //Rotates the player relative to camera
    void Rotate()
    {
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        forward = forward.normalized;

        Vector3 look = Quaternion.LookRotation(forward) * new Vector3(inputDir.x, 0.0f, inputDir.y);

        if (look != Vector3.zero)
        {
            Quaternion destRot = Quaternion.LookRotation(look);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, destRot, turnSpeed * Time.deltaTime);
        }
    }
}
