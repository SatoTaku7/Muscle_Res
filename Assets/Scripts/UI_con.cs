using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_con : MonoBehaviour
{
    OVRInput.Controller L_con = OVRInput.Controller.LTouch;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 L_accel = OVRInput.GetLocalControllerAcceleration(L_con);
        Debug.Log( L_accel );
    }
}
