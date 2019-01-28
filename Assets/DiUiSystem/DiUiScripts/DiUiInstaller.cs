using UnityEngine;
using Zenject;

namespace DiUi
{
    public class DiUiInstaller : MonoInstaller
    {
        public UIPrefabProviderType PrefabProviderType;
        public GameObject Cube;
        public GameObject ItemsCollection;

        public override void InstallBindings()
        {
            BindPrefabProviders();
            BindUIViewModels();
            BindSignals();
            Container.Bind<ICubeDataProvider>().To<CubeDataProvider>().AsSingle();
            Container.BindFactory<DataCube, DataCube.Factory>().FromComponentInNewPrefab(Cube).AsSingle();
            Container.Bind<IUIViewModelsStack>().To<UIViewModelsStack>().AsSingle();
            Container.Bind<IInventoryData>().To<InventoryData>().AsSingle();
            Container.Bind<IInventoryItemSprites>().To<InventoryItemSprites>().FromComponentInNewPrefab(ItemsCollection).AsSingle();
            
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
            Container.BindInterfacesAndSelfTo<DiUiPopUpViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<DiUiConfirmExitViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<DiUiPopUpThatHidesEverrythingViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<DiUiInventoryViewModel>().AsSingle();
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