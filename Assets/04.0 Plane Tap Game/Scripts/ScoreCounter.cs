using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreText;
    
    private int score = 0;

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    
}
