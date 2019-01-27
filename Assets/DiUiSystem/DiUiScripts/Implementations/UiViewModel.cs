﻿using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DiUi
{
    public abstract class UiViewModel<T> : UiViewModel where T : UiViewModel<T>
    {
        public UiViewModel( IDiUiPrefabProvider prefabProvider,
                            IUIViewModelsStack uIViewModelsStack)
        {
            _stack = uIViewModelsStack;
            _prefabProvider = prefabProvider;
        }

        public virtual async Task ShowViewAsync()
        {
            try
            {
                var Prefab = await _prefabProvider.GetWindowPrefab<T>();
                var ViewGo = GameObject.Instantiate(Prefab);
                Canvas = ViewGo.GetComponent<Canvas>();
                IView = ViewGo.GetComponent<IDiView>();
                IView.SetViewModel(this);
                _stack.AddViewModel(this);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        public override void Dispose()
        {
            if (IView.HideOnClose)
            {
                //Disable Canvas
            }
            else
            {
                //Destroy
                //Dispose VM?
            }

            GameObject.Destroy(Canvas.gameObject);
        }

        //From Stack
        public override void CloseCommand()
        {
            Dispose();
        }

        //From UI and Input
        public override void Close()
        {
            _stack.Close(this);
        }
    }

    public abstract class UiViewModel : IDiViewModel, IInitializable, IDisposable
    {
        internal IDiUiPrefabProvider _prefabProvider;
        internal IUIViewModelsStack _stack;
        internal abstract IDiView IView { get; set; }
        internal Canvas Canvas;

        public virtual void Initialize() { }
        public virtual void Dispose() { }
        public virtual void Close() { }
        public virtual void CloseCommand() { }
        public virtual void ShowConfirmToClose() { }
    }
}