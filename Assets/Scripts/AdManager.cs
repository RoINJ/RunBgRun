using System;
using GoogleMobileAds.Api;
using UnityEngine;

namespace Scripts
{
    public class AdManager : MonoBehaviour
    {
#if UNITY_ANDROID
        private string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
#else
  private string _adUnitId = "Not configured";
#endif

        private RewardedAd _rewardedAd;

        public void Start()
        {
            MobileAds.Initialize(_ => LoadRewardedAd());
        }

        public void LoadRewardedAd()
        {
            if (_rewardedAd is not null)
            {
                _rewardedAd.Destroy();
                _rewardedAd = null;
            }

            Debug.Log("Loading the rewarded ad.");

            RewardedAd.Load(_adUnitId, new AdRequest(),
                (RewardedAd ad, LoadAdError error) =>
                {
                    // if error is not null, the load request failed.
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

        public void ShowRewardedAd(Action callback)
        {
            if (_rewardedAd is not null && _rewardedAd.CanShowAd())
            {
                _rewardedAd.Show((Reward reward) =>
                {
                    callback?.Invoke();
                    LoadRewardedAd();
                });
            }
        }
    }
}
