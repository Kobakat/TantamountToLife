using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private class instances
    InputHandler ih = null;
    Rigidbody rb = null;
    Animator anim = null;
    #endregion

    #region Serialized data fields
    [SerializeField]
    float speed;
    #endregion

    void Start()
    {
        ih = new InputHandler();
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v2Input = ih.Standard.Movement.ReadValue<Vector2>();
        v2Input = v2Input.normalized;
        Vector3 v3Input = new Vector3(v2Input.x, 0, v2Input.y);

        rb.AddForce(v3Input * this.speed * Time.deltaTime, ForceMode.Acceleration);

        anim.SetFloat("Speed", v2Input.sqrMagnitude);
    }
}
