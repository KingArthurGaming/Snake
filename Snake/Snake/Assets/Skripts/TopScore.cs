using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TopScore : MonoBehaviour
{
    public TextMeshProUGUI ScoreTop1;
    public TextMeshProUGUI ScoreTop2;
    private string text1;
    private string text2;
    private List<string> topText;
    void Start()
    {
        topText = PlayerPrefs.GetString("Top10").Split(',').ToList();
        text1 += "1. "+topText[0] +"\n";
        text1 += "3. "+topText[2] +"\n";
        text1 += "5. "+topText[4] +"\n";
        text1 += "7. "+topText[6] +"\n";
        text1 += "9. "+topText[8] + "\n";
        ScoreTop1.text = text1;

        text2 += "2. " + topText[1] + "\n";
        text2 += "4. " + topText[3] + "\n";
        text2 += "6. " + topText[5] + "\n";
        text2 += "8. " + topText[7] + "\n";
        text2 += "10. " + topText[9] + "\n";
        ScoreTop2.text = text2;
    }

   
}
