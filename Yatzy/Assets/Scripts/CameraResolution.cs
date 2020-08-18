using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;

        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;

        float scaleheight = ( (float)Screen.width / Screen.height ) / ( (float)9 / 16 );    // 핸드폰 비율 을 우리가 원하는 비율로 나눔
        float scalewidth = 1f / scaleheight;

        // 핸드폰 비율에 따라 해상도를 수정
        if(scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
