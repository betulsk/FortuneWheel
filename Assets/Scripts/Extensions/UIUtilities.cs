using DG.Tweening;
using UnityEngine;

public static class UIUtilities
{
    public static void BoingEffect(Transform target, Vector3 initScale, float scaleFactor = 1.5f, float duration = .8f)
    {
        target.localScale = initScale;
        Sequence sequence = DOTween.Sequence().Append(target.DOScale(initScale * scaleFactor, duration / 2).SetLink(target.gameObject));
        sequence.Append(target.DOScale(initScale, duration / 2));
    }
}
