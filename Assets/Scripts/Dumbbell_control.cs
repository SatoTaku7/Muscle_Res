using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Dumbbell_state {normal,small,slow,small_slow}
public class Dumbbell_control : MonoBehaviour
{
    [SerializeField] GameObject Dumbbell;
    [SerializeField] GameObject Dumbbell_parts;
    [SerializeField] GameObject Slow_Dumbbell;//íxÇÍÇƒí«è]ÇÃÉ_ÉìÉxÉã
    [SerializeField] float speed;

    [SerializeField] TextMeshProUGUI Accel_text;
    [SerializeField] TextMeshProUGUI Size_text;
    Dumbbell_state D_state = Dumbbell_state.normal;

/// <summary>
/// íxÇ¢É_ÉìÉxÉã
/// </summary>
    void Start()
    {
        Size_text.SetText("Å~1");
        Dumbbell_parts.SetActive(true);
        Slow_Dumbbell.SetActive(false);
    }

    void Update()
    {
        Dumbbell_Type();
        //Accel_text.SetText("L:" + L_accel +"\n"+" R:" + R_accle);
        if(D_state!=Dumbbell_state.normal&&D_state!=Dumbbell_state.small)SlowDumbbel_trans();
        //Debug.Log( L_accel);
    }

    void Dumbbell_Type()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            switch (D_state)
            {

                case Dumbbell_state.normal:
                    Dumbbell.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    D_state = Dumbbell_state.small;
                    break;

                case Dumbbell_state.small:
                    Dumbbell.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    D_state = Dumbbell_state.slow;
                    break;

                case Dumbbell_state.slow:
                    Dumbbell.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    Dumbbell_parts.SetActive(false);
                    Slow_Dumbbell.SetActive(true);
                    D_state = Dumbbell_state.small_slow;
                    break;

            } 
        }
    }

    void SlowDumbbel_trans()
    {
        if (Dumbbell != null)
        {
            Vector3 NormalPosition = Dumbbell.transform.position;
            Vector3 SlowPosition = Vector3.MoveTowards(Slow_Dumbbell.transform.position, NormalPosition, speed*Time.deltaTime);
            Slow_Dumbbell.transform.position = SlowPosition;
            Slow_Dumbbell.transform.rotation = Dumbbell.transform.rotation;
        }
    }
}
