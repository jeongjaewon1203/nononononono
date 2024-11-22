using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    public GameObject Player;       //�÷��̾�
    public Rigidbody rigidbody;     //�÷��̾��� rigidbody
    public float Force = 100;       // �ö󰡴� ��
    public float FORCE = 50;        //�¿�� ���� ��
    public float time = 3;          // ���� ���� �ð�
    public TMP_Text UIText;         // ���� �ð� UI

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.useGravity = false;       //Rigidbody �� ����. 
        UIText.text = ("3");                //�����Ҷ� 3���� ����ش�
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;                 //�츮�� ������ �ð� - �� �ð�
        UIText.text = time.ToString("F0");      //ȭ�鿡 �ð��ʸ� ����ּ���
        if (time <= 0)                          //�ð��� 0���� �۰ų� ������
        {
            time = 0;                           //�ð� 0�ʷ� ����
            rigidbody.useGravity = true;        //�߷� ���
        }

        if (rigidbody.useGravity == true)       
        {
            if (Input.GetMouseButtonDown(0))                //���� ���콺 ��Ŭ���� �ߴٸ�
            {
                rigidbody.velocity = Vector2.zero;          //���� �������� �ʵ��� �ӷ��� 0���� ���� 
                rigidbody.AddForce(Vector2.up * Force);     //���� ���� ���� rigidbody�� �߰�
                rigidbody.AddForce(Vector2.left * FORCE);   //�������� ���� ���� rigidbody�� �߰�
            }
            if (Input.GetMouseButtonDown(1))                //���� ���콺 ��Ŭ���� �ߴٸ�   
            {
                rigidbody.velocity = Vector2.zero;          
                rigidbody.AddForce(Vector2.up * Force);        
                rigidbody.AddForce(Vector2.right * FORCE);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)  //�ݶ��̴��� �������
    {
        if (collision.gameObject.CompareTag("wall"))    //���� �ݶ��̴��� ���ӿ�����Ʈ �±װ� wall�̶��
        {
            rigidbody.useGravity = false ;              
            Destroy(Player.gameObject);                 //���� ������Ʈ �ı�
        }
    }
}
