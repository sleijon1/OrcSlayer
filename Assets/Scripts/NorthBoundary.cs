using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorthBoundary : MonoBehaviour
{
    private GameController controller;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerSwordSlash")
        {
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
