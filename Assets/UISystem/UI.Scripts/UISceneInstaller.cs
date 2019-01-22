using Zenject;
using myUi;

public class UISceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UITestDataClass>().AsSingle();
        Container.Bind<IUiManager>().To<UIManager>().AsSingle();
        Container.Bind<IUiPrefabProvider>().To<AdressablePrefabProvider>().AsSingle();
        Container.Bind<CanvasBuilder>().AsSingle();

        //UI
        
    }
}