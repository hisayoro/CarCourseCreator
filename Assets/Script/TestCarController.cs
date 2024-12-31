using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCarController : MonoBehaviour
{
    //�O�����̑��x
    public float velocityZ = 0;
    private bool OnOff = false;

    //�ړ�������R���|�[�l���g������
    private Rigidbody myRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        //Rigidbory�R���|�[�l���g���擾
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //���[�J�����W�n��Z�����ɑ��x��^����
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
