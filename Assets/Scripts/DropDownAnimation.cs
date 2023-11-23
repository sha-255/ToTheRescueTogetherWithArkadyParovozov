using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DropDownAnimation : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private float _duration = 0.5f;
    [SerializeField] private Vector2 _startPosition = new Vector2(0, 100);
    [SerializeField] private Ease _ease = Ease.InOutQuart;
    [SerializeField] private UnityEvent _endAnimation;

    void Start()
    {
        var curpos = transform.position;
        var isImg = TryGetComponent<Image>(out var img);
        DOTween.Sequence()
            .Append(transform.DOMove(_startPosition, 0)
            .SetUpdate(UpdateType.Normal, true))
            .Append(transform.DOMove(curpos, _duration)
            .SetEase(_ease)
            .SetUpdate(UpdateType.Normal, true))
            .OnComplete(()=> _endAnimation?.Invoke());
        if (!isImg) return;
        var curcol = img.color;
        DOTween.Sequence()
            .Append(img.DOColor(new Color(0, 0, 0, 0), 0)
            .SetUpdate(UpdateType.Normal, true))
            .Append(img.DOColor(curcol, _duration)
            .SetEase(_ease)
            .SetUpdate(UpdateType.Normal, true));
    }
}
