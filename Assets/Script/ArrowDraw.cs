using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;
    private Vector3 clickPos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPos = Input.mousePosition;
            arrowImage.gameObject.SetActive(true);
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 dist = clickPos - Input.mousePosition ;
            //ベクトルの長さ
            float size = dist.magnitude;
            //角度
            float angleRad = Mathf.Atan2 (dist.y, dist.x);
            //画像の移動
            arrowImage.rectTransform.position = clickPos;
            //画像の回転
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            //画像のスケール
            arrowImage.rectTransform.sizeDelta=new Vector2 (size, size);
        }
        if (Input.GetMouseButtonUp(0))
        {
            arrowImage.gameObject.SetActive(false);
        }
    }
}
