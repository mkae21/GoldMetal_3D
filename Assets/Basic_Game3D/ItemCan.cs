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
         * Rotate()함수는 매개 변수로 '회전 크기'만 요구한다.
         * 방향 벡터는 이미 정의 되어있어서 new를 사용하지 않아도 괜찮다.
         * 움직이는 값이 동일해야 하기 때문에 deltatime을 넣어줘야 한다.
         * 기본값으로 local 좌표계를 사용하기 때문에 Space.World로 Global 좌표계로 바꾼다.
         */
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime,Space.World);

    }


}
