using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Star : MonoBehaviour
{
    [Header("Sound")]
    private AudioSource audioSource;
    private Button button;
    [Header("Animation")]
    [SerializeField] private Ease Ease = Ease.OutQuad;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => OnButtonClick());
        Tweening();
    }

    private void OnButtonClick()
    {
        if (!audioSource.isPlaying) audioSource.Play();
    }

    private void Tweening()
    {
        DOTween.Sequence()
            .Append(transform.DORotate(new Vector3(0, 0, -20), 0.3f).SetEase(Ease).SetUpdate(UpdateType.Normal, true))
            .Append(transform.DORotate(new Vector3(0, 0, 20), 0.3f).SetEase(Ease).SetUpdate(UpdateType.Normal, true))
            .Append(transform.DORotate(new Vector3(0, 0, 0), 0.3f).SetEase(Ease).SetUpdate(UpdateType.Normal, true))
            .AppendInterval(1f).SetUpdate(UpdateType.Normal, true)
            .SetLoops(-1).SetUpdate(UpdateType.Normal, true);
        DOTween.Sequence()
            .Append(transform.DOScale(new Vector2(1.3f, 1.3f), 0.45f).SetEase(Ease).SetUpdate(UpdateType.Normal, true))
            .Append(transform.DOScale(new Vector2(1f, 1f), 0.45f).SetEase(Ease).SetUpdate(UpdateType.Normal, true))
            .AppendInterval(1f).SetUpdate(UpdateType.Normal, true)
            .SetLoops(-1).SetUpdate(UpdateType.Normal, true);
    }
}
