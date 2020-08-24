using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotTankController : MonoBehaviour
{
    public static BotTankController instance;

    public List<GameObject> pathList;

    public GameObject player;
    public GameObject bullet;

    public Text botHpText;

    int hp;
    int pathIndex;
    public bool followingPlayer;
    public float speed;
    float timer;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timer = 2;
    }

    void Update()
    {
        if(!followingPlayer)
            MoveOnPath();
        if (followingPlayer)
            FollowPlayer();
    }

    public void MoveOnPath()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(pathList[pathIndex].transform.position.x, transform.position.y, pathList[pathIndex].transform.position.z), Time.deltaTime*speed);
        transform.LookAt(new Vector3(pathList[pathIndex].transform.position.x, transform.position.y, pathList[pathIndex].transform.position.z));
        

        if(Mathf.Abs(transform.position.x - pathList[pathIndex].transform.position.x) <= 1 && Mathf.Abs(transform.position.z - pathList[pathIndex].transform.position.z) <= 1)
        {
            if (pathIndex < pathList.Count-1)
                pathIndex ++;
            else
                pathIndex = 0;
        }
    }

    public void FollowPlayer()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        if (Vector3.Distance(transform.position,player.transform.position) < 5 )
        {
            if(timer < Time.time)
            {
            Instantiate(bullet, transform.GetChild(0).position, transform.rotation);
            timer = Time.time + 2;
            }
        }

        else
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), Time.deltaTime * speed);
    }
    public void DamageTake()
    {
        hp -= 10;
        botHpText.text = "Bot HP : " + hp;
        if (hp <= 0)
            hp = 100;
    }
}
