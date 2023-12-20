using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Dumbbell_state {normal,small,slow,small_slow}
public enum Dumbbell_weight { kg10,kg7,kg4 }
public class Dumbbell_control : MonoBehaviour
{
    [SerializeField] GameObject Dumbbell;
    [SerializeField] GameObject Dumbbell_parts;
    [SerializeField] GameObject Normal_Hand;
    [SerializeField] GameObject Small_Hand;
    [SerializeField] GameObject Slow_Dumbbell;//íxÇÍÇƒí«è]ÇÃÉ_ÉìÉxÉã
    [SerializeField] float speed;

    [SerializeField] TextMeshProUGUI Accel_text;
    [SerializeField] TextMeshProUGUI Size_text;
    Dumbbell_state D_state = Dumbbell_state.normal;
    Dumbbell_weight D_weight = Dumbbell_weight.kg10;

/// <summary>
/// íxÇ¢É_ÉìÉxÉã
/// </summary>
    void Start()
    {
        Size_text.SetText("Å~1");
        Dumbbell_parts.SetActive(true);
        Normal_Hand.SetActive(true);
        Slow_Dumbbell.SetActive(false);
    }

    void Update()
    {
        Dumbbell_Type();
        SlowDumbbel_trans();
    }

    void Dumbbell_Type()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            switch (D_state)
            {

                case Dumbbell_state.normal://small
                    Dumbbell.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    Dumbbell_parts.SetActive(true);
                    Normal_Hand.SetActive(true);
                    Normal_Hand.transform.localScale = new Vector3(0.04634649f, 0.04634649f, 0.04634649f);
                    Normal_Hand.transform.localPosition = new Vector3(0.0004996192f, -0.05060722f, -0.09986175f);
                    Slow_Dumbbell.SetActive(false);
                    D_state = Dumbbell_state.small;
                    break;

                case Dumbbell_state.small://normal
                    Dumbbell.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    D_state = Dumbbell_state.slow;
                    Dumbbell_parts.SetActive(true);
                    Normal_Hand.SetActive(true);
                    Normal_Hand.transform.localScale = new Vector3(0.065250437f, 0.065250437f, 0.065250437f);
                    Normal_Hand.transform.localPosition = new Vector3(-0.0084f, -0.0735f, -0.1363f);
                    Slow_Dumbbell.SetActive(false);
                    break;

                case Dumbbell_state.slow://small_slow
                    Slow_Dumbbell.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    Dumbbell_parts.SetActive(false);
                    Normal_Hand.SetActive(false);
                    Small_Hand.transform.localScale = new Vector3(0.04634649f, 0.04634649f, 0.04634649f); 
                    Small_Hand.transform.localPosition = new Vector3(0.0026f, -0.0561f, -0.0973f);
                    Slow_Dumbbell.SetActive(true);
                    D_state = Dumbbell_state.small_slow;
                    break;

                case Dumbbell_state.small_slow://slow
                    Slow_Dumbbell.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    Dumbbell_parts.SetActive(false);
                    Normal_Hand.SetActive(false);
                    Small_Hand.transform.localScale = new Vector3(0.065250437f, 0.065250437f, 0.065250437f);
                    Small_Hand.transform.localPosition = new Vector3(-0.005f, -0.076f, -0.133f);
                    Slow_Dumbbell.SetActive(true);
                    D_state = Dumbbell_state.normal;
                    break;

            } 
        }
        //if (OVRInput.GetDown(OVRInput.RawButton.A))
        //{
        //    switch (D_weight)
        //    {

        //        case Dumbbell_weight.kg10:
        //            Dumbbell.transform.localPosition += new Vector3(0.001f, 0.001f, 0.001f);
        //            break;

        //        case Dumbbell_weight.kg7:
        //            Dumbbell.transform.localPosition += new Vector3(0.001f, 0.001f, 0.001f);
        //            break;

        //        case Dumbbell_weight.kg4:
        //            Dumbbell.transform.localPosition += new Vector3(0.001f, 0.001f, 0.001f);
        //            break;
        //    }
        //}
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
