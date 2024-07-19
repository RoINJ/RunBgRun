using Scripts.Authentication;
using Scripts.Runner;
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

            Container.Bind<SectionPool>().FromComponentInHierarchy().AsSingle();
        }
    }
}
