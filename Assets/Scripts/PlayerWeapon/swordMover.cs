using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordMover : MonoBehaviour
{
    public float speed;
    private GameController controller;
    private PlayerController playerController;
    public int turnSpeed;
    //public GameObject deathAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * turnSpeed, 0, Space.World);
    }
}
