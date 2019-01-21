using System.Threading.Tasks;
using UnityEngine;

public class CanvasBuilder
{
    readonly IUiPrefabProvider _prefabProvider;

    public CanvasBuilder(IUiPrefabProvider uiPrefabProvider)
    {
        _prefabProvider = uiPrefabProvider;
    }

    public async Task<CanvasFacade<T>> BuildAsync<T>() where T : GenericView
    {
        var _canvasPrefab = await _prefabProvider.GetPrefabAsync<T>();

        if (_canvasPrefab == null)
        {
            Debug.LogErrorFormat("Can't find UI prefab {0}");
            return null;
        }

        var _canvasGo = GameObject.Instantiate(_canvasPrefab);
        _canvasGo.name = _canvasPrefab.name;

        return new CanvasFacade<T>(_canvasGo);
    }
}
