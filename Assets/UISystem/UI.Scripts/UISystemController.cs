using UnityEngine;
using Zenject;

namespace myUi
{
    /// <summary>
    /// Root object for UI System
    /// </summary>
    public class UISystemController : MonoBehaviour
    {
        IUiManager _uiManager;

        [Inject]
        public void Construct(IUiManager uiManager)
        {
            _uiManager = uiManager;
        }

        void Start()
        {
            _uiManager.InitViewsAsync();
            //_uiManager.ShowWindowAsync<HUDView>();
        }

        void FixedUpdate()
        {
            _uiManager.UpdateViews(Time.deltaTime * 10);
        }
    }

}