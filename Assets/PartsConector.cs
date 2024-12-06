using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PartsConector : MonoBehaviour
{
    public Transform otherObject; // �A���Ώۂ̃I�u�W�F�N�g
    private float connectionDistance = 5.0f; // �A�����鋗��
    public Vector3 leftOffset;  //�����̖ʂ̃I�t�Z�b�g
    public Vector3 rightOffset; //�E���̖ʂ̃I�t�Z�b�g




    void Update()
    {
        // ���̃I�u�W�F�N�g�Ƃ̋������v�Z
        float distance = Vector3.Distance(transform.position, otherObject.position);

        // �������w�肵���A�������ȓ��ł���ΘA��
        if (distance <= connectionDistance)
        {
            ConnectObjects();
        }

        Debug.Log(otherObject.transform.position);
    }

    void ConnectObjects()
    {
        //�����̖ʂƉE���̖ʂ̈ʒu���v�Z
        Vector3 leftPosition = otherObject.position + leftOffset;
        Vector3 rightPosition = otherObject.position + rightOffset;

        //�����̖ʂƉE���̖ʂ̋������v�Z
        float leftDistance = Vector3.Distance(transform.position, leftPosition);
        float rightDistance = Vector3.Distance(transform.position, rightPosition);

        //�߂����̖ʂɘA��
        if (leftDistance < rightDistance)
        {
            transform.position = leftPosition;
        }
        else
        {
            transform.position = rightPosition;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Connectable"))
        {
            otherObject = other.transform;
        }
    }
}