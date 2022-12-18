using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] private Transform[] leftObstacles;
    [SerializeField] private Transform[] rightObstacles;

    [Header("Setup")]
    public float leftMinPos = -0.5f;
    public float leftMaxPos = -7f;
    public float rightMinPos = 0.5f;
    public float rightMaxPos = 7f;

    public void ChangeObstaclesPosition()
    {
        for (int i = 0; i < leftObstacles.Length; i++)
        {
            leftObstacles[i].localPosition = new Vector3(
                Random.Range(leftMinPos, leftMaxPos),
                leftObstacles[i].localPosition.y,
                leftObstacles[i].localPosition.z
                );
        }

        for (int i = 0; i < rightObstacles.Length; i++)
        {
            rightObstacles[i].localPosition = new Vector3(
                Random.Range(rightMinPos, rightMaxPos),
                rightObstacles[i].localPosition.y,
                rightObstacles[i].localPosition.z
                );
        }
    }
}
