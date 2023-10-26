using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

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
        SetNextThrow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNextThrow()
    {
        // Get the ball to the start position for throwing
        playerController.StartThrow();
    }

    public void CalculateFallenPins()
    {
        int count = 0;
        foreach (Pin pin in pins)
        {
            if (pin.isFallen)
            {
                count++;
            }
        }

        Debug.Log("Total Fallen Pins " + count);
    }
}
