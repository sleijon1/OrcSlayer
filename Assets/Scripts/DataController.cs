using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    private PlayerProgress playerProgress;
    private GameObject dataObject;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadPlayerProgress();
        SceneManager.LoadScene("MenuScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitNewPlayerScore(int newScore, int levelScore)
    {
        if(newScore > playerProgress.highscore && levelScore >= playerProgress.levelHighscore)
        {
            playerProgress.highscore = newScore;
            playerProgress.levelHighscore = levelScore;
            SavePlayerProgress();
        }

    }

    public int GetHighestPlayerScore()
    {
        return playerProgress.highscore;
    }

    public int GetHighestPlayerLevel()
    {
        return playerProgress.levelHighscore;
    }

    // This function could be extended easily to handle any additional data we wanted to store in our PlayerProgress object
    private void LoadPlayerProgress()
    {
        // Create a new PlayerProgress object
        playerProgress = new PlayerProgress();

        // If PlayerPrefs contains a key called "highestScore", set the value of playerProgress.highestScore using the value associated with that key
        if (PlayerPrefs.HasKey("highestScore"))
        {
            playerProgress.highscore = PlayerPrefs.GetInt("highestScore");
        }
    }

    // This function could be extended easily to handle any additional data we wanted to store in our PlayerProgress object
    private void SavePlayerProgress()
    {
        // Save the value playerProgress.highestScore to PlayerPrefs, with a key of "highestScore"
        PlayerPrefs.SetInt("highestScore", playerProgress.highscore);
    }

}
