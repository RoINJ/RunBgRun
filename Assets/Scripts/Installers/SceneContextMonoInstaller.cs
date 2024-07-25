using Scripts.Authentication;
using Scripts.Runner.Sections.Obstacles;
using Scripts.Runner.Sections;
using Zenject;
using Scripts.GameMenu;

namespace Scripts.Installers
{
    public class SceneContextMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<AdManager>()
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
