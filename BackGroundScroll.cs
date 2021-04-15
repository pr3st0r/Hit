using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    public float speed; // 배경 스크롤 속도
    public Transform[] backgrounds; // 배경 배열

    float leftPosX = 0f; // 배경 끝 X 좌표
    float rightPosX = 0f; // 배경 시작 X 좌표
    float xScreenHalfSize; // 카메라 y 좌표 절반
    float yScreenHalfSize; // 카메라 x 좌표 절반

    void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2);   
        rightPosX = xScreenHalfSize * 2 * backgrounds.Length; 

    }
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(-speed, 0, 0) * Time.deltaTime;   // 배경 배열을 speed 속도로 왼쪽으로 이동

            if (backgrounds[i].position.x < leftPosX)     // 배경의 위치가 화면크기만큼 화면너머로 이동했을때
            {
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.x + rightPosX, nextPos.y, nextPos.z);  
                backgrounds[i].position = nextPos;   // 배경을 배경 배열 끝으로 이동
            }
        }
    }
}