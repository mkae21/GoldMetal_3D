using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBall : MonoBehaviour
{
    MeshRenderer mesh;//MeshRenderer 넣을 변수
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        material = mesh.material;
    }

    //보통 이벤트 처리 함수는 On을 붙인다

    /*
     * Color(r,g,b)는 기본 색상 클래스
     * Collsion은 충돌 정보 클래스
     * 
     */

    private void OnCollisionEnter(Collision collision)//물리적 충돌이 시작할 때 호출 되는 함수
    {
        if (collision.gameObject.name == "My Ball")
            material.color = new Color(0, 0, 0);//검정색으로 설정

    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "My Ball" )
            material.color = new Color(1, 1, 1);
    }

}
