using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

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

    
    /*
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }
    */

    void OnMouseDrag()
    {
        //�}�E�X�h���b�O�����XZ���ʂ݂̂��ړ�����悤�ɂȂ�(Y=0)
        Vector3 mousePosition = GetMouseWorldPos() + mOffset;
        transform.position = new Vector3(mousePosition.x, 0, mousePosition.z);
    }

}