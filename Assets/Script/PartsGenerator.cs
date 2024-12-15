using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject straightPrefab;
    public GameObject curvePrefab;
    private GameObject carAmountText;
    private GameObject straightAmountText;
    private GameObject curveAmountText;

    //パーツを生成するUIのボタン
    public Button carButton;
    public Button straightButton;
    public Button curveButton;

    //パーツの個数管理、初期値
    public int carAmount;
    public int straightAmount;
    public int curveAmount;


    // Start is called before the first frame update
    void Start()
    {
        //carの初期数量を表示
        this.carAmount = 1;
        this.carAmountText = GameObject.Find("CarAmountText");
        this.carAmountText.GetComponent<Text>().text = this.carAmount.ToString("D3");

        //straightの初期数量を表示
        this.straightAmount = 10;
        this.straightAmountText = GameObject.Find("StraightAmountText");
        this.straightAmountText.GetComponent<Text>().text = this.straightAmount.ToString("D3");

        //curveの初期数量を表示
        this.curveAmount = 5;
        this.curveAmountText = GameObject.Find("CurveAmountText");
        this.curveAmountText.GetComponent<Text>().text = this.curveAmount.ToString("D3");
    }

    // Update is called once per frame
    void Update()
    {
        //UIに残数を表示・・・オブジェクトの種類すべて書き出す
        this.carAmountText.GetComponent<Text>().text = this.carAmount.ToString("D3");
        this.straightAmountText.GetComponent<Text>().text = this.straightAmount.ToString("D3");
        this.curveAmountText.GetComponent<Text>().text = this.curveAmount.ToString("D3");
    }
    //carの生成と個数を減らしてUI表示
    public void CarButtonDown()
    {
        if (carAmount > 0)
        {
            Vector3 carButtonPos = carButton.transform.position;
            Vector3 carGenPosSc = new Vector3(carButtonPos.x + 100, carButtonPos.y, carButtonPos.z + 30);
            Vector3 carGenPos = Camera.main.ScreenToWorldPoint(carGenPosSc);

            GameObject car = Instantiate(carPrefab);
            car.transform.position = carGenPos;

            carAmount -= 1;   //パーツを生成したら数を減らす
        }
    }

    //straightの生成と個数を減らしてUI表示
    public void StraightButtonDown()
    {
        if (straightAmount >0)
        {
            Vector3 straightButtonPos = straightButton.transform.position;
            Vector3 straightGenPosSc = new Vector3(straightButtonPos.x + 100, straightButtonPos.y, straightButtonPos.z + 30);
            Vector3 straightGenPos = Camera.main.ScreenToWorldPoint(straightGenPosSc);

            GameObject straight = Instantiate(straightPrefab);
            straight.transform.position = straightGenPos;

            straightAmount -= 1;   //パーツを生成したら数を減らす
        }
    }

    //curveの生成と個数を減らしてUI表示
    public void CurveButtonDown()
    {
        if(curveAmount > 0)
        {
            Vector3 curveButtonPos = curveButton.transform.position;
            Vector3 curveGenPosSc = new Vector3(curveButtonPos.x + 100, curveButtonPos.y, curveButtonPos.z + 30);
            Vector3 curveGenPos = Camera.main.ScreenToWorldPoint(curveGenPosSc);

            GameObject curve = Instantiate(curvePrefab);
            curve.transform.position = curveGenPos;

            curveAmount -= 1;   //パーツを生成したら数を減らす
        }
    }

}