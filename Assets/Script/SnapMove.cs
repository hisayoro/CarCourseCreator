using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapMove : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public float gridSize = 10f; // �O���b�h�̃T�C�Y

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
        // �}�E�X�h���b�O�ŃI�u�W�F�N�g���ړ����AXZ���ʂɃX�i�b�v������
        Vector3 mousePosition = GetMouseWorldPos() + mOffset;
        Vector3 targetPosition = new Vector3(mousePosition.x, 0, mousePosition.z);

        // �O���b�h�ɃX�i�b�v�������ʒu���v�Z
        Vector3 snapPosition = new Vector3(
            Mathf.Round(targetPosition.x / gridSize) * gridSize,
            0,
            Mathf.Round(targetPosition.z / gridSize) * gridSize
        );

        // �I�u�W�F�N�g���X�i�b�v�ʒu�Ɉړ�
        transform.position = snapPosition;
    }
}