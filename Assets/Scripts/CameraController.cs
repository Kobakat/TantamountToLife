using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target = null;
    [SerializeField]
    float distFromPlayer, height;

    void FixedUpdate()
    {
        StandardStateUpdate();
        
        this.transform.LookAt(target);
    }

    private void StandardStateUpdate()
    {
        Vector3 adjust = new Vector3(transform.position.x, target.position.y + height, transform.position.z);
        transform.position = adjust;

        Vector3 targetPos = target.position + (transform.position - target.position).normalized * distFromPlayer;
        transform.position = targetPos;
    }
}
