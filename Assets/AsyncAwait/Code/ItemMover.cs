using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class ItemMover
{
    public async Task<bool> Move(Transform item, Vector3 newPosition, float duration)
    {
        item.DOMove(newPosition, duration);
        await new WaitForSeconds(duration);
        return OnTweenMovementDone();
    }

    public async Task<bool> Move2 (Transform item1, Transform item2, Vector3 newPosition1, Vector3 newPosition2, float duration)
    {
        item1.DOMove(newPosition1, duration);
        item2.DOMove(newPosition2, duration);

        await new WaitForSeconds(duration);
        return OnTweenMovementDone();
    }

    bool OnTweenMovementDone()
    {
        return true;
    }
}
