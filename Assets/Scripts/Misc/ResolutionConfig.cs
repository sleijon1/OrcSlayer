using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolutionConfig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1260, 650, true);
        Screen.fullScreen = !Screen.fullScreen;
        SceneManager.LoadScene("Persistent");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
