using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pipe;
    public GameObject scoreZone;
    public float startingXPos = 50;
    public float maxYPosForBottomPipe = -4;
    public float minYPosForBottomPipe = -30;
    public float minDistanceBetweenPipes = 57;
    public float maxDistanceBetweenPipes = 64;
    public float spawnTime = 100;
    private float spawnTimer = 0;

    private void Update()
    {
        spawnTimer--;
        if (spawnTimer < 0)
        {
            SpawnPipe();
            spawnTimer = spawnTime;
        }
    }

    private void SpawnPipe()
    {
        float yPos = Random.Range(minYPosForBottomPipe, maxYPosForBottomPipe);
        GameObject bottomPipe = Instantiate(pipe, new Vector2(startingXPos, yPos), Quaternion.identity);
        float distanceBetweenPipes = Random.Range(minDistanceBetweenPipes, maxDistanceBetweenPipes);
        float newYPos = yPos + distanceBetweenPipes;
        Instantiate(pipe, new Vector2(startingXPos, newYPos), Quaternion.Euler(Vector3.forward * 180));
        GameObject zone = Instantiate(scoreZone, bottomPipe.transform);
        zone.transform.position = new Vector2(zone.transform.position.x, (newYPos + yPos) / 2);
    }
}
