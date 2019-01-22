using UnityEngine;

namespace myUi
{
    public class CanvasFacade<T> where T : GenericView
    {
        public T CanvasMV { get; }
        readonly Canvas _canvas;
        bool _enabled = true;
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled == value) return;

                _enabled = value;
                _canvas.enabled = value;
            }
        }

        public int SortingOrder
        {
            get { return _canvas.sortingOrder; }
            set { _canvas.sortingOrder = value; }
        }

        //Destroy

        public CanvasFacade(GameObject iCanvasGo)
        {
            CanvasMV = iCanvasGo.GetComponentInChildren<T>();
            CanvasMV.OnWrapped();
            _canvas = iCanvasGo.GetComponentInChildren<Canvas>();

            _canvas.gameObject.SetActive(true);
            _canvas.enabled = _enabled;
        }

        public void Update(float iDeltaTime)
        {
            if (_enabled == false)
                return;

            CanvasMV.ViewUpdate(iDeltaTime);
        }
    }
}
