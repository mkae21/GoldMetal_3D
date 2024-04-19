using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall : MonoBehaviour
{
    Rigidbody rigid;// ������Ʈ�� ���� ����
    
    // Start is called before the first frame update
    void Start()//���ѹ��� ����
    {
        rigid = GetComponent<Rigidbody>();//������Ʈ�� ������'
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, 0, v);

        rigid.AddForce(vec,ForceMode.Impulse);
    }

    /*Is trigger�� check�Ǿ� ������ �������� �����ϰ� �ڵ忡 ���� ���۸� �Ѵ�.
     *OnTrigger�� �ݶ��̴��� ��� �浹 �ϰ� ���� �� ȣ���Ѵ�.
     *�̴� '������'�� �浹�� �̾߱� �ϴ� ���� �ƴ� collider�� ������ ���ƴ°� �Ǻ��Ѵ�.
     *��, �������� �浹�� �ƴϱ� ������ �浹 ������ �������� �ʴ´�.
     */
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Cube")
            rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
    }
}
