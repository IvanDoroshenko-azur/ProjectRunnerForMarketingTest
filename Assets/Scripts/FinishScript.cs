using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField] private GameObject effectObjfinish;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerControl>())
        {
            GameControl.instance.OnFinishLevel?.Invoke();

            for (int i = 0; i <= 50; i++)
            {
                GameObject ef = Instantiate(effectObjfinish, transform.position + Vector3.up * 5 + Vector3.forward *2, Quaternion.identity);
                ef.GetComponent<Rigidbody>().AddForce((Vector3.right * Random.Range(-15, 15)) + (Vector3.down * Random.Range(-15, 15)));
            }
        }
    }
}
