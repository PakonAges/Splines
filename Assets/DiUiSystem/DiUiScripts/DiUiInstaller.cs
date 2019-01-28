using UnityEngine;
using Zenject;

namespace DiUi
{
    public class DiUiInstaller : MonoInstaller
    {
        public UIPrefabProviderType PrefabProviderType;
        public GameObject Cube;

        public override void InstallBindings()
        {
            BindPrefabProviders();
            BindUIViewModels();
            BindSignals();
            Container.Bind<ICubeDataProvider>().To<CubeDataProvider>().AsSingle();
            Container.BindFactory<DataCube, DataCube.Factory>().FromComponentInNewPrefab(Cube).AsSingle();
            Container.Bind<IUIViewModelsStack>().To<UIViewModelsStack>().AsSingle();
            Container.Bind<IInventoryData>().To<InventoryData>().AsSingle();
        }

        void BindPrefabProviders()
        {
            switch (PrefabProviderType)
            {
                case UIPrefabProviderType.Addressables:
                Container.Bind<IDiUiPrefabProvider>().To<AdressablePrefabProvider>().AsSingle();
                break;

                case UIPrefabProviderType.Inspector:
                //Container.Bind<IDiUiPrefabProvider>().To<InspectorPrefabProvider>().FromComponentInHierarchy().AsSingle();
                break;

                default:
                Container.Bind<IDiUiPrefabProvider>().To<AdressablePrefabProvider>().AsSingle();
                break;
            }
        }

        void BindUIViewModels()
        {
            Container.BindInterfacesAndSelfTo<DiUiHUDViewModel>().AsSingle();
            Container.Bind<DiUiPopUpViewModel>().AsSingle();
            Container.Bind<DiUiConfirmExitViewModel>().AsSingle();
            Container.Bind<DiUiPopUpThatHidesEverrythingViewModel>().AsSingle();
            Container.Bind<DiUiInventoryViewModel>().AsSingle();
        }

        void BindSignals()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<CubeMovementSignal>();
        }

        public enum UIPrefabProviderType
        {
            Addressables,
            Inspector
        }
    }
}