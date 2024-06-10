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
        // rb = GetComponent<Rigidbody>(); // GameObject‚ÍÈ—ª‰Â”\
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Õ“Ë‚µ‚½");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("ÚG’†");
        //Õ“Ë‚µ‚Ä‚¢‚é“_‚Ìî•ñ‚ª•¡”Ši”[‚³‚ê‚Ä‚¢‚é
        ContactPoint[] contacts = collision.contacts;
        //0”Ô–Ú‚ÌÕ“Ëî•ñ‚©‚çAÕ“Ë‚µ‚Ä‚¢‚é“_‚Ì–@ü‚ğæ“¾
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
        Debug.Log("—£’E‚µ‚½");
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
