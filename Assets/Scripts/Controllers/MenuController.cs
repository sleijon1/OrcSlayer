using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Text highScoreText;
    private DataController dataController;
    private int highScore;
    private int levelHighScore;
    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();

        if (dataController != null)
        {
            highScore = dataController.GetHighestPlayerScore();
            levelHighScore = dataController.GetHighestPlayerLevel();

            highScoreText.text = "Highest score: " + highScore + " - Level: " + levelHighScore;
        }
        else
        {
            Debug.Log("DataController not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("k"))
        {
            Scene level = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Level1");
        }
    }
}
