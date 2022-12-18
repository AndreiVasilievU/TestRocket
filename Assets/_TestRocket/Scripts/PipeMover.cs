using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] Transform[] partPipesTransform;

    private ObstaclesController[] obstaclesControllers;
    private const float startPosPartPipeTransform = 41f;
    public bool isActive;

    [Header("Setup")]
    public float speed = 1;

    private void Awake()
    {
        obstaclesControllers = new ObstaclesController[partPipesTransform.Length];

        for (int i = 0; i < obstaclesControllers.Length; i++)
        {
            obstaclesControllers[i] = partPipesTransform[i].gameObject.GetComponent<ObstaclesController>();
        }
    }

    void Update()
    {
        if (isActive)
        {
            for (int i = 0; i < partPipesTransform.Length; i++)
            {
                if (partPipesTransform[i].localPosition.y <= -startPosPartPipeTransform)
                {
                    partPipesTransform[i].localPosition = new Vector3(0, startPosPartPipeTransform, 0);
                    obstaclesControllers[i].ChangeObstaclesPosition();
                }

                partPipesTransform[i].localPosition -= new Vector3(0,speed,0) * Time.deltaTime;
            }
        }
    }
}
