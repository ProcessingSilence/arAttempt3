/*
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Camera cam;
    public Transform camPos;
    public Vector3 offset;
    private void Update()
    {

        
        if (Input.touchCount > 0)
        {
            offset = Input.GetTouch(0).position;
            Debug.Log("click");
        }
        transform.position = new Vector3(offset.x*.001f, offset.y*.001f, 0.4f) + camPos.position;
        transform.rotation = camPos.rotation;
        Debug.Log(transform.position);
    }
}
*/