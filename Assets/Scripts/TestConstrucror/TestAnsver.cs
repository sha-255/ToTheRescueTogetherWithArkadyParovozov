using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestAnsver : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private DragAnimation drag;

    [HideInInspector] public Ansver Ansver;

    public UnityEvent RightClicked;

    public string Text 
    { 
        get => _text.text; 
        set => _text.text = value; 
    }

    public AudioClip AudioSource 
    { 
        get => _audioSource.clip; 
        set => _audioSource.clip = value; 
    }

    public AnsverType AnsverType { get; set; }

    public string text 
    { 
        get => _text.text;
        set => _text.text = value;
    }

    public void Inst()
    {
        if (AnsverType == AnsverType.Right)
        {
            drag.enabled = false;//
            drag.GetComponent<Button>().onClick.AddListener(() => RightClicked?.Invoke());
        }
    }
}
