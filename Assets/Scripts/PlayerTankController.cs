using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTankController : MonoBehaviour
{
    Rigidbody rb;

    public int speed;
    int hp;

    public Text playerHpText;
    public GameObject bullet;

    float y;
    float z;
    void Start()
    {
        hp = 100;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTank();
        Fire();
    }

    public void MoveTank()
    {
        y = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        rb.AddRelativeForce(0, 0, z*speed);
        rb.AddTorque(0, y*speed, 0);
    }

    public void DamageTake()
    {
        hp -= 10;
        playerHpText.text = "Player HP : " + hp;
        if(hp <= 0)
            hp = 100;
    }

    public void Fire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet,transform.GetChild(0).position, transform.rotation);
        }
    }
}
