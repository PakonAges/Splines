using UnityEngine;
using Zenject;

namespace DiUi
{
    public class DiUiInstaller : MonoInstaller
    {
        public UIPrefabProviderType PrefabProviderType;
        //public GameObject InspectorPrefabProvider;

        public override void InstallBindings()
        {
            Container.Bind<IDiUiManager>().To<DiUiManager>().AsSingle();
            BindPrefabProviders();
            BindUIViewModels();
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
            Container.BindFactory<DiUiHUDModelView, DiUiHUDModelView.Factory>();
        }

        public enum UIPrefabProviderType
        {
            Addressables,
            Inspector
        }
    }
}