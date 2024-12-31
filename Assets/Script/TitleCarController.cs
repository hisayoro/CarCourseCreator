using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCarController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private float velocityZ = 30f;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidboryコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //ローカル座標系のZ方向に速度を与える
        this.myRigidbody.velocity = this.transform.TransformDirection(new Vector3(0, 0, this.velocityZ));
    }
}
