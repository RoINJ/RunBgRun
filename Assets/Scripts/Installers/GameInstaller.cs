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
                .Bind<IAuthenticationProvider>()
                .To<FirebaseAuthenticationProvider>()
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
