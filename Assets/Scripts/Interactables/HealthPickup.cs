using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] float angularSpeed = 30;
    [SerializeField] float linearSpeed = 2;
    [SerializeField] float heightClamp = 3;

    float origin;

    void Start()
    {
        origin = this.transform.position.y;
    }
    void Update()
    {
        //Position
        this.transform.position = new Vector3(
            this.transform.position.x,
            origin + (Mathf.Sin(linearSpeed * Time.time) / heightClamp),
            this.transform.position.z);

        //Rotation
        this.transform.rotation = Quaternion.AngleAxis(angularSpeed * Time.time, Vector3.up);
    }
}
