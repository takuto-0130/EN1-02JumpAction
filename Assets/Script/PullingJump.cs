using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPos;
    [SerializeField]
    private float jumpPower = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // rb = GetComponent<Rigidbody>(); // GameObjectÇÕè»ó™â¬î\
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 dist = clickPos - Input.mousePosition;
            if(dist.sqrMagnitude == 0) { return; }
            rb.velocity = dist.normalized * jumpPower;
        }
    }
}
