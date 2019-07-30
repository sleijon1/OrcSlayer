using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class westBoundaryDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerSword")
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
