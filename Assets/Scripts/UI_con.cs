using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_con : MonoBehaviour
{
    [SerializeField] GameObject Player;
    OVRInput.Controller L_con;
    void Start()
    {
        L_con = OVRInput.Controller.LTouch;
    }

    void Update()
    {
        Vector3 L_accel = OVRInput.GetLocalControllerAcceleration(L_con);
        Debug.Log("L_accel:" + L_accel );
    }
}
