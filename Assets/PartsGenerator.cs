using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsGenerator : MonoBehaviour
{
    //PlatePrefab������
    public GameObject platePrefab;
    public GameObject cubePrefab;
    public GameObject plateAmountText;
    private GameObject cubeAmountText;

    //�p�[�c�𐶐�����UI�̃{�^��
    public Button plateButton;
    public Button cubeButton;

    //�p�[�c�̌��Ǘ��A�����l
    public int plateAmount = 3;
    public int cubeAmount = 3;


    // Start is called before the first frame update
    void Start()
    {
        //Plate�̏������ʂ�\��
        this.plateAmountText = GameObject.Find("PlateAmountText");
        this.plateAmountText.GetComponent<Text>().text = this.plateAmount.ToString("D3");

        //Cube�̏������ʂ�\��
        this.cubeAmountText = GameObject.Find("CubeAmountText");
        this.cubeAmountText.GetComponent<Text>().text = this.cubeAmount.ToString("D3");

    }

    // Update is called once per frame
    void Update()
    {
        //UI�Ɏc����\��
        this.plateAmountText.GetComponent<Text>().text = this.plateAmount.ToString("D3");
        this.cubeAmountText.GetComponent<Text>().text = this.cubeAmount.ToString("D3");
    }

    //Plate�̐����ƌ������炵��UI�\��
    public void plateButtonDown()
    {
        if (plateAmount >0)
        {
            Vector3 plateButtonPos = plateButton.transform.position;
            Vector3 plateGenPosSc = new Vector3(plateButtonPos.x + 100, plateButtonPos.y, plateButtonPos.z + 30);
            Vector3 plateGenPos = Camera.main.ScreenToWorldPoint(plateGenPosSc);

            GameObject plate = Instantiate(platePrefab);
            plate.transform.position = plateGenPos;

            plateAmount -= 1;   //�p�[�c�𐶐������琔�����炷
        }
    }

    //Cube�̐����ƌ������炵��UI�\��
    public void cubeButtonDown()
    {
        if(cubeAmount > 0)
        {
            Vector3 cubeButtonPos = cubeButton.transform.position;
            Vector3 cubeGenPosSc = new Vector3(cubeButtonPos.x + 100, cubeButtonPos.y, cubeButtonPos.z + 30);
            Vector3 cubeGenPos = Camera.main.ScreenToWorldPoint(cubeGenPosSc);

            GameObject cube = Instantiate(cubePrefab);
            cube.transform.position = cubeGenPos;

            cubeAmount -= 1;   //�p�[�c�𐶐������琔�����炷
        }
    }

}