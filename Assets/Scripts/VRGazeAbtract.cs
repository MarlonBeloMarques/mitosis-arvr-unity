using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class VRGazeAbtract : MonoBehaviour
{
    public Image imgGaze;

    public float totalTime = 2;
    public bool gvrStatus;
    public float gvrTimer;

    public int distanceOfRay = 10;
    protected RaycastHit _hit;

    public int indexScene;
    public static GameObject input;

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}
