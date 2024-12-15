using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsController : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private bool isSelected = false;    //�I�u�W�F�N�g��]�p

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        //�}�E�X�h���b�O�����XZ���ʂ݂̂��ړ�����悤�ɂȂ�(Y=0)
        Vector3 mousePosition = GetMouseWorldPos() + mOffset;
        transform.position = new Vector3(mousePosition.x, 0, mousePosition.z);
    }

    //�}�E�X��ɂ���p�[�c�������E�N���b�N�ŉ�]������E�E�E�n�܂�
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //���C���쐬
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); RaycastHit hit;

            // ���C�L���X�g�����s���ăI�u�W�F�N�g�����o
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.transform == transform)
                {
                    isSelected = true;
                    RotateObject();
                }
                else
                {
                    isSelected = false;
                }
            }
        }
    }
    void RotateObject()
    {
        if (isSelected)
        {
            transform.Rotate(0, 90, 0, Space.Self);
        }
    }
    //�}�E�X��ɂ���p�[�c�������E�N���b�N�ŉ�]������E�E�E�I���
}