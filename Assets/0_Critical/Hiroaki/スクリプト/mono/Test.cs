using UnityEngine;

public class Test:MonoBehaviour
{
    public Transform target;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 b = target.position;
            b.z += 0.05f;
            target.position = b;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 b = target.position;
            b.z -= 0.05f;
            target.position = b;
        }
    }
}
