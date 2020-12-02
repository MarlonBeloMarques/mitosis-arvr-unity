using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRGazeMenu : VRGazeAbtract
{
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
}
