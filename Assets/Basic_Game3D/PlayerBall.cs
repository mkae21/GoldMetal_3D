using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // restart 하기 위해서 꼭 가져와야 함

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    bool isJump;
    public int itemCount;
    public GameManagerLogic manager;
    Rigidbody rigid;
    private void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)//jump가 false일 때 스페이스 눌렀을 때
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0 ,v),ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
            isJump = false;
    }


    /*OnTriggerEnter은 충돌이 났을 때를 지칭한다.
     * other.gameObject.GetComponent<해당 스크립트>
     * gameObject는 해당 스크립트가 들어가 있는 인스턴스 '자기 자신',변수가 기본적으로 선언 되어있음
     * SetActive()는 활성화/비활성화 설정 가능
     * tag는 오브젝트를 구분하는 단순한 문자열
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            /*
             * PlayerBall player은 PlayerBall 스크립트가 부착된 게임 오브젝트에 대한 참조를 가진다.
             * itemCount를 조작하기 위해서
             * other로부터 PlayerBall이라는 스크립트를 가져오는 역할을 합니다. 
             * 이는 해당 게임 오브젝트에 부착된 PlayerBall 스크립트를 찾아서 그것에 대한 참조를 반환합니다.
             * Player은 실체가 아닌 참조하는 것 (class 개념에서는)
             * "PlayerBall 스크립트`는 PlayerBall 타입의 클래스를 정의하고 있다"
             * 즉, PlayerBall 스크립트는 PlayerBall type이라 할 수 있다.
             */
            itemCount++;            
            other.gameObject.SetActive(false);
        }
        else if(other.tag == "Point")
        {   
            //Find 계열의 함수는 부하를 초래할 수 있으므로 피하는 것을 권장, 최적화가 중요하다면 사용 안함
            //GameObject.FindGameObjectsWithTag();
            if(itemCount == manager.totalItemCount)
            {
                /*game clear
                 *원래는 다음에 올 Scene을 Load해야 한다.
                 */
                SceneManager.LoadScene("NextLevel");
            }
            else
            {   /*restart*/
                SceneManager.LoadScene("Basic_3DGame");
            }
        }
    }
}
