using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsController : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
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
        //マウスドラッグするとXZ平面のみを移動するようになる(Y=0)
        Vector3 mousePosition = GetMouseWorldPos() + mOffset;
        transform.position = new Vector3(mousePosition.x, 0, mousePosition.z);
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