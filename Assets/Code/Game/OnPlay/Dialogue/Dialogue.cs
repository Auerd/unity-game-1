using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField]
    public string CharacterName { get; private set; }
    [SerializeField]
    [TextArea(1, 5)]
    private string[] sentences;
    private readonly Queue<string> sentencesQueue = new();

    public string GetNextSentence()
    {
        if (sentencesQueue.Count != 0)
            return sentencesQueue.Dequeue();
        return null;
    }
    public void StartNewDialogue()
    {
        sentencesQueue.Clear();
        foreach (string sentence in sentences)
        {
            sentencesQueue.Enqueue(sentence);
        }
    }
}
