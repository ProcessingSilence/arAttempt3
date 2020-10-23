using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DisablePlaneView : MonoBehaviour
{
    [SerializeField] private bool isManagerOrPlane;
    // Update is called once per frame
    void Update()
    {
        if (GoAwayPlane.disablePlanes.onOff)
        {
            if (isManagerOrPlane)
            {
                gameObject.GetComponent<ARPlane>().enabled = false;
                gameObject.GetComponent<ARPlaneMeshVisualizer>().enabled = false;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<LineRenderer>().enabled = false;
                gameObject.GetComponent<DisablePlaneView>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<ARPlaneManager>().enabled = false;
           }

            gameObject.GetComponent<DisablePlaneView>().enabled = false;
        }
    }
}
