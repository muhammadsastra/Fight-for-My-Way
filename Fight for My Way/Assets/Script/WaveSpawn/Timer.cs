using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public int countdownTime;
    public Text countdownText;
    public WaveManager waveManager;
    public Player Player;
    private void Start()
    {
        StartCoroutine(countdowntoStart());
    }
    public IEnumerator countdowntoStart()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        yield return new WaitForSeconds(1f);
        countdownText.text = "FIGHT!";
        yield return new WaitForSeconds(1f);
        countdownText.text = "";
        countdownText.gameObject.SetActive(false);
        waveManager.mulai();
        UpdateUI();
    }
    public void Waveselanjutnya()
    {
        countdownText.gameObject.SetActive(true);
        StartCoroutine(countdowntoStart());
    }

    public void UpdateUI()
    {
        countdownTime = 3;
        Player.TambahDarah(20);
    }
}
