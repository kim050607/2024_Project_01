using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;                  //���콺 Drag �Ǵ�
    public bool isUsed;                  //��� �Ϸ� üũ
    Rigidbody2D rigidbody2D;             //2D ���� ����

    public int index;                    //���� ��ȣ ����            

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();         //������Ʈ�� ��ü�� ����
        isUsed = false;                                    //�����Ҷ� ����� �ȵǾ��ٰ� �Է�
        rigidbody2D.simulated = false;                     //���� �ൿ�� ó������ �������� �ʰ� ����
    }
    void Start()
    {
        isUsed = false;                                       //�����Ҷ� ����� �ȵǾ��ٰ� �Է�
        rigidbody2D = GetComponent<Rigidbody2D>();            //������Ʈ�� ��ü�� ����
        rigidbody2D.simulated = false;                        //���� �ൿ�� ó������ �������� �ʰ� ����
    }

    void Update()
    {
        if (isUsed)                             //����� �Ϸ�� ������Ʈ�� ������Ʈ ���� �׳� ����������. (���콺 Input ���븦 ���� ����)
            return;

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);      //ȭ�� ��ũ������ ����Ƽ Scene ������ ��ǥ�� �����´�.

            float leftBorder = -5.0f + transform.localScale.x / 2f;  //������ ��ŭ �̵� ����
            float rightBorder = 5.0f - transform.localScale.x / 2f;

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;    // ���콺 ��ġ�� �̵� ���� �Ѱ� �̻�,���Ϸ� ���� ���� �����ؼ� ���д�.
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;                                          //������Ʈ Y�� �� ����
            mousePos.z = 0;                                          //������Ʈ Z�� �� ����
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);  //�� ������Ʈ�� ���콺 ��ġ�� ���Ͼ��ϰ� 0.2����ŭ �̵����� ���󰣴�.
        }

        if (Input.GetMouseButtonDown(0)) Drag();                     //���콺 ��ư�� �������� Drag �Լ� ����
        if (Input.GetMouseButtonUp(0)) Drop();                       //���콺 ��ư�� �������� Drop �Լ� ����

    }


    void Drag()                     //�巡�� �� �� ���� �� �Լ�
    {
        isDrag = true;              //�巡�� ���̴�.(true)
        rigidbody2D.simulated = false;  //���� �ù����̼� �� �� (false)
    }

    void Drop()                     //��� �� �� ���� �� �Լ�
    {
        isDrag = false;                  //�巡�� ���̴�. (false)
        isUsed = true;                   //��� �Ϸ� �Ǿ���. (true)
        rigidbody2D.simulated = true;    //���� �ù����̼� ����� (true)

        GameObject temp = GameObject.FindWithTag("GameManager");                //Scene���� GameManager Tag ������ �ִ� ������Ʈ�� �����´�.
        if (temp != null)                                                       //�ش� ������Ʈ�� ���� ���
        {
            temp.gameObject.GetComponent<GamerManager>().GenObject();           //GameManager �� GenObject �Լ��� ȣ��
        }
    }

    public void Used()
    {
        isDrag = false;                                                        //�巡�� ���̴�.(false)
        isUsed = true;                                                         //��� �Ϸ� �Ǿ���.(true)
        rigidbody2D.simulated = true;                                          //���� �ù����̼� ����� (true)
    }

    public void OnCollisionEnter2D(Collision2D Collision)                      //�ش� ������Ʈ�� �浹 ���� ��  OnCollision2D                                                                               
    {
        if (Collision.gameObject.tag == "Fruit")
        {
            CircleObject temp = Collision.gameObject.GetComponent<CircleObject>();      //���� ��ü���� ���� Class�� �޾ƿ´�.

            if (temp.index == index)                                             //�浹 index�� �� index �� ����.  
            {

                if (gameObject.GetInstanceID() > Collision.gameObject.GetInstanceID())  // 2���� ���ļ� 1���� ����� ���� ID �˻� �� ū�͸�
                {
                    //GameManger���� ��ģ ������Ʈ�� ����
                    GameObject tempGameManger = GameObject.FindWithTag("GameManger");          //Scene���� GameManger Tag ������ �ִ� ������Ʈ�� �����´�.
                   if (tempGameManger != null)                                                //�ش� ������Ʈ�� ���� ���
                   {
                        tempGameManger.gameObject.GetComponent<GamerManager>().MergeObject(index, gameObject.transform.position);
                   }
                    
                   Destroy(temp.gameObject);                                          //�浹�� ��ü ����
                   Destroy(gameObject);                                               //�ڽŵ� ����
                }

            }

        }

    }
}
