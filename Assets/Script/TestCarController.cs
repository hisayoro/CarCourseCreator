using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCarController : MonoBehaviour
{
    //前方向の速度
    public float velocityZ = 0;
    private bool OnOff = false;

    //移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;


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

    public void CarEngineOnOff()
    {
        if (OnOff == false)
        {
            velocityZ = 10.0f;
            OnOff = true;
        }
        else
        {
            velocityZ = 0;
            OnOff = false;
        }
    }
}
