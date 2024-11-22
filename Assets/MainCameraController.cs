using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    //カメラの移動量
    private float moveAmount = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //カメラを前後左右に移動（矢印キー）
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

        //カメラを回転（A：反時計回り、S：時計回り）
        if ((Input.GetKey(KeyCode.A)))
        {
            transform.Rotate(new Vector3(0, moveAmount, 0));
        }
        if ((Input.GetKey(KeyCode.S)))
        {
            transform.Rotate(new Vector3(0, -moveAmount, 0));
        }
        //カメラをズーム（Z：イン、X：アウト）

    }
}
