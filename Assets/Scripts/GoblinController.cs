using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    Animator anim;
    public float goblinSpeed;
    public GameObject explosion;
    private GameController controller;
    public Goblin type;
    public GoblinFactory factory;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Meteor")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if (other.tag == "PlayerSword")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
        }
        if (other.tag == "NorthWall")
        {
            if (controller.level > 1)
            {
                controller.AddScore(type.stealGold);
            }
            else
            {
                controller.AddScore(-1);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController>();
        if(controller == null)
        {
            Debug.LogError("Unable to find gamecontroller scripts");
        }

        //animator = GetComponent<Animator>();
        anim = GetComponent<Animator>();
        controller.AddScore(1);

        int random = Random.Range(0, 9);
        if(controller.level == 2)
        {
            if (random >= 5)
            {
                Goblin newSpawn = gameObject.AddComponent<FastGoblin>();
                factory = new FastGoblinFactory();
            }
            else
            {
                factory = new RegularGoblinFactory();
            }
        }
        else if (controller.level == 3)
        {
            Debug.Log("random: " + random);

            if (random >= 5)
            {
                Goblin newSpawn = gameObject.AddComponent<FastGoblin>();
                factory = new FastGoblinFactory();
            }
            else
            {
                Goblin newSpawn = gameObject.AddComponent<ThiefGoblin>();
                factory = new ThiefGoblinFactory();
            }
        }
        else
        {
            factory = new RegularGoblinFactory();
        }

        type = factory.GetGoblin(gameObject);
        goblinSpeed = type.speed;
        
    }


    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * goblinSpeed * Time.deltaTime);    

        anim.SetInteger("moving", 1);//walk
    }


}
