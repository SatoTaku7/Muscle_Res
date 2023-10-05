using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;　　

public class ChartScript : MonoBehaviour
{
    /// <summary>
    /// Oculus関係
    /// </summary>
    private OVRInput.Controller L_con;
    private Vector3 L_accel;//速度取得

    /// <summary>
    /// グラフ関係
    /// </summary>
    [SerializeField] GameObject LineChart;
    private float timeOut = 0.01f;//取得間隔
    private float durationTime = 25.01f;//グラフの終わり
    private float timeElapsed = 0.0f;
    private LineChart chart;
    #region 参考サイト
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
        TitleSet();//タイトルの設定
        YAxisSet();//Y軸の設定
        XAxisSet1();//X軸の設定
    }
    private void Update()
    {
        L_accel = OVRInput.GetLocalControllerVelocity(L_con);
    }

    private void YAxisSet() //Y軸の表示設定
    {
        chart.yAxes[0].type = Axis.AxisType.Value;
        chart.yAxes[0].minMaxType = Axis.AxisMinMaxType.Custom;
        chart.yAxes[0].min = 0f;　//最小値
        chart.yAxes[0].max = 4f;　 //最大値
        chart.yAxes[0].splitNumber = 5; //分割数
    }

    private void TitleSet()　//タイトルの表示設定
    {
        chart.title.show = true;
        chart.title.textStyle.fontSize = 30;　//タイトルフォントサイズ
        chart.title.text = "x-tグラフ";　//タイトルの名称
    }
    private void XAxisSet1() //X軸の表示設定
    {
        chart.xAxes[0].boundaryGap = true;//文字表示設定
        chart.xAxes[0].splitNumber = 5;　//グラフに表示されるメモリの数

        //グラフにプロットする数を決める（X軸のメモリ間隔を決める）
        for (float i = 0; i < durationTime; i += timeOut)
        {
            float duration_cell = Mathf.FloorToInt(i);
            chart.AddXAxisData(duration_cell + "s");
        }
    }

    private void XAxisAddData(float x) //プロットするデータ
    {
        chart.AddData(0, x);
    }

    //一定時間ごとに物体の位置情報をプロットさせる
    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            XAxisAddData(Mathf.Sqrt(L_accel.x * L_accel.x + L_accel.y * L_accel.y + L_accel.z * L_accel.z));//速度から3次元ベクトルを求め、グラフに書き出す
            timeElapsed = 0.0f;
        }

    }
}