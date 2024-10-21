namespace SpaceBattle.Lib.Tests;
using Moq;

public class MoveCommandTest
{
    [Fact]
    public void MoveCommandPositive()
    {

        var moving = new Mock<IMoving>();
        moving.SetupGet(m => m.Position).Returns(new int[] { 12, 5 });
        moving.SetupGet(m => m.Velocity).Returns(new int[] { -3, 3 });
        var mc = new MoveCommand(moving.Object);

        mc.Execute();


        moving.VerifySet(m => m.Position = new int[] { 9, 8 });
    }
}