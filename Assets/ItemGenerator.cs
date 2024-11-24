using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGenerator : MonoBehaviour
{
    //PlatePrefabを入れる
    public GameObject platePrefab;

    //パーツを生成するUIのボタン
    public Button partsButton;

    //オブジェクトを出現させるスクリーン座標
    //private Vector3 plateGenPos = new Vector3(10, 10, 0);




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void PartsButtonDown()
    {
        
        Vector3 partsButtonPos = partsButton.transform.position;
        Vector3 partsGenPosSc = new Vector3(partsButtonPos.x+100,partsButtonPos.y,partsButtonPos.z+30);
        Vector3 plateGenPos = Camera.main.ScreenToWorldPoint(partsGenPosSc);

        Debug.Log("ボタンスクリーン座標 " + partsButtonPos);
        Debug.Log("ボタンスクリーン座標改 " + partsGenPosSc);
        Debug.Log("ワールド座標 " + plateGenPos);

        GameObject plate = Instantiate(platePrefab);
        plate.transform.position = plateGenPos;
    }
}