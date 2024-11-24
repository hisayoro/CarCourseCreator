using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGenerator : MonoBehaviour
{
    //PlatePrefab������
    public GameObject platePrefab;

    //�p�[�c�𐶐�����UI�̃{�^��
    public Button partsButton;

    //�I�u�W�F�N�g���o��������X�N���[�����W
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

        Debug.Log("�{�^���X�N���[�����W " + partsButtonPos);
        Debug.Log("�{�^���X�N���[�����W�� " + partsGenPosSc);
        Debug.Log("���[���h���W " + plateGenPos);

        GameObject plate = Instantiate(platePrefab);
        plate.transform.position = plateGenPos;
    }
}