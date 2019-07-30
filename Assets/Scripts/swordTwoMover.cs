using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordTwoMover : MonoBehaviour
{
    public int turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * turnSpeed, 0, 0, Space.World);

    }
}
