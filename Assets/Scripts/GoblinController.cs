using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    Animator anim;
    public float goblinSpeed;
    public GameObject explosion;
    private GameController controller;

    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Meteor")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if(other.tag == "PlayerSword")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
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
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * goblinSpeed * Time.deltaTime);    

        anim.SetInteger("moving", 1);//walk
    }


}
