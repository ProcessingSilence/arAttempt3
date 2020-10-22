using UnityEngine;

public class RotateForever : MonoBehaviour
{
    public float rotateSpeed;

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate (0,rotateSpeed * Time.deltaTime,0);
    }
}
