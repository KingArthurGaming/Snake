using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private int neededFood = 1;
    private int foodNow = 1;

    public GameObject foodPrep;
    void LateUpdate()
    {

        foodNow = CountChildren(gameObject.transform);
        if (foodNow < neededFood)
        {
            for (int i = 0; i < neededFood - foodNow; i++)
            {
                Vector3 v = transform.TransformPoint(new Vector3(Random.Range(-300, 300), Random.Range(-280, 410), 0));

                Instantiate(foodPrep, v, Quaternion.identity, gameObject.transform);
            }
        }
        //transform.TransformPoint(new Vector3(Random.Range(-320, 317),
        //                                           Random.Range(320, 420)
        //                                           , 0));
    }
    int CountChildren(Transform a)
    {
        int childCount = 0;
        foreach (Transform b in a)
        {
            //Debug.Log("Child: " + b);
            childCount++;
            childCount += CountChildren(b);
        }
        return childCount;
    }

}
