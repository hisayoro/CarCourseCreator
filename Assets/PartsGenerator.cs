using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsGenerator : MonoBehaviour
{
    //PlatePrefabを入れる
    public GameObject platePrefab;
    public GameObject cubePrefab;
    public GameObject plateAmountText;
    private GameObject cubeAmountText;

    //パーツを生成するUIのボタン
    public Button plateButton;
    public Button cubeButton;

    //パーツの個数管理、初期値
    public int plateAmount = 3;
    public int cubeAmount = 3;


    // Start is called before the first frame update
    void Start()
    {
        //Plateの初期数量を表示
        this.plateAmountText = GameObject.Find("PlateAmountText");
        this.plateAmountText.GetComponent<Text>().text = this.plateAmount.ToString("D3");

        //Cubeの初期数量を表示
        this.cubeAmountText = GameObject.Find("CubeAmountText");
        this.cubeAmountText.GetComponent<Text>().text = this.cubeAmount.ToString("D3");

    }

    // Update is called once per frame
    void Update()
    {
        //UIに残数を表示
        this.plateAmountText.GetComponent<Text>().text = this.plateAmount.ToString("D3");
        this.cubeAmountText.GetComponent<Text>().text = this.cubeAmount.ToString("D3");
    }

    //Plateの生成と個数を減らしてUI表示
    public void plateButtonDown()
    {
        if (plateAmount >0)
        {
            Vector3 plateButtonPos = plateButton.transform.position;
            Vector3 plateGenPosSc = new Vector3(plateButtonPos.x + 100, plateButtonPos.y, plateButtonPos.z + 30);
            Vector3 plateGenPos = Camera.main.ScreenToWorldPoint(plateGenPosSc);

            GameObject plate = Instantiate(platePrefab);
            plate.transform.position = plateGenPos;

            plateAmount -= 1;   //パーツを生成したら数を減らす
        }
    }

    //Cubeの生成と個数を減らしてUI表示
    public void cubeButtonDown()
    {
        if(cubeAmount > 0)
        {
            Vector3 cubeButtonPos = cubeButton.transform.position;
            Vector3 cubeGenPosSc = new Vector3(cubeButtonPos.x + 100, cubeButtonPos.y, cubeButtonPos.z + 30);
            Vector3 cubeGenPos = Camera.main.ScreenToWorldPoint(cubeGenPosSc);

            GameObject cube = Instantiate(cubePrefab);
            cube.transform.position = cubeGenPos;

            cubeAmount -= 1;   //パーツを生成したら数を減らす
        }
    }

}