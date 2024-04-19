using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Transform playerTrasnform;
    Vector3 offset;

    /*
     * FindGameObjectWithTag()�� �־��� �±׷� ������Ʈ �˻�
     */
    void Awake()
    {
        playerTrasnform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTrasnform.position;
    }
    /* Update���Ŀ� ����Ǵ� ���� LateUpdate
     * UI,Camera Update�� ���� ���⼭ ������Ʈ �ȴ�.
     */
    void LateUpdate()
    {
        //offset��ŭ �ڿ� �־�� �Ѵ�.
        transform.position = playerTrasnform.position + offset;
    }

}
