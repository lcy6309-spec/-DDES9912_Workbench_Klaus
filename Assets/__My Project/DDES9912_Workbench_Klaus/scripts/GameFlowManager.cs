using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance;

    public int currentTaskIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    // NPC 1 ¡ú Task 1
    public void StartTask1()
    {
        UIManager.Instance.ShowDialogue("Task 1: Please enter NEWS on Typewriter 1.");
        currentTaskIndex = 1;
    }

    // NPC 2 ¡ú Task 2
    public void StartTask2()
    {
        UIManager.Instance.ShowDialogue("Task 2: Please enter HELLO WORLD on Typewriter 2.");
        currentTaskIndex = 2;
    }

    // NPC 3 ¡ú Task 3
    public void StartTask3()
    {
        UIManager.Instance.ShowDialogue("Task 3: Please enter $123 on Typewriter 3.");
        currentTaskIndex = 3;
    }

    // NPC 4 ¡ú Task 4
    public void StartTask4()
    {
        UIManager.Instance.ShowDialogue("Task 4: Please enter the Morse code result: A.");
        currentTaskIndex = 4;
    }

    // NPC 5 ¡ú Task 5
    public void StartTask5()
    {
        UIManager.Instance.ShowDialogue("Task 5: Please fill the missing word: BERLIN.");
        currentTaskIndex = 5;
    }

    // NPC 6 ¡ú Final Task (Combined Password)
    public void StartTask6()
    {
        UIManager.Instance.ShowDialogue("Final Task: Please enter the final combined password.");
        currentTaskIndex = 6;
    }

    // Called when a task is completed successfully
    public void NextTask()
    {
        currentTaskIndex++;

        switch (currentTaskIndex)
        {
            case 2:
                UIManager.Instance.ShowDialogue("Task 2 unlocked! Talk to NPC 2.");
                break;

            case 3:
                UIManager.Instance.ShowDialogue("Task 3 unlocked! Talk to NPC 3.");
                break;

            case 4:
                UIManager.Instance.ShowDialogue("Task 4 unlocked! Talk to NPC 4.");
                break;

            case 5:
                UIManager.Instance.ShowDialogue("Task 5 unlocked! Talk to NPC 5.");
                break;

            case 6:
                UIManager.Instance.ShowDialogue("Task 6 unlocked! Talk to NPC 6.");
                break;

            case 7:
                UIManager.Instance.ShowDialogue("All tasks completed! You have solved the office mystery!");
                break;

            default:
                UIManager.Instance.ShowDialogue("Unknown task index.");
                break;
        }
    }
}
