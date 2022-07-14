using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndDestroy : MonoBehaviour
{
    public float period = 2f;

    void Update()
    {
        transform.Rotate(Vector3.forward * 50);

        if ((period -= Time.deltaTime) <= 0)
            Destroy(gameObject);
    }
}
