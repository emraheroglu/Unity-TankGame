using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddRelativeForce(Vector3.forward * 500);

        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("PlayerTank"))
            other.GetComponent<PlayerTankController>().DamageTake();
        else if(other.name.Equals("BotTank"))
            other.GetComponent<BotTankController>().DamageTake();
        if (!other.name.Equals("Cube") && !other.name.Equals("Cylinder"))
            Destroy(gameObject);

    }

}
