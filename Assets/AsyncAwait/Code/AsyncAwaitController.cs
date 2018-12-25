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

        [Header("Result")]
        private bool _alreadyCreated = false;
        private bool _isMoving = false;
        public GameObject[] Items;

        private void Awake()
        {
            Items = new GameObject[ItemsToSpawn];
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

        void StartMovement()
        {
            _isMoving = true;
            Debug.Log("Movement Started");
        }

        void StopMovement()
        {
            _isMoving = false;
            Debug.Log("Movement Stopped");
        }
    }
}
