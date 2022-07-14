using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private GameObject effectObject;
    public float speedRotate = 10;

    private void Update()
    {
        transform.Rotate(Vector3.up * speedRotate * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerControl>())
        {
            GameControl.instance.OnCoinCollect?.Invoke();

            for (int i = 0; i <= 10; i++)
            {
                GameObject star = Instantiate(effectObject, transform.position, Quaternion.identity);
                star.GetComponent<Rigidbody>().AddForce((Vector3.up * Random.Range(5,40)) + Vector3.left*Random.Range(-15,15) + Vector3.forward*Random.Range(0, 25)); 
            }

            Destroy(gameObject);
        }
    }
}
