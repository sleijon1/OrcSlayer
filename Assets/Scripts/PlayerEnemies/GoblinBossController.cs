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
        if(health <= 0)
        {
            health = maxHealth;
            healthBar.UpdateBar(maxHealth, maxHealth);
            Instantiate(zeroHealthAnimation, transform.position, transform.rotation);
            controller.AddScore(5);
        }
    }

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
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
        Instantiate(spear, spearSpawn.position, spear.transform.rotation);

        yield return new WaitForSeconds(1);

        anim.SetInteger("moving", 1);
        goblinBody.rotation = Quaternion.LookRotation(movement);
        goblinBody.velocity = preVelocity;
    }

    void FixedUpdate()
    {


    }
}
