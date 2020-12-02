using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRGazeOptions : VRGazeAbtract
{
    // Start is called before the first frame update
    void Start()
    {
        input = GameObject.FindWithTag("Mitosis");
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
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Mitosis"))
            {
                input.SetActive(false);
                SceneManager.LoadScene(indexScene);
            }
        }
    }
}
