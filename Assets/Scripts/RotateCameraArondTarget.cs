using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraArondTarget : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private float X;
    private float x;
    private bool demo = false;

    void Start()
    {
        offset = new Vector3(0, 0, -8);
    }

    void Update()
    {
        if (GameControl.instance.finish)
        {
            if(!demo)
            {
                transform.position = target.position + offset;
                demo = true;
            }

            X = transform.localEulerAngles.y - x;

            transform.localEulerAngles = new Vector3(15f, X, 0);
            transform.position = transform.localRotation * offset + target.position;

            x = 10 * Time.deltaTime;
        }
    }
}
