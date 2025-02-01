using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
   int score;
   TMP_Text scoreText;

    void Start() 
    {
      //  scoreText.GetComponent<TMP_Text>();
        // if(scoreText != null)
       // scoreText.text = "Start";
        // Debug.Log($"{scoreText} ------");
    }
    
   public void IncreaseScore(int amountToIncrease)
   {
        // score += amountToIncrease;
        // if(scoreText != null)
      // scoreText.text = score.ToString();
   }
}
