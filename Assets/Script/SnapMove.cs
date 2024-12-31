using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapMove : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public float gridSize = 10f; // グリッドのサイズ

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
        // マウスドラッグでオブジェクトを移動し、XZ平面にスナップさせる
        Vector3 mousePosition = GetMouseWorldPos() + mOffset;
        Vector3 targetPosition = new Vector3(mousePosition.x, 0, mousePosition.z);

        // グリッドにスナップさせた位置を計算
        Vector3 snapPosition = new Vector3(
            Mathf.Round(targetPosition.x / gridSize) * gridSize,
            0,
            Mathf.Round(targetPosition.z / gridSize) * gridSize
        );

        // オブジェクトをスナップ位置に移動
        transform.position = snapPosition;
    }
}