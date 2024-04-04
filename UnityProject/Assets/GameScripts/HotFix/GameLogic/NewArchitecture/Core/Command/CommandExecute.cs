namespace GameLogic.NewArchitecture.Core
{
    public static class CommandExecute
    {
        public static void Execute<T>() where T : ICommand, new()
        {
            T t = new T();
            t.Run();
        }
    }
}