using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRGazeMenu : MonoBehaviour
{
    public Image imgGaze;

    public float totalTime = 2;
    public bool gvrStatus;
    public float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;

    public int indexScene;
    public static GameObject input;

    // Start is called before the first frame update
    void Start()
    {
        input = GameObject.FindWithTag("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if (gvrStatus)
            {
                gvrTimer += Time.deltaTime;
                imgGaze.fillAmount = gvrTimer / totalTime;
            }
        }

        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Start"))
            {
                input.SetActive(false);
                SceneManager.LoadScene(indexScene);
            }
        }
    }

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
