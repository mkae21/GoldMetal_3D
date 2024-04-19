using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // restart �ϱ� ���ؼ� �� �����;� ��

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
        if (Input.GetButtonDown("Jump") && !isJump)//jump�� false�� �� �����̽� ������ ��
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


    /*OnTriggerEnter�� �浹�� ���� ���� ��Ī�Ѵ�.
     * other.gameObject.GetComponent<�ش� ��ũ��Ʈ>
     * gameObject�� �ش� ��ũ��Ʈ�� �� �ִ� �ν��Ͻ� '�ڱ� �ڽ�',������ �⺻������ ���� �Ǿ�����
     * SetActive()�� Ȱ��ȭ/��Ȱ��ȭ ���� ����
     * tag�� ������Ʈ�� �����ϴ� �ܼ��� ���ڿ�
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            /*
             * PlayerBall player�� PlayerBall ��ũ��Ʈ�� ������ ���� ������Ʈ�� ���� ������ ������.
             * itemCount�� �����ϱ� ���ؼ�
             * other�κ��� PlayerBall�̶�� ��ũ��Ʈ�� �������� ������ �մϴ�. 
             * �̴� �ش� ���� ������Ʈ�� ������ PlayerBall ��ũ��Ʈ�� ã�Ƽ� �װͿ� ���� ������ ��ȯ�մϴ�.
             * Player�� ��ü�� �ƴ� �����ϴ� �� (class ���信����)
             * "PlayerBall ��ũ��Ʈ`�� PlayerBall Ÿ���� Ŭ������ �����ϰ� �ִ�"
             * ��, PlayerBall ��ũ��Ʈ�� PlayerBall type�̶� �� �� �ִ�.
             */
            itemCount++;            
            other.gameObject.SetActive(false);
        }
        else if(other.tag == "Point")
        {   
            //Find �迭�� �Լ��� ���ϸ� �ʷ��� �� �����Ƿ� ���ϴ� ���� ����, ����ȭ�� �߿��ϴٸ� ��� ����
            //GameObject.FindGameObjectsWithTag();
            if(itemCount == manager.totalItemCount)
            {
                /*game clear
                 *������ ������ �� Scene�� Load�ؾ� �Ѵ�.
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
