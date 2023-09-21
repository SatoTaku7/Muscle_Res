using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Dumbbell_state {normal,big,small}
public class Dumbbell_control : MonoBehaviour
{
    OVRInput.Controller L_con;
    OVRInput.Controller R_con;
    [SerializeField] GameObject Dumbbell;
    [SerializeField] TextMeshProUGUI Accel_text;
    [SerializeField] TextMeshProUGUI Size_text;
    Dumbbell_state D_state = Dumbbell_state.normal;
    void Start()
    {
        L_con = OVRInput.Controller.LTouch;
        R_con = OVRInput.Controller.RTouch;
        Size_text.SetText("Å~1");
    }

    void Update()
    {
        Vector3 L_accel = OVRInput.GetLocalControllerVelocity(L_con);
        Vector3 R_accle = OVRInput.GetLocalControllerVelocity(R_con);
        Dumbbell_Size();
        Accel_text.SetText("L:" + L_accel +"\n"+" R:" + R_accle);
        
        Debug.Log( L_accel);
    }

    void Dumbbell_Size()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            switch (D_state)
            {

                case Dumbbell_state.normal:
                    Dumbbell.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    Size_text.SetText("Å~1");
                    D_state = Dumbbell_state.big;
                    break;

                case Dumbbell_state.big:
                    Dumbbell.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                    Size_text.SetText("Å~1.3");
                    D_state = Dumbbell_state.small;
                    break;

                case Dumbbell_state.small:
                    Dumbbell.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    Size_text.SetText("Å~0.7");
                    D_state = Dumbbell_state.normal;
                    break;

            } 
        }
        
    }
}
