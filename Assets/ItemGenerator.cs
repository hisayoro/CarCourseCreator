using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //PlatePrefab������
    public GameObject platePrefab;
    //Plate�̐ݒu�ʒu���Ăяo�����Ƃɂ��炷
    private float posX = 0;

    //�I�u�W�F�N�g���o��������X�N���[�����W
    private Vector3 plateGenPos = new Vector3(10, 10, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Plate�̐���
        if (Input.GetMouseButtonDown(1))
        {
            GameObject plate = Instantiate(platePrefab);
            //plate.transform.position = new Vector3(this.posX, 0, 0);
            //this.posX += 2;

            plate.transform.position = plateGenPos;

           
        }
    }
}