using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    AudioSource audio;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        text.text = "Score: " + score.totalScore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Consumables"))
        {
            audio.Play();
            Destroy(collision.gameObject);
            score.totalScore++;
            text.text = "Score: " + score.totalScore.ToString();
            

        }
    }
}
