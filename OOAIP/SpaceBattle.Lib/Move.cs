using System.Numerics;

namespace SpaceBattle.Lib;

public interface IMoving
{
    Vector2 Position { get;set; }
    Vector2 Velocity { get; }
}

public interface ICommand
{
    void Execute();
}

public class MoveCommand : ICommand
{
    private IMoving obj;
    public MoveCommand(IMoving obj)
    {
        this.obj = obj;
    }
    public void Execute()
    {
        obj.Position = obj.Position + obj.Velocity;
    }
}