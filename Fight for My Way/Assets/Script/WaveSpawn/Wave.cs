using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Wave : MonoBehaviour
{
    public int waveCounter = 0;
    public Text waveText;
    public void UpdateWave()
    {
        waveCounter += 1;
        waveText.text = "Wave : " + waveCounter.ToString();
    }
}
