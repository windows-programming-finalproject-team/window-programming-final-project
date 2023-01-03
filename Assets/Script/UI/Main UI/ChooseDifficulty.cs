using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDifficulty : MonoBehaviour
{
    // effects around text
    [SerializeField] GameObject easyLine;
    [SerializeField] GameObject hardcoreLine;

    public static bool isEasyMode = false;

    private void Start()
    {
        chooseHardcoreMode();
    }

    public void chooseEasyMode()
    {
        isEasyMode = true;
        easyLine.SetActive(true);
        hardcoreLine.SetActive(false);
    }

    public void chooseHardcoreMode()
    {
        isEasyMode = false;
        easyLine.SetActive(false);
        hardcoreLine.SetActive(true);
    }
}
