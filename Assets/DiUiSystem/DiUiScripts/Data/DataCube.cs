using DG.Tweening;
using UnityEngine;

namespace DiUi
{
    public class DataCube : MonoBehaviour
    {
        public Vector3 MoveTarget;
        public float MoveDuration = 1;

        Material _material;
        Color _origColor;
        Tweener _movementTweener;
        Tweener _colorTweener;

        void Start()
        {
            _material = gameObject.GetComponent<MeshRenderer>().material;
            _origColor = _material.color;
            StartMovement();

        }

        void StartMovement()
        {
            _movementTweener = transform.DOLocalMove(MoveTarget, MoveDuration).SetLoops(-1, LoopType.Yoyo);
            _colorTweener = _material.DOColor(Color.red, MoveDuration).SetLoops(-1, LoopType.Yoyo);
        }

        public void ControlTweener()
        {
            //DOESN't WORK!
            _movementTweener.TogglePause();
        }
    }
}