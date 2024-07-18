using System;
using System.Collections;
using Firebase;
using Firebase.Auth;
using UnityEngine;

namespace Scripts.Authentication
{
    public class FirebaseAuthenticationProvider : IAuthenticationProvider
    {
        public IEnumerator SignIn(string email, string password, Action<User> onSuccess, Action<string> onFailure)
        {
            var loginTask = FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email, password);

            yield return new WaitUntil(() => loginTask.IsCompleted);

            if (loginTask.Exception is not null)
            {
                Debug.LogWarning(message: $"Failed to register task with {loginTask.Exception}");

                var firebaseEx = (FirebaseException)loginTask.Exception.GetBaseException();
                var errorCode = (AuthError)firebaseEx.ErrorCode;

                var message = errorCode switch
                {
                    AuthError.MissingEmail => "Missing Email",
                    AuthError.MissingPassword => "Missing Password",
                    AuthError.WrongPassword => "Wrong Password",
                    AuthError.InvalidEmail => "Invalid Email",
                    AuthError.UserNotFound => "Account does not exist",
                    _ => "Login Failed!",
                };

                Debug.LogWarning($"Failed to register task. {message}");
                onFailure(message);
            }
            else
            {
                var user = loginTask.Result.User;
                var castedUser = new User
                {
                    Email = user.Email,
                    Username = user.DisplayName
                };

                Debug.LogFormat("User signed in successfully: {0} ({1})", user.DisplayName, user.Email);
                onSuccess(castedUser);
            }
        }

        public IEnumerator SignUp(string email, string password, string username, Action<User> onSuccess, Action<string> onFailure)
        {
            var signUpTask = FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(email, password);

            yield return new WaitUntil(() => signUpTask.IsCompleted);

            if (signUpTask.Exception != null)
            {
                Debug.LogWarning(message: $"Failed to register task with {signUpTask.Exception}");
                FirebaseException firebaseEx = signUpTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }

                onFailure(message);
            }
            else
            {
                var user = signUpTask.Result.User;

                if (user is not null)
                {
                    var profile = new UserProfile { DisplayName = username };

                    var updateProfileTask = user.UpdateUserProfileAsync(profile);

                    yield return new WaitUntil(() => updateProfileTask.IsCompleted);

                    if (updateProfileTask.Exception != null)
                    {
                        Debug.LogWarningFormat("Failed to register task with", updateProfileTask.Exception);
                    }
                    else
                    {
                        var castedUser = new User
                        {
                            Email = user.Email,
                            Username = user.DisplayName
                        };
                        
                        onSuccess(castedUser);
                    }
                }
                else
                {
                    onFailure("User is null");
                }
            }
        }
    }
}
