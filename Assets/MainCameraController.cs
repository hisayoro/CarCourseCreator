using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    //�J�����̈ړ���
    private float moveAmount = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //�J������O�㍶�E�Ɉړ��i���L�[�j
        if ((Input.GetKey(KeyCode.LeftArrow)))
        {
            this.transform.Translate(-moveAmount, 0, 0, Space.Self);
        }
        if ((Input.GetKey(KeyCode.RightArrow)))
        {
            this.transform.Translate(moveAmount, 0, 0, Space.Self);
        }
        if ((Input.GetKey(KeyCode.UpArrow)))
        {
            this.transform.Translate(0, 0, moveAmount, Space.Self);
        }
        if ((Input.GetKey(KeyCode.DownArrow)))
        {
            this.transform.Translate(0, 0, -moveAmount, Space.Self);
        }

        //�J��������]�iA�F�����v���AS�F���v���j
        if ((Input.GetKey(KeyCode.A)))
        {
            transform.Rotate(new Vector3(0, moveAmount, 0));
        }
        if ((Input.GetKey(KeyCode.S)))
        {
            transform.Rotate(new Vector3(0, -moveAmount, 0));
        }
        //�J�������Y�[���iZ�F�C���AX�F�A�E�g�j

    }
}
