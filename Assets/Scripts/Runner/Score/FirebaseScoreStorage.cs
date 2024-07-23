using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using Zenject;

namespace Scripts.Runner.Score
{
    public class FirebaseScoreStorage : IScoreStorage
    {
        private DatabaseReference _databaseReference;

        [Inject]
        private void Init(DatabaseReference databaseReference)
        {
            _databaseReference = databaseReference;
        }

        public void SaveScore(ScoreEntity score)
        {
            var key = _databaseReference.Child("scores").Push().Key;
            var json = JsonUtility.ToJson(score);
            _databaseReference.Child("scores").Child(key).SetRawJsonValueAsync(json);
        }

        public void GetTopScores(Action<IReadOnlyList<ScoreEntity>> resultCallback)
        {
            _databaseReference.Child("scores").GetValueAsync().ContinueWithOnMainThread(task =>
            {
                var result = task.Result.Children
                    .Take(Constants.ScoreboardLength)
                    .Select(snapshot =>
                    {
                        var score = (IDictionary)snapshot.Value;
                        return new ScoreEntity
                        {
                            Username = score["Username"].ToString(),
                            Score = int.Parse(score["Score"].ToString())
                        };
                    })
                    .OrderByDescending(s => s.Score)
                    .ToList();

                resultCallback?.Invoke(result);
            });
        }
    }
}
