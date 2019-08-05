using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverSpear : MonoBehaviour
{
    public float speed;
    private Rigidbody spearBody;
    private GameController controller;
    private PlayerController playerController;
    //public GameObject deathAnimation;

    // Start is called before the first frame update
    void Start()
    {
        spearBody = GetComponent<Rigidbody>();
        spearBody.velocity = new Vector3(0, 0, -1) * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
            controller = tmp.GetComponent<GameController>();
            if (controller == null)
            {
                Debug.LogError("Unable to find gamecontroller scripts");
            }
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            playerController = player.GetComponent<PlayerController>();

            if (playerController == null)
            {
                Debug.LogError("Unable to find gamecontroller scripts");
            }

            playerController.setTriggerGetHit(true);

            controller.AddScore(-1);
        }

        //Instantiate(deathAnimation, other.transform.position, other.transform.rotation);
        //Destroy(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            playerController = player.GetComponent<PlayerController>();

            if (playerController == null)
            {
                Debug.LogError("Unable to find gamecontroller scripts");
            }

            playerController.setTriggerGetHit(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
