using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // ��ũ���� �Ǵ� ��׶���
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
        // ������ ���͸��󿡼� ��������
        Vector2 newOffset = mymaterial.mainTextureOffset;

        // ���Ӱ� offset �ٲٱ�
        // x �κ� ���� �ӵ��� ������ �����ؼ� ������
        newOffset.Set(newOffset.x + (scrollSpeed * Time.deltaTime), 0);

        // ���͸��� ������ �� �־��ֱ�
        mymaterial.mainTextureOffset = newOffset;
    }
}
