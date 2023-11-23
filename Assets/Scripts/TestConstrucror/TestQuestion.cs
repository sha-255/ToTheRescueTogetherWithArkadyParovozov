using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TestQuestion : MonoBehaviour
{
    [SerializeField] private TMP_Text question;
    [SerializeField] private AudioSource questionAudio;
    [SerializeField] private RectTransform ansversContainer;
    [SerializeField] private TestAnsver ansverPrefab;

    [HideInInspector] public Question Question;
    public UnityEvent RightClicked;

    public string Text
    {  
        get => question.text;
        set => question.text = value;
    }

    private void Start()
    {
        Text = Question.QuestionText;
        questionAudio.clip = Question.QuestionAudio;
        foreach (var el in Question.Ansvers)
        {
            var pref = Instantiate(ansverPrefab, ansversContainer);
            pref.AnsverType = el.Type;
            pref.text = el.Text;
            pref.AudioSource = el.Audio;
            pref.Inst();
            pref.RightClicked.AddListener(() => RightClicked?.Invoke());//
        }
    }
}
