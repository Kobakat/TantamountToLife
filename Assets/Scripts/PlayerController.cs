using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private data fields
    InputHandler ih = null;
    Rigidbody rb = null;
    Animator anim = null;
    Collider col = null;

    Vector2 inputDir;
    #endregion

    #region Serialized data fields
    [SerializeField]
    PhysicMaterial stopPhysicsMat, movePhysicsMat;

    [SerializeField]
    float speed, maxSpeed, turnSpeed;
    #endregion

    private void Awake()
    {
        ih = new InputHandler();
    }
    void Start()
    {   
        rb = this.GetComponent<Rigidbody>();
        col = this.GetComponent<Collider>();
    }
    private void OnEnable()
    {
        ih.Enable();
    }

    private void OnDisable()
    {
        ih.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        inputDir = ih.Standard.Movement.ReadValue<Vector2>();
        col.material = inputDir.sqrMagnitude > 0 ? movePhysicsMat : stopPhysicsMat;
    }

    void FixedUpdate()
    {
        Vector3 inputDirV3 = new Vector3(inputDir.x, 0, inputDir.y);
        inputDirV3 = inputDirV3.normalized;

        if (rb.velocity.sqrMagnitude < maxSpeed)
            rb.AddForce(inputDirV3 * speed, ForceMode.Acceleration);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

   
}
