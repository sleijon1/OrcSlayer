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
    public Text Instructions;
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
        Instructions.text = "INSTRUCTIONS:" + "\n Q: Throws spear across the map \n E: Sweeps sword across the ground level \n R: Swings sword in the middle of the opposite wall \n Space: Launches meteor from play position";
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
