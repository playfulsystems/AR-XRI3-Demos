using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreText;
    public AudioSource audioSource;
    
    private int score = 0;

    public void IncrementScore()
    {
        score++;
        audioSource.Play();
        scoreText.text = score.ToString();
    }
    
}
