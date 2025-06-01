using UnityEngine;

public class Mover : MonoBehaviour
{
    public Rigidbody body;
    void Start()
    {
        InvokeRepeating("Tic", 1f, 0.05f);
    }
    public void Tic()
    {
        body.AddForce(transform.forward,ForceMode.VelocityChange);
        transform.Rotate(0,Input.GetAxisRaw("Horizontal")*15,0);
    }
}
