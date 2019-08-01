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
            GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
            controller = tmp.GetComponent<GameController>();
            if (controller == null)
            {
                Debug.LogError("Unable to find gamecontroller scripts");
            }

          //  controller.AddScore(-1);
            Destroy(other.gameObject);
        }
        
    }
}
