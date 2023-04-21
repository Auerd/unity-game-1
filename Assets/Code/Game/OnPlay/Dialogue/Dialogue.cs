using UnityEngine;
[System.Serializable]
public class Dialogue
{
    int currentSentence = 0;
    public string characterName{get; private set;}
    [SerializeField]
    [TextArea(3, 10)]
    private string[] sentences;

    public string GetNextSentence()
    {
        if(currentSentence < sentences.Length){
            currentSentence++;
            return sentences[currentSentence];
        }
        GetOutOfDialog();
        return null;
    }
    public void GetOutOfDialog() => currentSentence = 0;
}
