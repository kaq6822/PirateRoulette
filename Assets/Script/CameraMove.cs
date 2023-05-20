using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 100f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            transform.RotateAround(target.position, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }
}
