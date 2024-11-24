using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PartsConector : MonoBehaviour
{
    public float connectionDistance = 1.0f; // 連結する距離
    public Transform otherObject; // 連結対象のオブジェクト
    public Vector3 leftOffset;
    public Vector3 rightOffset;

    void Update()
    {
        // 他のオブジェクトとの距離を計算
        float distance = Vector3.Distance(transform.position, otherObject.position);

        // 距離が指定した連結距離以内であれば連結
        if (distance <= connectionDistance)
        {
            ConnectObjects();
        }
    }

    void ConnectObjects()
    {
        // 左側の面と右側の面の位置を計算
        Vector3 leftPosition = otherObject.position + leftOffset;
        Vector3 rightPosition = otherObject.position + rightOffset;

        //左側の面と右側の面の距離を計算
        float leftDistance = Vector3.Distance(transform.position, leftPosition);
        float rightDistance = Vector3.Distance(transform.position, rightPosition);

        //近い方の面に連結
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