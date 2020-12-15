using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndWave : MonoBehaviour
{
    public Wave wave;
    private string endWave;
    public Text ket;

    public void WaveTerakhir()
    {
        endWave = wave.waveCounter.ToString();
        ket.text = "You die in wave " + endWave;
    }
}
