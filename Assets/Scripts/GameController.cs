using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject lootGoblin;
    public Vector3 spawnValue;
    public int goblinCount;
    public float spawnWait;
    public float startWait;
    public float goblinSpeed;
    public Text goldText;
    public Text endGameText;
    public Text advanceLevelText;
    private int score;
    private int highscore;
    private bool gameOver;
    public bool levelOne;
    public bool levelTwo;
    public bool levelThree;

    private DataController dataController;

    private bool advanceToTwo;
    private bool advanceToThree;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        if (dataController == null)
        {
            Debug.Log("DataController not being found from GameController");
        }
        advanceLevelText.gameObject.SetActive(false);
        endGameText.gameObject.SetActive(false);
        goldText.text = "Gold: 0";
        StartCoroutine(SpawnWaves());
    }

    public void AddScore(int points)
    {
        score += points;
        goldText.text = "Gold: " + score;

        if(score > highscore)
        {
            highscore = score;
        }
        
        if(score <= -5)
        {
            if (levelTwo)
            {
                EndGame(2);
            }else if (levelThree)
            {
                EndGame(3);
            }
            else
            {
                EndGame(1);
            }
        }

        if (score >= 10 && levelOne)
        {
            advanceLevelText.text = "Advanced to level 2. Press L to continue!";
            AdvanceLevel();
        }

        if(score >= 25 && levelTwo)
        {
            advanceLevelText.text = "Advanced to the last level(3) play for highscore. Press L to continue!";
            AdvanceLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Destroy(player);
            endGameText.gameObject.SetActive(true);
            if (Input.GetKey("k"))
            {
                Scene level = SceneManager.GetActiveScene();
                SceneManager.LoadScene(level.name);
            }
        }
        if (advanceToTwo)
        {
            highscore = 0;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Destroy(player);
            advanceLevelText.gameObject.SetActive(true);
            if (Input.GetKey("l"))
            {
                SceneManager.LoadScene("Level2");
            }
        }

        if (advanceToThree)
        {
            highscore = 0;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Destroy(player);
            advanceLevelText.gameObject.SetActive(true);
            if (Input.GetKey("l"))
            {
                SceneManager.LoadScene("Level3");
            }
        }

    }

    void EndGame(int level)
    {
        gameOver = true;
        dataController.SubmitNewPlayerScore(highscore, level);
        SceneManager.LoadScene("MenuScreen");
    }

    void AdvanceLevel()
    {
        if (levelOne)
        {
            advanceToTwo = true;
        }

        if (levelTwo)
        {
            advanceToThree = true;
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < goblinCount; i++)
            {
                Vector3 spawnAt = new Vector3(
                    Random.Range(-spawnValue.x, spawnValue.x),
                        spawnValue.y,
                        spawnValue.z
                    );
      
                Instantiate(lootGoblin, spawnAt, Quaternion.identity);

                yield return new WaitForSeconds(spawnWait);

            }
        }
        
    }
}
