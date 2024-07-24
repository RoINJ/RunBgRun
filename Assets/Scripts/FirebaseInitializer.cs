using System;
using Firebase;
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
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    FirebaseApp.DefaultInstance.Options.DatabaseUrl = new Uri(Constants.DatabaseUrl);
                    firebaseAuthenticationProvider.IsInitialized = true;
                }
                else
                {
                    Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
                }
            });
        }
    }
}
