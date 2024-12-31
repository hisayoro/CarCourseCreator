using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsGenerator : MonoBehaviour
{
    //オブジェクトを格納
    public GameObject carPrefab;
    public GameObject straightSPrefab;
    public GameObject straightLPrefab;
    public GameObject curveSPrefab;
    public GameObject curveLPrefab;

    //残数管理するオブジェクトのテキスト
    private GameObject carAmountText;
    private GameObject straightSAmountText;
    private GameObject straightLAmountText;
    private GameObject curveSAmountText;
    private GameObject curveLAmountText;

    //オブジェクトを呼び出すUIのボタン
    public Button carButton;
    public Button straightSButton;
    public Button straightLButton;
    public Button curveSButton;
    public Button curveLButton;

    //オブジェクトの個数管理、初期値
    public int carAmount;
    public int straightSAmount;
    public int straightLAmount;
    public int curveSAmount;
    public int curveLAmount;


    // Start is called before the first frame update
    void Start()
    {
        //carの初期数量を表示
        this.carAmount = 1;
        this.carAmountText = GameObject.Find("CarAmountText");
        this.carAmountText.GetComponent<Text>().text = this.carAmount.ToString("D3");

        //straight(S)の初期数量を表示
        this.straightSAmount = 30;
        this.straightSAmountText = GameObject.Find("StraightSAmountText");
        this.straightSAmountText.GetComponent<Text>().text = this.straightSAmount.ToString("D3");

        //straight(L)の初期数量を表示
        this.straightLAmount = 10;
        this.straightLAmountText = GameObject.Find("StraightLAmountText");
        this.straightLAmountText.GetComponent<Text>().text = this.straightLAmount.ToString("D3");

        //curve(S)の初期数量を表示
        this.curveSAmount = 10;
        this.curveSAmountText = GameObject.Find("CurveSAmountText");
        this.curveSAmountText.GetComponent<Text>().text = this.curveSAmount.ToString("D3");

        //curve(L)の初期数量を表示
        this.curveLAmount = 10;
        this.curveLAmountText = GameObject.Find("CurveLAmountText");
        this.curveLAmountText.GetComponent<Text>().text = this.curveLAmount.ToString("D3");
    }

    // Update is called once per frame
    void Update()
    {
        //UIに残数を表示・・・オブジェクトの種類すべて書き出す
        this.carAmountText.GetComponent<Text>().text = this.carAmount.ToString("D3");
        this.straightSAmountText.GetComponent<Text>().text = this.straightSAmount.ToString("D3");
        this.straightLAmountText.GetComponent<Text>().text = this.straightLAmount.ToString("D3");
        this.curveSAmountText.GetComponent<Text>().text = this.curveSAmount.ToString("D3");
        this.curveLAmountText.GetComponent<Text>().text = this.curveLAmount.ToString("D3");
    }
    //carの生成と個数を減らしてUI表示
    public void CarButtonDown()
    {
        if (carAmount > 0)
        {
            //呼び出しボタンの場所を読み込み、オブジェクトを呼び出す場所を決める
            Vector3 carButtonPos = carButton.transform.position;
            Vector3 carGenPosSc = new Vector3(carButtonPos.x + 100, carButtonPos.y-50, carButtonPos.z+70);
            Vector3 carGenPos = Camera.main.ScreenToWorldPoint(carGenPosSc);

            GameObject car = Instantiate(carPrefab);
            car.transform.position = carGenPos;

            carAmount -= 1;   //パーツを生成したら数を減らす
        }
    }

    //パーツの呼び出しと個数を減らす
    public void StraightSButtonDown()
    {
        if (straightSAmount >0)
        {
            Vector3 straightSButtonPos = straightSButton.transform.position;
            Vector3 straightSGenPosSc = new Vector3(straightSButtonPos.x + 100, straightSButtonPos.y, straightSButtonPos.z + 70);
            Vector3 straightSGenPos = Camera.main.ScreenToWorldPoint(straightSGenPosSc);

            GameObject straightS = Instantiate(straightSPrefab);
            straightS.transform.position = straightSGenPos;

            straightSAmount -= 1;
        }
    }

    public void StraightLButtonDown()
    {
        if (straightLAmount > 0)
        {
            Vector3 straightLButtonPos = straightLButton.transform.position;
            Vector3 straightLGenPosSc = new Vector3(straightLButtonPos.x + 100, straightLButtonPos.y, straightLButtonPos.z + 70);
            Vector3 straightLGenPos = Camera.main.ScreenToWorldPoint(straightLGenPosSc);

            GameObject straightL = Instantiate(straightLPrefab);
            straightL.transform.position = straightLGenPos;

            straightLAmount -= 1;
        }
    }

    public void CurveSButtonDown()
    {
        if (curveLAmount > 0)
        {
            Vector3 curveSButtonPos = curveSButton.transform.position;
            Vector3 curveSGenPosSc = new Vector3(curveSButtonPos.x + 100, curveSButtonPos.y - 30, curveSButtonPos.z + 70);
            Vector3 curveSGenPos = Camera.main.ScreenToWorldPoint(curveSGenPosSc);

            GameObject curveS = Instantiate(curveSPrefab);
            curveS.transform.position = curveSGenPos;

            curveSAmount -= 1;
        }
    }

    public void CurveLButtonDown()
    {
        if(curveLAmount > 0)
        {
            Vector3 curveLButtonPos = curveLButton.transform.position;
            Vector3 curveLGenPosSc = new Vector3(curveLButtonPos.x + 100, curveLButtonPos.y-30, curveLButtonPos.z + 70);
            Vector3 curveLGenPos = Camera.main.ScreenToWorldPoint(curveLGenPosSc);

            GameObject curveL = Instantiate(curveLPrefab);
            curveL.transform.position = curveLGenPos;

            curveLAmount -= 1;
        }
    }
}