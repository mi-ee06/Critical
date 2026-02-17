using UnityEngine;

public class move : MonoBehaviour
{
    public float jumpPower = 5f;
    public float speed = 10f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //ÉWÉÉÉìÉv
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        //âEÇ…ìÆÇ≠
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
        }
        //ç∂Ç…ìÆÇ≠
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed, ForceMode.Impulse);
        }
    }
}
