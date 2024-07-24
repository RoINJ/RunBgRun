namespace Scripts
{
    public class Constants
    {
        public const float StartMovementSpeed = 0.1f;

        public const float SpeedIncreasingAcceleration = 0.00002f;

        public const float SectionLength = 20f;

        public const int ActiveSectionsCount = 4;

        public const int ScoreboardLength = 25;

        public const string EmailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        // TODO: Move to config file
        public const string DatabaseUrl = "https://runbgrun-c6887-default-rtdb.europe-west1.firebasedatabase.app/";
    }
}
