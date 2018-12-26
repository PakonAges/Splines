using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsyncAwaitTryouts
{
    public class AsyncAwaitController : MonoBehaviour
    {
        [Header("Setup")]
        public int ItemsToSpawn = 8;
        public GameObject Item;
        public KeyCode SpawnKey = KeyCode.S;
        public KeyCode ToggleMovement =  KeyCode.D;
        public float MovementDuration = 1.0f;

        [Header("Result")]
        private bool _alreadyCreated = false;
        private bool _isMoving = false;
        public GameObject[] Items;

        private ItemMover _mover;
        private int _iterator = 0; //used to continue movement after Pause from the same spot

        private void Awake()
        {
            Items = new GameObject[ItemsToSpawn];
            _mover = new ItemMover();
        }

        private void Update()
        {
            if (Input.GetKeyDown(SpawnKey))
            {
                if (!_alreadyCreated)
                {
                    SpawnItems();
                }
            }
            else if (Input.GetKeyDown(ToggleMovement))
            {
                if (!_isMoving)
                {
                    StartMovement();
                }
                else
                {
                    StopMovement();
                }
            }
        }

        void SpawnItems()
        {
            for (int i = 0; i < ItemsToSpawn; i++)
            {
                Vector3 Pos = new Vector3(i, 0, 0);
                var newItem = Instantiate(Item,Pos,Quaternion.identity);
                Items[i] = newItem;
            }

            _alreadyCreated = true;
        }

        async void StartMovement()
        {
            try
            {
                Debug.Log("Movement Started");
                _isMoving = true;

                if (_iterator == 0)
                {
                    var moveFirst = await _mover.Move(Items[0].transform, Vector3.down, MovementDuration);
                    _iterator = 1;
                }

                for (int i = _iterator; i < ItemsToSpawn; i++)
                {
                    if (_isMoving)
                    {
                        int prevIndex = (i != 0) ? (i - 1) : ItemsToSpawn - 1;
                        Transform prevItem = Items[prevIndex].transform;
                        Vector3 prevItemNewPosition = new Vector3(prevIndex, 0, 0);

                        Transform item = Items[i].transform;
                        Vector3 newPosition = new Vector3(i, -1, 0);

                        var moveOld = await _mover.Move2(prevItem, item, prevItemNewPosition, newPosition, MovementDuration);

                        i = (i == (ItemsToSpawn - 1)) ? i = -1 : i;
                        _iterator = i;
                    }
                }   
            }
            catch
            {
                _isMoving = false;
                Debug.LogFormat("An error occurred in Start Movement. Iterator: {0}" , _iterator);
            }
        }

        void StopMovement()
        {
            _isMoving = false;
            //DOTween.CompleteAll();
            Debug.Log("Movement Stopped");
        }
    }
}
