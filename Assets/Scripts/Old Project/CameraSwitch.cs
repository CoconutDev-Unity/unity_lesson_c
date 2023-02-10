using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    private Camera mainCameraComponent;
    [SerializeField] private Camera otherCameraComponent;
    [SerializeField] private Score scoreScript;
    public bool isCube = true;

    void Start() {
        mainCameraComponent = GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            otherCameraComponent.depth = 0;
            scoreScript.scoreValue++;
            scoreScript.scoreText.text = "Score: " + scoreScript.scoreValue.ToString();
            isCube = true;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            otherCameraComponent.depth = 1;
            scoreScript.scoreValue++;
            scoreScript.scoreText.text = "Score: " + scoreScript.scoreValue.ToString();
            isCube = false;
        }

    }
}
