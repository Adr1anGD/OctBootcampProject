using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private Pin[] pins;

    private bool isGamePlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGamePlaying = true;

        // Get first throw
        playerController.StartThrow();
    }

    // Update is called once per frame
    void Update()
    {
        // if (isGamePlaying == false && Input.GetKeyUp(KeyCode.X))
        //{
        //     StartGame();
        //}
    }

    public void SetNextThrow()
    {
        Invoke(nameof(NextThrow), 3.0f);
    }

    void NextThrow()
    {
        if(scoreManager.currentFrame == 0)
        {
            Debug.Log($"Game over {scoreManager.CalculateTotalScore()}");
        }
        else
        {
            Debug.Log($"Frame: {scoreManager.currentFrame}, Throw: {scoreManager.currentThrow}");
            scoreManager.SetFrameScore(CalculateFallenPins());
            Debug.Log($"Current score: (scoreManager.CalculateTotalScore)");

            // Get the ball to the start position for throwing
            playerController.StartThrow();
        }
    }

    public int CalculateFallenPins()
    {
        int count = 0;
        foreach (Pin pin in pins)
        {
            if (pin.isFallen)
            {
                count++;
                pin.gameObject.SetActive(false);
            }
        }

        Debug.Log("Total Fallen Pins " + count);
        return count;
    }

    public void ResetAllPins()
    {
        foreach (Pin pin in pins)
        {
            pin.ResetPin();
        }
    }
}