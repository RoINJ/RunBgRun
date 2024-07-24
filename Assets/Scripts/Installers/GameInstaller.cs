using Scripts.Authentication;
using Scripts.Runner.Sections.Obstacles;
using Scripts.Runner.Sections;
using Zenject;
using Firebase.Database;
using Scripts.Runner.Score;

namespace Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInstance(FirebaseDatabase.DefaultInstance.RootReference)
                .AsSingle();
                
            Container
                .BindInterfacesAndSelfTo<FirebaseAuthenticationProvider>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<FirebaseScoreStorage>()
                .AsTransient();

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
