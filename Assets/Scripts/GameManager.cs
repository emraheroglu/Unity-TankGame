using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        var botController = BotTankController.instance;

        lineRenderer.SetPosition(0, botController.pathList[0].transform.position);
        lineRenderer.SetPosition(1, botController.pathList[1].transform.position);
        lineRenderer.SetPosition(2, botController.pathList[2].transform.position);
        lineRenderer.SetPosition(3, botController.pathList[3].transform.position);
        lineRenderer.SetPosition(4, botController.pathList[4].transform.position);
        lineRenderer.SetPosition(5, botController.pathList[5].transform.position);
        lineRenderer.SetPosition(6, botController.pathList[6].transform.position);
        lineRenderer.SetPosition(7, botController.pathList[7].transform.position);
    }
}
