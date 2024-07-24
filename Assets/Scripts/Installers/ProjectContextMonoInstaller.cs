using Firebase.Database;
using Scripts.Authentication;
using Scripts.Runner.Score;
using Zenject;

namespace Scripts.Installers
{
    public class ProjectContextMonoInstaller : MonoInstaller
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
        }
    }
}