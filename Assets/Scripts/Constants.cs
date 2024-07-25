namespace Scripts
{
    public class Constants
    {
#if UNITY_ANDROID
        public const string AdUnitId = "ca-app-pub-3940256099942544/5224354917";
#else
        private string _adUnitId = "Not configured";
#endif
        
        public const float StartMovementSpeed = 0.1f;
        public const float SpeedIncreasingAcceleration = 0.00002f;
        public const float SectionLength = 20f;
        public const int ActiveSectionsCount = 10;
        public const int ScoreboardLength = 25;
        public const string EmailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        public class Triggers
        {
            public const string RunTrigger = "RunTrigger";
            public const string JumpTrigger = "JumpTrigger";
            public const string SlideTrigger = "SlideTrigger";
            public const string DeathTrigger = "DeathTrigger";
        }
    }
}
