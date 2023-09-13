using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dumbbell_state {normal,big,small}
public class Dumbbell_control : MonoBehaviour
{
    OVRInput.Controller L_con;
    OVRInput.Controller R_con;
    [SerializeField] GameObject Dumbbell;
    Dumbbell_state D_state = Dumbbell_state.normal;
    void Start()
    {
        
        L_con = OVRInput.Controller.LTouch;
        R_con = OVRInput.Controller.RTouch;
    }

    void Update()
    {
        Vector3 L_accel = OVRInput.GetLocalControllerAcceleration(L_con);
        Vector3 R_accle = OVRInput.GetLocalControllerAcceleration(R_con);
        Dumbbell_Size();
        Debug.Log("ç∂ÇÃâ¡ë¨ìx:" + L_accel + "    âEÇÃâ¡ë¨ìx:"+R_accle);
    }

    void Dumbbell_Size()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            switch (D_state)
            {

                case Dumbbell_state.normal:
                    Dumbbell.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    D_state = Dumbbell_state.big;
                    break;

                case Dumbbell_state.big:
                    Dumbbell.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                    D_state = Dumbbell_state.small;
                    break;

                case Dumbbell_state.small:
                    Dumbbell.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    D_state = Dumbbell_state.normal;
                    break;

            } 
        }
        
    }
}
