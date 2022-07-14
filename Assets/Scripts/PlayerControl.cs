using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10f;
    private float z = 0;
    private Animation anim;
    private int animState = 0;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !GameControl.instance.finish)
        {
            if (animState == 0)
                anim.Play("Run");
            animState = 1;
            z = speed * Time.deltaTime;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + Input.GetAxis("Mouse X"), -1.7f, 1.7f), transform.position.y, transform.position.z + z);
        }
        else if (GameControl.instance.finish)
        {
            if (animState != 2)
                anim.Play("Runtojumpspring");
            animState = 2;
        }
        else
        {
            if (animState == 1)
                anim.Play("Idle");
            animState = 0;
        }
    }
}
