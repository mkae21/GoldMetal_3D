using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ItemCan : MonoBehaviour
{
    public float rotateSpeed;
    void Update()
    {
        /*
         * Rotate()�Լ��� �Ű� ������ 'ȸ�� ũ��'�� �䱸�Ѵ�.
         * ���� ���ʹ� �̹� ���� �Ǿ��־ new�� ������� �ʾƵ� ������.
         * �����̴� ���� �����ؾ� �ϱ� ������ deltatime�� �־���� �Ѵ�.
         * �⺻������ local ��ǥ�踦 ����ϱ� ������ Space.World�� Global ��ǥ��� �ٲ۴�.
         */
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime,Space.World);

    }


}
