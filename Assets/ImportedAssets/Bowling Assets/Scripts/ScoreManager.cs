using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private int totalScore;

    public int currentThrow { get; private set; }
    public int currentFrame { get; private set; }

    private int[] frames = new int[10];

    private bool isSpare = false;
    private bool isStrike = false;

    // Set value for our frame score each time we throw the ball
    public void SetFrameScore(int score)
    {
        // Ball 1
        if(currentThrow == 1)
        {
            frames[currentFrame - 1] += score; // Setting the right frame index and adding the score value from the passed parameter

            // Parallel process to check spare
            if(isSpare)
            {
                frames[currentFrame - 2] += score;
                isSpare = false;
            }
            // ---------------------------------------------------------------------------------------------------------------------

            if(score == 10)
            {
                if(currentFrame == 10)
                {
                    currentThrow++; // Wait for ball 2
                }
                else
                {
                    isStrike = true;
                    currentFrame++; // Move to next frame since full marks obtained
                }

                // To do: GameManager to reset pins
            }
            else
            {
                currentThrow++; // Wait for ball 2
            }

            return;
        }

        // Ball 2
        if(currentThrow == 2)
        {
            frames[currentFrame - 1] += score;

            // Parallel process to check strike
            if(isStrike)
            {
                frames[currentFrame - 2] += frames[currentFrame - 1];
                isStrike = false;
            }
            // ---------------------------------------------------------------------------------------------------------------------

            if (frames[currentFrame - 1] == 10) // Total frame score == 10
            {
                if(currentFrame == 10)
                {
                    currentThrow++; // Wait for ball 3
                }
                else
                {
                    isSpare = true;
                    currentFrame++;
                    currentThrow = 1;
                }
            }
            else
            {
                if(currentFrame == 10)
                {
                    // End of all throws
                    currentThrow = 0;
                    currentFrame = 0;
                }
                else
                {
                    currentFrame++;
                    currentThrow = 1;
                }
            }

            // To do: GameManager to reset all pins
            gameManager.ResetAllPins();

            return;
        }

        // Ball 3 ONLY FRAME 10
        if(currentThrow == 3 && currentFrame == 10)
        {
            frames[currentFrame - 1] += score;

            // End of all throws
            currentThrow = 0;
            currentFrame = 0;

            return;
        }
    }

    public int CalculateTotalScore()
    {
        totalScore = 0;
        foreach(var frame in frames)
        {
            totalScore += frame;
        }

        return totalScore;
    }

    private void ResetScore()
    {
        totalScore = 0;
        currentFrame = 1;
        currentThrow = 1;
        frames = new int[10];
    }
}