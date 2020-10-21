using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// Credit because I was struggling a bit on getting object placement working:
// https://tutorialsforar.com/how-to-use-plane-tracking-in-ar-and-place-objects-using-unity/

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{
   [SerializeField]
   private GameObject placeablePrefab;
   [SerializeField]
   private ARRaycastManager _arRaycastManager;
   
   static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

   private void Awake()
   {
      _arRaycastManager = GetComponent<ARRaycastManager>();
      placeablePrefab = Instantiate(placeablePrefab, Vector3.zero, Quaternion.identity);
   }

   bool TryGetTouchPos(out Vector2 touchPos)
   {
      if (Input.touchCount > 0)
      {
         touchPos = Input.GetTouch(0).position;
         return true;
      }
      touchPos = default;
      return false;
   }

   private void Update()
   {
      if (!TryGetTouchPos(out Vector2 touchPos))
      {
         return;
      }

      if (_arRaycastManager.Raycast(touchPos, s_Hits, TrackableType.PlaneWithinPolygon))
      {
         var hitPos = s_Hits[0].pose;

            placeablePrefab.transform.position = hitPos.position;
            placeablePrefab.transform.rotation = hitPos.rotation;         
      }
   }

}
