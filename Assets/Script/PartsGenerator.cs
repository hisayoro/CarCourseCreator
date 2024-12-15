using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsGenerator : MonoBehaviour
{
    public GameObject straightPrefab;
    public GameObject curvePrefab;
    private GameObject straightAmountText;
    private GameObject curveAmountText;

    //�p�[�c�𐶐�����UI�̃{�^��
    public Button straightButton;
    public Button curveButton;

    //�p�[�c�̌��Ǘ��A�����l
    public int straightAmount;
    public int curveAmount;


    // Start is called before the first frame update
    void Start()
    {
        //straight�̏������ʂ�\��
        this.straightAmount = 10;
        this.straightAmountText = GameObject.Find("StraightAmountText");
        this.straightAmountText.GetComponent<Text>().text = this.straightAmount.ToString("D3");

        //curve�̏������ʂ�\��
        this.curveAmount = 5;
        this.curveAmountText = GameObject.Find("CurveAmountText");
        this.curveAmountText.GetComponent<Text>().text = this.curveAmount.ToString("D3");
    }

    // Update is called once per frame
    void Update()
    {
        //UI�Ɏc����\��
        this.straightAmountText.GetComponent<Text>().text = this.straightAmount.ToString("D3");
        this.curveAmountText.GetComponent<Text>().text = this.curveAmount.ToString("D3");
    }

    //straight�̐����ƌ������炵��UI�\��
    public void StraightButtonDown()
    {
        if (straightAmount >0)
        {
            Vector3 straightButtonPos = straightButton.transform.position;
            Vector3 straightGenPosSc = new Vector3(straightButtonPos.x + 100, straightButtonPos.y, straightButtonPos.z + 30);
            Vector3 straightGenPos = Camera.main.ScreenToWorldPoint(straightGenPosSc);

            GameObject straight = Instantiate(straightPrefab);
            straight.transform.position = straightGenPos;

            straightAmount -= 1;   //�p�[�c�𐶐������琔�����炷
        }
    }

    //curve�̐����ƌ������炵��UI�\��
    public void CurveButtonDown()
    {
        if(curveAmount > 0)
        {
            Vector3 curveButtonPos = curveButton.transform.position;
            Vector3 curveGenPosSc = new Vector3(curveButtonPos.x + 50, curveButtonPos.y, curveButtonPos.z + 100);
            Vector3 curveGenPos = Camera.main.ScreenToWorldPoint(curveGenPosSc);

            GameObject curve = Instantiate(curvePrefab);
            curve.transform.position = curveGenPos;

            curveAmount -= 1;   //�p�[�c�𐶐������琔�����炷
        }
    }

}