using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    AudioSource source;

    public AudioClip roundStart;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    async public void announceWave(int wave)
    {
        waveText.text = $"Wave of {wave} Started!";
        source.PlayOneShot(roundStart);
        await new WaitForSeconds(2f);
        waveText.text = "";
    }
}
