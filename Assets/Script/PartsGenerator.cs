using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsGenerator : MonoBehaviour
{
    //�I�u�W�F�N�g���i�[
    public GameObject carPrefab;
    public GameObject straightSPrefab;
    public GameObject straightLPrefab;
    public GameObject curveSPrefab;
    public GameObject curveLPrefab;

    //�c���Ǘ�����I�u�W�F�N�g�̃e�L�X�g
    private GameObject carAmountText;
    private GameObject straightSAmountText;
    private GameObject straightLAmountText;
    private GameObject curveSAmountText;
    private GameObject curveLAmountText;

    //�I�u�W�F�N�g���Ăяo��UI�̃{�^��
    public Button carButton;
    public Button straightSButton;
    public Button straightLButton;
    public Button curveSButton;
    public Button curveLButton;

    //�I�u�W�F�N�g�̌��Ǘ��A�����l
    public int carAmount;
    public int straightSAmount;
    public int straightLAmount;
    public int curveSAmount;
    public int curveLAmount;


    // Start is called before the first frame update
    void Start()
    {
        //car�̏������ʂ�\��
        this.carAmount = 1;
        this.carAmountText = GameObject.Find("CarAmountText");
        this.carAmountText.GetComponent<Text>().text = this.carAmount.ToString("D3");

        //straight(S)�̏������ʂ�\��
        this.straightSAmount = 30;
        this.straightSAmountText = GameObject.Find("StraightSAmountText");
        this.straightSAmountText.GetComponent<Text>().text = this.straightSAmount.ToString("D3");

        //straight(L)�̏������ʂ�\��
        this.straightLAmount = 10;
        this.straightLAmountText = GameObject.Find("StraightLAmountText");
        this.straightLAmountText.GetComponent<Text>().text = this.straightLAmount.ToString("D3");

        //curve(S)�̏������ʂ�\��
        this.curveSAmount = 10;
        this.curveSAmountText = GameObject.Find("CurveSAmountText");
        this.curveSAmountText.GetComponent<Text>().text = this.curveSAmount.ToString("D3");

        //curve(L)�̏������ʂ�\��
        this.curveLAmount = 10;
        this.curveLAmountText = GameObject.Find("CurveLAmountText");
        this.curveLAmountText.GetComponent<Text>().text = this.curveLAmount.ToString("D3");
    }

    // Update is called once per frame
    void Update()
    {
        //UI�Ɏc����\���E�E�E�I�u�W�F�N�g�̎�ނ��ׂď����o��
        this.carAmountText.GetComponent<Text>().text = this.carAmount.ToString("D3");
        this.straightSAmountText.GetComponent<Text>().text = this.straightSAmount.ToString("D3");
        this.straightLAmountText.GetComponent<Text>().text = this.straightLAmount.ToString("D3");
        this.curveSAmountText.GetComponent<Text>().text = this.curveSAmount.ToString("D3");
        this.curveLAmountText.GetComponent<Text>().text = this.curveLAmount.ToString("D3");
    }
    //car�̐����ƌ������炵��UI�\��
    public void CarButtonDown()
    {
        if (carAmount > 0)
        {
            //�Ăяo���{�^���̏ꏊ��ǂݍ��݁A�I�u�W�F�N�g���Ăяo���ꏊ�����߂�
            Vector3 carButtonPos = carButton.transform.position;
            Vector3 carGenPosSc = new Vector3(carButtonPos.x + 100, carButtonPos.y-50, carButtonPos.z+70);
            Vector3 carGenPos = Camera.main.ScreenToWorldPoint(carGenPosSc);

            GameObject car = Instantiate(carPrefab);
            car.transform.position = carGenPos;

            carAmount -= 1;   //�p�[�c�𐶐������琔�����炷
        }
    }

    //�p�[�c�̌Ăяo���ƌ������炷
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