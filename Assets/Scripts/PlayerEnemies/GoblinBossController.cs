using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMax, xMin;
}

public class GoblinBossController : MonoBehaviour
{
    private Vector3 movement;
    public int goblinBossSpeed;
    public Boundary boundary;
    private Rigidbody goblinBody;
    private float nextFire = 1;
    public float fireRate;
    public int health;
    public int maxHealth;
    public SimpleHealthBar healthBar;
    private GameController controller;
    public GameObject zeroHealthAnimation;
    public int rotationSpeed; 

    // SPEAR
    public GameObject spear;
    public Transform spearSpawn;

    // LL for cleaning up thrown halberd's
    private LinkedList<GameObject> thrownSpears = new LinkedList<GameObject>();


    private GameObject lastAnimation;
    Animator anim;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerSpear")
        {
            TakeDamage(25);
        }
        if(other.tag == "PlayerSwordSlash")
        {
            TakeDamage(50);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.UpdateBar(health, maxHealth);
        Destroy(lastAnimation);
        if (health <= 0)
        {
            health = maxHealth;
            healthBar.UpdateBar(maxHealth, maxHealth);
            lastAnimation = (GameObject)Instantiate(zeroHealthAnimation, transform.position, transform.rotation);
            controller.addConsumedObject(lastAnimation);
            controller.AddScore(5);
            
        }
    }

    void Start()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController>();

        health = 100;
        maxHealth = 100;

        anim = GetComponent<Animator>();
        goblinBody = GetComponent<Rigidbody>();
        goblinBody.velocity = transform.right * goblinBossSpeed;
        anim.SetInteger("moving", 1);
        movement = new Vector3(-1, 0, 0);
        transform.rotation = Quaternion.LookRotation(movement);
    }

    void Update()
    {
        if(thrownSpears.Count == 10)
        {
            for(int i = 0; i < 5; i++)
            {
               LinkedListNode<GameObject> tmp = thrownSpears.First;
               GameObject tmpGo = tmp.Value;
               thrownSpears.RemoveFirst();
               Destroy(tmpGo);
            }
        }
        if (Time.time > nextFire)
        {
            StartCoroutine(throwSpear());
        }
        float timeDelta = Time.deltaTime;

        if (GetComponent<Rigidbody>().position.x >= boundary.xMax)
        {
            movement = new Vector3(-1, 0, 0);
            transform.rotation = Quaternion.LookRotation(movement);
            goblinBody.velocity = transform.forward * goblinBossSpeed;

        }
        else if (GetComponent<Rigidbody>().position.x <= boundary.xMin)
        {
            movement = new Vector3(1, 0, 0);
            transform.rotation = Quaternion.LookRotation(movement);
            goblinBody.velocity = transform.forward * goblinBossSpeed;
        }
    }

    IEnumerator throwSpear()
    {
        Vector3 preVelocity = goblinBody.velocity;
        Vector3 throwRotation = new Vector3(0, 0, -1);
        goblinBody.velocity = Vector3.zero;
        goblinBody.rotation = Quaternion.LookRotation(throwRotation);
        anim.SetInteger("moving", 0);

        nextFire = Time.time + fireRate;

        GameObject newSpear = (GameObject)Instantiate(spear, spearSpawn.position, spear.transform.rotation);
        thrownSpears.AddLast(newSpear);


        yield return new WaitForSeconds(1);

        anim.SetInteger("moving", 1);
        goblinBody.rotation = Quaternion.LookRotation(movement);
        goblinBody.velocity = preVelocity;
    }

    void FixedUpdate()
    {


    }
}
