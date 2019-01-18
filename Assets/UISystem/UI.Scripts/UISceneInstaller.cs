using Zenject;

public class UISceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UITestDataClass>().AsSingle();
    }
}