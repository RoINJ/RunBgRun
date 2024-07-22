using Scripts.Authentication;
using Scripts.Runner.Sections.Obstacles;
using Scripts.Runner.Sections;
using Zenject;

namespace Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<FirebaseAuthenticationProvider>()
                .AsSingle();

            Container
                .Bind<FirebaseInitializer>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<AuthUIManager>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<GameMenuUIManager>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<AdManager>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<GameManager>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<SectionPool>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<ObstaclesPool>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}
