using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private TMP_Text display, hiDisplay;
    [SerializeField] private UintSO score, hiscore;

    void Start()
    {
        if (score.value > hiscore.value)
            hiscore.value = score.value;

        display.text = "Score: " + score.value;
        hiDisplay.text = "Best: " + hiscore.value;
    }
}
