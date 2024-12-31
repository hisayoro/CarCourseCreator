using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PartsController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 mOffset;
    private float mZCoord;
    private float gridSize = 5f; // �O���b�h�̃T�C�Y

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
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        
        //�}�E�X�h���b�O�����XZ���ʂ݂̂��ړ�����悤�ɂȂ�(Y=0)
        Vector3 mousePosition = GetMouseWorldPos() + mOffset;
        Vector3 targetPosition = new Vector3(mousePosition.x, 0, mousePosition.z);

        // �O���b�h�ɃX�i�b�v�������ʒu���v�Z
        Vector3 snapPosition = new Vector3(
            Mathf.Round(targetPosition.x / gridSize) * gridSize,
            0,
            Mathf.Round(targetPosition.z / gridSize) * gridSize);

        // �I�u�W�F�N�g���X�i�b�v�ʒu�Ɉړ�
        transform.position = snapPosition;
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