using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Transform playerTrasnform;
    Vector3 offset;

    /*
     * FindGameObjectWithTag()는 주어진 태그로 오브젝트 검색
     */
    void Awake()
    {
        playerTrasnform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTrasnform.position;
    }
    /* Update이후에 실행되는 것이 LateUpdate
     * UI,Camera Update가 보통 여기서 업데이트 된다.
     */
    void LateUpdate()
    {
        //offset만큼 뒤에 있어야 한다.
        transform.position = playerTrasnform.position + offset;
    }

}
