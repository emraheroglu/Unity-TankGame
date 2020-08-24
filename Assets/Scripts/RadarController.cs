using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarController : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,30*Time.deltaTime,0);
        Radar();

        
    }

    void Radar()
    {
        Debug.DrawRay(transform.position, transform.forward * 15, Color.green);

        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward, out hit, 15))
        {

            if(hit.transform.name.Equals("PlayerTank"))
            {
                transform.root.GetComponent<BotTankController>().followingPlayer = true;
            }
        }
    }
}
