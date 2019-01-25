using DG.Tweening;
using UnityEngine;
using Zenject;

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

        SignalBus _signalBus;
        MovementDirection _direction;
        MovementDirection _cachedDirection;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        void Start()
        {
            _material = gameObject.GetComponent<MeshRenderer>().material;
            _origColor = _material.color;
            StartMovement();
            _movementTweener.SetAutoKill(false);
        }

        void StartMovement()
        {
            MoveRight();
            _colorTweener = _material.DOColor(Color.red, MoveDuration).SetLoops(-1, LoopType.Yoyo);
        }

        public void ControlTweener()
        {
            _movementTweener.TogglePause();

            if (!_movementTweener.IsPlaying())
            {
                _cachedDirection = _direction;
                _direction = MovementDirection.Stop;
            }
            else
            {
                _direction = _cachedDirection;
            }

            _signalBus.TryFire(new CubeMovementSignal(_direction));
        }


        void MoveRight()
        {
            _movementTweener = transform.DOLocalMove(MoveTarget, MoveDuration).OnComplete(MoveLeft);
            OnMovementChage();
        }

        void MoveLeft()
        {
            _movementTweener = transform.DOLocalMove(-MoveTarget, MoveDuration).OnComplete(MoveRight);
            OnMovementChage();
        }


        void OnMovementChage()
        {
            if (_direction == MovementDirection.Invalid)
            {
                _direction = MovementDirection.Right;
            } else if (_direction == MovementDirection.Left)
            {
                _direction = MovementDirection.Right;
            }
            else if (_direction == MovementDirection.Right)
            {
                _direction = MovementDirection.Left;
            }

            _signalBus.TryFire(new CubeMovementSignal(_direction));
        }

        public class Factory : PlaceholderFactory<DataCube> { }
    }
}