namespace Devil2
{
    class oGlobal
    {
    }

    //Log Level을 지정할 Enum
    public enum enLogLevel
    {
        Info,
        Warning,
        Error,
    }

    //공통 선언
    // UserControl에서 Main으로 Log를 전달 하기 위한 Delegate
    //public delegate void delLogSender(object oSender, enLogLevel eLevel, string strLog);
}
