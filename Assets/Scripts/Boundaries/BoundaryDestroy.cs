using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroy : MonoBehaviour
{
    private GameController controller;

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            return;
        }
        if(other.tag == "Meteor")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Goblin")
        {
            Destroy(other.gameObject);
        }
        
    }
}
