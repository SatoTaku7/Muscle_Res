using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;�@�@

public class ChartScript : MonoBehaviour
{
    /// <summary>
    /// Oculus�֌W
    /// </summary>
    private OVRInput.Controller L_con;
    private Vector3 L_accel;//���x�擾

    /// <summary>
    /// �O���t�֌W
    /// </summary>
    [SerializeField] GameObject LineChart;
    private float timeOut = 0.01f;//�擾�Ԋu
    private float durationTime = 25.01f;//�O���t�̏I���
    private float timeElapsed = 0.0f;
    private LineChart chart;
    #region �Q�l�T�C�g
    /*https://megane-sensei.com/246/ */
    #endregion

    void Awake()
    {

    }

    void Start()
    {
        L_con = OVRInput.Controller.LTouch;

        chart = LineChart.GetComponent<LineChart>();
        chart.RemoveData();
        chart.AddSerie(SerieType.Line);
        TitleSet();//�^�C�g���̐ݒ�
        YAxisSet();//Y���̐ݒ�
        XAxisSet1();//X���̐ݒ�
    }
    private void Update()
    {
        L_accel = OVRInput.GetLocalControllerVelocity(L_con);
    }

    private void YAxisSet() //Y���̕\���ݒ�
    {
        chart.yAxes[0].type = Axis.AxisType.Value;
        chart.yAxes[0].minMaxType = Axis.AxisMinMaxType.Custom;
        chart.yAxes[0].min = 0f;�@//�ŏ��l
        chart.yAxes[0].max = 4f;�@ //�ő�l
        chart.yAxes[0].splitNumber = 5; //������
    }

    private void TitleSet()�@//�^�C�g���̕\���ݒ�
    {
        chart.title.show = true;
        chart.title.textStyle.fontSize = 30;�@//�^�C�g���t�H���g�T�C�Y
        chart.title.text = "x-t�O���t";�@//�^�C�g���̖���
    }
    private void XAxisSet1() //X���̕\���ݒ�
    {
        chart.xAxes[0].boundaryGap = true;//�����\���ݒ�
        chart.xAxes[0].splitNumber = 5;�@//�O���t�ɕ\������郁�����̐�

        //�O���t�Ƀv���b�g���鐔�����߂�iX���̃������Ԋu�����߂�j
        for (float i = 0; i < durationTime; i += timeOut)
        {
            float duration_cell = Mathf.FloorToInt(i);
            chart.AddXAxisData(duration_cell + "s");
        }
    }

    private void XAxisAddData(float x) //�v���b�g����f�[�^
    {
        chart.AddData(0, x);
    }

    //��莞�Ԃ��Ƃɕ��̂̈ʒu�����v���b�g������
    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            XAxisAddData(Mathf.Sqrt(L_accel.x * L_accel.x + L_accel.y * L_accel.y + L_accel.z * L_accel.z));//���x����3�����x�N�g�������߁A�O���t�ɏ����o��
            timeElapsed = 0.0f;
        }

    }
}