using UnityEngine;

public class CanvasFacade<T> where T : GenericView
{
    public T CanvasMV { get; }

    readonly Canvas _canvas;
    bool _enabled = true;

    public CanvasFacade(GameObject iCanvasGo)
    {
        CanvasMV = iCanvasGo.GetComponentInChildren<T>();
        CanvasMV.OnWrapped();
        _canvas = iCanvasGo.GetComponentInChildren<Canvas>();

        _canvas.gameObject.SetActive(true);
        _canvas.enabled = _enabled;
    }
}
