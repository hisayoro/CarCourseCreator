using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //PlatePrefabを入れる
    public GameObject platePrefab;
    //Plateの設置位置を呼び出すごとにずらす
    private float posX = 0;

    //オブジェクトを出現させるスクリーン座標
    private Vector3 plateGenPos = new Vector3(10, 10, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Plateの生成
        if (Input.GetMouseButtonDown(1))
        {
            GameObject plate = Instantiate(platePrefab);
            //plate.transform.position = new Vector3(this.posX, 0, 0);
            //this.posX += 2;

            plate.transform.position = plateGenPos;

           
        }
    }
}