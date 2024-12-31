using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PartsController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 mOffset;
    private float mZCoord;
    private float gridSize = 5f; // グリッドのサイズ

    private bool isSelected = false;    //オブジェクト回転用

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
        
        //マウスドラッグするとXZ平面のみを移動するようになる(Y=0)
        Vector3 mousePosition = GetMouseWorldPos() + mOffset;
        Vector3 targetPosition = new Vector3(mousePosition.x, 0, mousePosition.z);

        // グリッドにスナップさせた位置を計算
        Vector3 snapPosition = new Vector3(
            Mathf.Round(targetPosition.x / gridSize) * gridSize,
            0,
            Mathf.Round(targetPosition.z / gridSize) * gridSize);

        // オブジェクトをスナップ位置に移動
        transform.position = snapPosition;
    }

    //マウス上にあるパーツだけを右クリックで回転させる・・・始まり
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //レイを作成
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); RaycastHit hit;

            // レイキャストを実行してオブジェクトを検出
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
    //マウス上にあるパーツだけを右クリックで回転させる・・・終わり
}