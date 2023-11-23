using DG.Tweening;
using UnityEngine;

public class DragAnimation : MonoBehaviour
{
    public void Drag()
    {
        var startpos = transform.position;
        DOTween.Sequence()
            .SetUpdate(UpdateType.Normal, true)
            .Append(transform.DOMove(new Vector2(.3f,transform.position.y), .1f))
            .Append(transform.DOMove(new Vector2(-.3f, transform.position.y), .1f))
            .Append(transform.DOMove(new Vector2(.3f, transform.position.y), .1f))
            .Append(transform.DOMove(new Vector2(-.3f, transform.position.y), .1f))
            .Append(transform.DOMove(startpos, .2f));
    }
}
