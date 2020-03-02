using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsController.SetMasterVolume(0.4f);
        Debug.Log("Return to " + PlayerPrefsController.GetMAsterVolume());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
