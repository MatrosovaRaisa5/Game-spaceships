namespace SpaceBattle.Lib.Tests;

using System.Numerics;
using Moq;

public class MoveCommandTest
{
    [Fact]
    public void MoveCommandPositive()
    {

        var moving = new Mock<IMoving>();
        moving.SetupGet(m => m.Position).Returns(new Vector2(12, 5));
        moving.SetupGet(m => m.Velocity).Returns(new Vector2(-3, 3));
        var mc = new MoveCommand(moving.Object);

        mc.Execute();


        moving.VerifySet(m => m.Position = new Vector2(9, 8));
    }
}