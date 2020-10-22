using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupHUD : MonoBehaviour
{
    private RawImage _rawImage;
    public static class CurrentState
    {
        public static bool spriteEnable;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        _rawImage.enabled = CurrentState.spriteEnable;
    }
}
