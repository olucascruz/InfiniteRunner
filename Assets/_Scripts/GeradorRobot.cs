using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorRobot : MonoBehaviour
{   
    [SerializeField]
    private GameObject[] robotPrefabs;
    [SerializeField]
    private float delayInitial;
    [SerializeField]
    private float delayBetweenRobots;
    

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
