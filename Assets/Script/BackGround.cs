using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // 스크롤이 되는 백그라운드
    public float scrollSpeed = 0.3f;
    private Material mymaterial;

    // Start is called before the first frame update
    void Start()
    {
        mymaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // 오프셋 머터리얼에서 가져오기
        Vector2 newOffset = mymaterial.mainTextureOffset;

        // 새롭게 offset 바꾸기
        // x 부분 값을 속도에 프레임 보정해서 더해줌
        newOffset.Set(newOffset.x + (scrollSpeed * Time.deltaTime), 0);

        // 머터리얼에 오프셋 값 넣어주기
        mymaterial.mainTextureOffset = newOffset;
    }
}
