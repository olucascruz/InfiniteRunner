using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorRobot : MonoBehaviour
{   
    public GameObject[] robotPrefabs;
    public float delayInitial;
    public float delayBetweenRobots;
    

    private void Start()
    {
        InvokeRepeating("GenerateRobots", delayInitial, delayBetweenRobots);
    }

    private void GenerateRobots(){
        var lengthRobots = robotPrefabs.Length;
        var randomIndex = Random.Range(0, lengthRobots);
        var robotPrefab = robotPrefabs[randomIndex];
        Instantiate(robotPrefab, transform.position, robotPrefab.transform.rotation);
    }
}
