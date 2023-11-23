using UnityEngine;

[CreateAssetMenu]
public class Question : ScriptableObject
{
    public AudioClip QuestionAudio;
    public string QuestionText;
    public Ansver[] Ansvers;
}

[System.Serializable]
public class Ansver
{
    public string Text;
    public AudioClip Audio;
    public AnsverType Type;
}

public enum AnsverType
{
    Right,
    Wrong
}
