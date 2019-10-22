using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    void Resets()
    {

        FindObjectOfType<Snake>().tail.Clear();
    }
}
