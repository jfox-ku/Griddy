namespace Features.OrderedEvents
{
    public static class GameEvents
    {
        public static OrderedVoidEvent OnGameInitialized = new OrderedVoidEvent();
        public static OrderedVoidEvent OnGameStart = new OrderedVoidEvent();
        public static OrderedVoidEvent OnGameEnd = new OrderedVoidEvent();
        public static OrderedVoidEvent OnRoundComplete = new OrderedVoidEvent();
        public static OrderedVoidEvent OnRoundFail = new OrderedVoidEvent();
        public static OrderedVoidEvent OnRoundStart = new OrderedVoidEvent();
    }
}