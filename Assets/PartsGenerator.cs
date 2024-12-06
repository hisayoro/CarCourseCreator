using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsGenerator : MonoBehaviour
{
    //PlatePrefabを入れる
    public GameObject platePrefab;
    public GameObject cubePrefab;

    //パーツを生成するUIのボタン
    public Button plateButton;
    public Button cubeButton;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void plateButtonDown()
    {
        Vector3 plateButtonPos = plateButton.transform.position;
        Vector3 plateGenPosSc = new Vector3(plateButtonPos.x+100,plateButtonPos.y,plateButtonPos.z+30);
        Vector3 plateGenPos = Camera.main.ScreenToWorldPoint(plateGenPosSc);

        GameObject plate = Instantiate(platePrefab);
        plate.transform.position = plateGenPos;
    }

    public void cubeButtonDown()
    {
        Vector3 cubeButtonPos = cubeButton.transform.position;
        Vector3 cubeGenPosSc = new Vector3(cubeButtonPos.x + 100, cubeButtonPos.y, cubeButtonPos.z + 30);
        Vector3 cubeGenPos = Camera.main.ScreenToWorldPoint(cubeGenPosSc);

        GameObject cube = Instantiate(cubePrefab);
        cube.transform.position = cubeGenPos;
    }

}