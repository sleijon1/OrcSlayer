using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject lootGoblin;
    public Vector3 spawnValue;
    public int goblinCount;
    public float spawnWait;
    public float startWait;
    public float goblinSpeed;
    public Text goldText;
    public Text endGameText;
    public Text advanceLevelText;
    public RawImage transitionImage;
    private int score;
    private int highscore;
    private bool gameOver;
    public bool levelOne;
    public bool levelTwo;
    public bool levelThree;
    public int level; 

    private DataController dataController;

    private bool advanceToTwo;
    private bool advanceToThree;
    private string goldForNextLvl;

    private LinkedList<GameObject> consumedObjects = new LinkedList<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        if (dataController == null)
        {
            Debug.Log("DataController not being found from GameController");
        }

        transitionImage.gameObject.SetActive(false);
        advanceLevelText.gameObject.SetActive(false);
        endGameText.gameObject.SetActive(false);

        switch (level)
        {
            case 1:
                goldForNextLvl = "Required for next level: " + 10;
                break;
            case 2:
                goldForNextLvl = "Required for next level: " + 25;
                break;
            case 3:
                goldForNextLvl = "Max level!";
                break;

        }
        goldText.text = "Gold: 0" + " | " + goldForNextLvl;
        StartCoroutine(SpawnWaves());
    }

    public void addConsumedObject(GameObject go)
    {
        consumedObjects.AddLast(go);
        if(consumedObjects.Count > 8)
        {
            for(int i = 0; i < 3; i++)
            {
                LinkedListNode<GameObject> tmp = consumedObjects.First;
                consumedObjects.RemoveFirst();
                GameObject tmpGo = tmp.Value;
                Destroy(tmpGo);
            }
        }
    }

    public void AddScore(int points)
    {
        score += points;
        goldText.text = "Gold: " + score + " | " + goldForNextLvl; 

        if(score > highscore)
        {
            highscore = score;
        }
        
        if(score <= -5)
        {
            if (levelTwo)
            {
                EndGame();
            }else if (levelThree)
            {
                EndGame();
            }
            else
            {
                EndGame();
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
        }
        if (advanceToTwo)
        {
            highscore = 0;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Destroy(player);
            advanceLevelText.gameObject.SetActive(true);
            transitionImage.gameObject.SetActive(true);
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
            transitionImage.gameObject.SetActive(true);
            if (Input.GetKey("l"))
            {
                SceneManager.LoadScene("Level3");
            }
        }

    }

    void EndGame()
    {
        gameOver = true;
        dataController.SubmitNewPlayerScore(highscore, level);
        SceneManager.LoadScene("Persistent");

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
