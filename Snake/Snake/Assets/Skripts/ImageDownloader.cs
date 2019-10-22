using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ImageDownloader : MonoBehaviour
{
    void Awake()
    {
        Start();
    }
    // Use this for initialization
    IEnumerator Start()
    {
        WWW www = new WWW("https://lh3.googleusercontent.com/Lpcxd-3q665RhKJ39CwSTn12YyBpZZ76pj-hKPD0e-RkpgDjLtn2hUeqPQMUuTCYTibIEAGQEIJfWJOiE5oP9Cwhbdon0MnON52i4yqpCLNZk8IMs2D89m5RWt97TZV37EvDxS6cgWB16A52EOHvSTa4MufCE4KCS-wnEcUxaIS45lgbdP1A4MuCJ6Bjf0-OY6KIgaMdpqBqjv462hRhCirBUcLvYkOH4ysj3wiYLISQ-HZsyebtFlSHpBEFpnn1qsNwpweI9PNr7KfIS_JJL37aGZbMhUBT1rGz1E4-3Kb9RySJNm8PhM5oZVB-Mmnc1R1-tz27Jr_VJ6uY-MNonI_e4-XBt6ZShJMT92NldIq8_xJ-EA--AJlf4hrrRiX9RD6XO2Khz0LYqa_FPwe0KIDL7eXu9E9JQumsZIPYrxfYMZ4HXvdyIdXtMFQJKgBbLKd6Qaz5Swr9drj5nntKUJIInvT7c7VYQQlmgsuE_8owjzsumPabpHjC-u6JVsAtmsrvo9iQbswhd4GM63MGth27x9cmOBqUd7fcbGUu9PQlu9zdIg_mnvS8gdEMthfddkypzuu0yBefQJIy7D60jePsEpCZRVyzRkWiXNY_R3Q0QOKSnPaa5aBp407y6kb8xEpWvwa4aZeiyQUiUvAXCrq8DyXWy-MocZew8ppm8dk8xCyZJZetUY8=s814-no");
        yield return www;
        Texture2D texture = www.texture;
        this.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, 810, 810), new Vector2(100f, 100f), 81);





    }

}
