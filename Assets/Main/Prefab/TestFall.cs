using UnityEngine;

public class TestFall : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Debug.Log(rb.useGravity);
        Debug.Log(rb.isKinematic);
    }
}