using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private CameraSwitch cameraScript;
    public int scoreValue = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: " + scoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (cameraScript.isCube) {
                scoreValue++;
                scoreText.text = "Score: " + scoreValue.ToString();
        }
            

            if (scoreValue != 10) {
                scoreText.color = Color.black;
            }
            else {
                scoreText.color = Color.white;
            }
        }
    }
}
