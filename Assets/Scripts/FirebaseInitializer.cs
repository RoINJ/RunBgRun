using Scripts.Authentication;
using UnityEngine;
using Zenject;

namespace Scripts
{
    public class FirebaseInitializer : MonoBehaviour
    {
        [Inject]
        private void Init(FirebaseAuthenticationProvider firebaseAuthenticationProvider)
        {
            firebaseAuthenticationProvider.InitializeFirebase();
        }
    }
}
