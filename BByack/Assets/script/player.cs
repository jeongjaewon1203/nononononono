using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    public GameObject Player;       //플레이어
    public Rigidbody rigidbody;     //플레이어의 rigidbody
    public float Force = 100;       // 올라가는 힘
    public float FORCE = 50;        //좌우로 가는 힘
    public float time = 3;          // 게임 시작 시간
    public TMP_Text UIText;         // 시작 시간 UI

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.useGravity = false;       //Rigidbody 를 끈다. 
        UIText.text = ("3");                //시작할때 3으로 띄워준다
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;                 //우리가 설정한 시간 - 찐 시간
        UIText.text = time.ToString("F0");      //화면에 시간초를 띄워주세요
        if (time <= 0)                          //시간이 0보다 작거나 같을때
        {
            time = 0;                           //시간 0초로 고정
            rigidbody.useGravity = true;        //중력 허용
        }

        if (rigidbody.useGravity == true)       
        {
            if (Input.GetMouseButtonDown(0))                //만약 마우스 좌클릭을 했다면
            {
                rigidbody.velocity = Vector2.zero;          //힘이 겹쳐지지 않도록 속력을 0으로 설정 
                rigidbody.AddForce(Vector2.up * Force);     //위로 가는 힘을 rigidbody에 추가
                rigidbody.AddForce(Vector2.left * FORCE);   //왼쪽으로 가는 힘을 rigidbody에 추가
            }
            if (Input.GetMouseButtonDown(1))                //만약 마우스 우클릭을 했다면   
            {
                rigidbody.velocity = Vector2.zero;          
                rigidbody.AddForce(Vector2.up * Force);        
                rigidbody.AddForce(Vector2.right * FORCE);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)  //콜라이더가 닿았을때
    {
        if (collision.gameObject.CompareTag("wall"))    //만약 콜라이더의 게임오브젝트 태그가 wall이라면
        {
            rigidbody.useGravity = false ;              
            Destroy(Player.gameObject);                 //게임 오브젝트 파괴
        }
    }
}
