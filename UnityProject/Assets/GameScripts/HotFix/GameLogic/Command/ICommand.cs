namespace GameLogic
{
    public interface ICommand
    {
        public void Do();
        public void UnDo();
    }
}