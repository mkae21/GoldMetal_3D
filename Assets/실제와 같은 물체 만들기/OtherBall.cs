using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBall : MonoBehaviour
{
    MeshRenderer mesh;//MeshRenderer ���� ����
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        material = mesh.material;
    }

    //���� �̺�Ʈ ó�� �Լ��� On�� ���δ�

    /*
     * Color(r,g,b)�� �⺻ ���� Ŭ����
     * Collsion�� �浹 ���� Ŭ����
     * 
     */

    private void OnCollisionEnter(Collision collision)//������ �浹�� ������ �� ȣ�� �Ǵ� �Լ�
    {
        if (collision.gameObject.name == "My Ball")
            material.color = new Color(0, 0, 0);//���������� ����

    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "My Ball" )
            material.color = new Color(1, 1, 1);
    }

}
