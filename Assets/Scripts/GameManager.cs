using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    OVRInput.Controller L_con;
    OVRInput.Controller R_con;
    void Start()
    {
        
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A)) SceneManager.LoadScene("TrainingRoom");
        
    }
}
