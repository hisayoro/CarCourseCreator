using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //�O�����̑��x
    private float velocityZ = 30.0f;

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
        this.myRigidbody.velocity = transform.TransformDirection(new Vector3(0, 0, this.velocityZ));
    }
}
