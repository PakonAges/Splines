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

                var moveFirst = await _mover.Move(Items[0].transform, Items[0].transform.position + Vector3.down, MovementDuration);

                for (int i = 1; i < ItemsToSpawn; i++)
                {

                    int prevIndex = (i != 0) ? (i - 1) : ItemsToSpawn - 1;
                    Transform prevItem = Items[prevIndex].transform;
                    Vector3 prevItemNewPosition = prevItem.position + Vector3.up;

                    Transform item = Items[i].transform;
                    Vector3 newPosition = item.position + Vector3.down;

                    var moveOld = await _mover.Move2(prevItem, item, prevItemNewPosition, newPosition, MovementDuration);


                    i = (i == (ItemsToSpawn - 1)) ? i = -1 : i;
                }

            }
            catch
            {
                _isMoving = false;
                Debug.Log("An error occurred in Start Movement");
            }
        }

        void StopMovement()
        {
            _isMoving = false;
            Debug.Log("Movement Stopped");
        }
    }
}
