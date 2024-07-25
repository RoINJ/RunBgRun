namespace Scripts
{
    public class Constants
    {
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
