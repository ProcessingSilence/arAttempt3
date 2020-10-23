using UnityEngine;

public class GoAwayPlane : MonoBehaviour
{
    public static class disablePlanes
    {
        public static bool onOff;
    }

    public void Awake()
    {
        disablePlanes.onOff = false;
    }

    public void ChangeStatic(bool onOff)
    {
        disablePlanes.onOff = onOff;
    }
}
