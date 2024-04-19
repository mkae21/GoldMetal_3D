using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall : MonoBehaviour
{
    Rigidbody rigid;// 컴포넌트를 담을 변수
    
    // Start is called before the first frame update
    void Start()//단한번만 실행
    {
        rigid = GetComponent<Rigidbody>();//컴포넌트를 가져옴'
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, 0, v);

        rigid.AddForce(vec,ForceMode.Impulse);
    }

    /*Is trigger에 check되어 있으면 물리현상 무시하고 코드에 의한 동작만 한다.
     *OnTrigger는 콜라이더가 계속 충돌 하고 있을 때 호출한다.
     *이는 '물리적'인 충돌을 이야기 하는 것이 아닌 collider의 영역이 겹쳤는가 판별한다.
     *즉, 물리적인 충돌이 아니기 때문에 충돌 정보가 존재하지 않는다.
     */
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Cube")
            rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
    }
}
