using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TestWINLOSE : MonoBehaviour
{
    [SerializeField] private Slider Enemyslider = null;
    [SerializeField] private Slider PlayersSlider = null;
    [SerializeField] private TMP_Text winningText;

    private void Start()
    {
        winningText.enabled = false; //Hide the text when the game starts
    }
    private void Update()
    {
        if(Enemyslider.value == 0) //should try to check if the value is 0?
        {
            winningText.enabled = true; //Show the text
            winningText.text = "You Win!"; //show the win 
            Time.timeScale = 0; //pause

        }
        else if (PlayersSlider.value == 0) //should try to check if the value is 0?
        {
            winningText.enabled = true; //Show text
            winningText.text = "You Lose!"; //show lose
            Time.timeScale = 0; //pause
        }
    }
}
