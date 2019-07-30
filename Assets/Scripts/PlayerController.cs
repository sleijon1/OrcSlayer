using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float rotationSpeed = 100f;
    public float fireRate;
    public float spearFireRate;
    private float nextFire;

    Animator animator;
    Rigidbody body;

    // Shots
    public GameObject shot;
    public Transform shotSpawn;
    public GameObject spear;
    public Transform spearSpawn;
    public GameObject sword;
    public Transform swordSpawn;
    public GameObject swordTwo;
    public Transform swordSpawnTwo;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    public void setTriggerGetHit(bool hit)
    {
        if (hit)
        {
            animator.SetTrigger("getHit");
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
        }
        else
        {
            animator.ResetTrigger("getHit");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("a"))
        {
            animator.SetTrigger("startRun");
            animator.SetBool("attack1", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
            animator.ResetTrigger("startRun");
            animator.SetBool("attack1", true);

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
        }

        if (Input.GetKey("q"))
        {
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
            animator.ResetTrigger("startRun");
            animator.SetBool("attack1", true);

            if (Time.time > nextFire)
            {
                nextFire = Time.time + spearFireRate;
                Instantiate(spear, spearSpawn.position, spear.transform.rotation);
            }
        }

        if (Input.GetKey("e"))
        {
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
            animator.ResetTrigger("startRun");
            animator.SetBool("attack1", true);

            if (Time.time > nextFire)
            {
                nextFire = Time.time + spearFireRate;
                Instantiate(sword, swordSpawn.position, sword.transform.rotation);
            }
        }

        if (Input.GetKey("r"))
        {
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
            animator.ResetTrigger("startRun");
            animator.SetBool("attack1", true);

            if (Time.time > nextFire)
            {
                nextFire = Time.time + spearFireRate;
                Instantiate(swordTwo, swordSpawnTwo.position, swordTwo.transform.rotation);
            }
        }



    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal") * Speed;
        float moveV = Input.GetAxis("Vertical") * Speed;

        Vector3 movement = new Vector3(moveH, 0, moveV);


        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            transform.Translate(movement * Time.deltaTime, Space.World);
           
            
        }
        body.AddForce(movement * Speed);

    }
}
