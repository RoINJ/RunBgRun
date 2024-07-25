using System;
using GoogleMobileAds.Api;
using UnityEngine;
using Zenject;

namespace Scripts
{
    public class AdManager : MonoBehaviour
    {
        private GameConfiguration _gameConfiguration;
        private RewardedAd _rewardedAd;

        public void ShowRewardedAd(Action callback)
        {
            if (_rewardedAd is not null && _rewardedAd.CanShowAd())
            {
                _rewardedAd.Show(_ =>
                {
                    callback?.Invoke();
                    LoadRewardedAd();
                });
            }
        }

        [Inject]
        private void Init(GameConfiguration gameConfiguration)
        {
            _gameConfiguration = gameConfiguration;
        }

        private void Start()
        {
            MobileAds.Initialize(_ => LoadRewardedAd());
        }

        private void LoadRewardedAd()
        {
            if (_rewardedAd is not null)
            {
                _rewardedAd.Destroy();
                _rewardedAd = null;
            }

            Debug.Log("Loading the rewarded ad.");

            RewardedAd.Load(_gameConfiguration.AdUnitAndroidId, new AdRequest(),
                (ad, error) =>
                {
                    if (error is null && ad is not null)
                    {
                        Debug.Log("Rewarded ad loaded with response : "
                                  + ad.GetResponseInfo());

                        _rewardedAd = ad;
                    }
                    else
                    {
                        Debug.LogError("Rewarded ad failed to load an ad " +
                                       "with error : " + error);
                    }
                });
        }
    }
}
