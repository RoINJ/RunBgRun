using Scripts.Authentication;
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
        }
    }
}
