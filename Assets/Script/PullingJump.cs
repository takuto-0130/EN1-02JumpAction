using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPos;
    [SerializeField]
    private float jumpPower = 10;
    private bool isCanJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // rb = GetComponent<Rigidbody>(); // GameObjectは省略可能
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("衝突した");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("接触中");
        //衝突している点の情報が複数格納されている
        ContactPoint[] contacts = collision.contacts;
        //0番目の衝突情報から、衝突している点の法線を取得
        Vector3 ohterNormaal = contacts[0].normal;

        Vector3 upVector = new Vector3(0,1,0);

        float dotUN = Vector3.Dot(upVector, ohterNormaal);

        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

        if(dotDeg <= 45)
        {
            isCanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("離脱した");
        isCanJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickPos = Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButtonUp(0))
        {
            Vector3 dist = clickPos - Input.mousePosition;
            if(dist.sqrMagnitude == 0) { return; }
            rb.velocity = dist.normalized * jumpPower;
        }
    }
}
