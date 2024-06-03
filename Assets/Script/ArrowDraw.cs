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
            //�x�N�g���̒���
            float size = dist.magnitude;
            //�p�x
            float angleRad = Mathf.Atan2 (dist.y, dist.x);
            //�摜�̈ړ�
            arrowImage.rectTransform.position = clickPos;
            //�摜�̉�]
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            //�摜�̃X�P�[��
            arrowImage.rectTransform.sizeDelta=new Vector2 (size, size);
        }
        if (Input.GetMouseButtonUp(0))
        {
            arrowImage.gameObject.SetActive(false);
        }
    }
}
