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
            BindPrefabProviders();
        }



        void BindPrefabProviders()
        {
            switch (PrefabProviderType)
            {
                case UIPrefabProviderType.Addressables:
                Container.Bind<IDiUiPrefabProvider>().To<AdressablePrefabProvider>().AsSingle();
                break;

                case UIPrefabProviderType.Inspector:
                Container.Bind<IDiUiPrefabProvider>().To<InspectorPrefabProvider>().FromComponentInHierarchy().AsSingle();
                break;

                default:
                Container.Bind<IDiUiPrefabProvider>().To<AdressablePrefabProvider>().AsSingle();
                break;
            }
        }

        public enum UIPrefabProviderType
        {
            Addressables,
            Inspector
        }
    }
}