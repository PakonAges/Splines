﻿using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DiUi
{
    public abstract class UiViewModel<T> : UiViewModel where T : UiViewModel<T>
    {
        public UiViewModel(IDiUiPrefabProvider prefabProvider,
                            IUIViewModelsStack uIViewModelsStack)
        {
            _stack = uIViewModelsStack;
            _prefabProvider = prefabProvider;
        }

        public async override Task Open()
        {
            //Already been created
            if (IView != null && IView.HideOnClose)
            {
                if (!Canvas)
                {
                    Debug.LogErrorFormat("Trying to enable Canvas on Cached View ({0}), but there is no canvas", this);
                    return;
                }

                Canvas.enabled = true;
                _stack.AddViewModel(this);
            }
            else
            {
                await ShowViewAsync();
            }
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
            if (IView == null || Canvas == null)
            {
                return;
            }

            if (IView.HideOnClose)
            {
                Canvas.enabled = false;
            }
            else
            {
                if (Canvas)
                {
                    GameObject.Destroy(Canvas.gameObject);
                }
            }
        }

        public override void CloseCommand()
        {
            Dispose();
        }

        public override void Close()
        {
            _stack.Close(this);
        }
    }

    public abstract class UiViewModel : IDiViewModel, IInitializable, IDisposable
    {
        internal IDiUiPrefabProvider _prefabProvider;
        internal IUIViewModelsStack _stack;
        internal virtual IDiView IView { get; set; }
        internal Canvas Canvas;

        public virtual void Initialize() { }
        public virtual void Dispose() { }

        /// <summary>
        /// Open call from UI and Input. Check if there is cached View is awailable before creating new
        /// </summary>
        public virtual Task Open() { return null; }

        /// <summary>
        /// Call from UI and Input
        /// </summary>
        public virtual void Close() { }

        /// <summary>
        /// Call from UI Stack
        /// </summary>
        public virtual void CloseCommand() { }

        /// <summary>
        /// ON close -> Show confirm Pop Up without closing View
        /// </summary>
        public virtual void ShowConfirmToClose() { }
    }
}