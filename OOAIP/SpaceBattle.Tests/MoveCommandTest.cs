using System.Numerics;
using Moq;

namespace SpaceBattle.Lib.Tests
{
    public class MoveCommandTest
    {
        [Fact]
        public void MoveCommandOrdinaryTest()
        {
            var moving = new Mock<IMoving>();
            moving.SetupGet(m => m.Position).Returns(new Vector2(12, 5));
            moving.SetupGet(m => m.Velocity).Returns(new Vector2(-7, 3));

            var cmd = new MoveCommand(moving.Object);
            cmd.Execute();

            moving.VerifySet(m => m.Position = new Vector2(5, 8));
        }

        [Fact]
        public void MoveCommand_PositionNotReadable()
        {
            var moving = new Mock<IMoving>();
            moving.SetupGet(m => m.Position).Throws<Exception>();

            var cmd = new MoveCommand(moving.Object);

            Assert.Throws<Exception>(() => cmd.Execute());
        }

        [Fact]
        public void MoveCommand_VelocityNotReadable()
        {
            var moving = new Mock<IMoving>();
            moving.SetupGet(m => m.Position).Returns(new Vector2(12, 5));
            moving.SetupGet(m => m.Velocity).Throws<Exception>();

            var cmd = new MoveCommand(moving.Object);

            Assert.Throws<Exception>(() => cmd.Execute());
        }

        [Fact]
        public void MoveCommand_PositionNotSettable()
        {
            var moving = new Mock<IMoving>();
            moving.SetupGet(m => m.Position).Returns(new Vector2(12, 5));
            moving.SetupGet(m => m.Velocity).Returns(new Vector2(-7, 3));
            moving.SetupSet(m => m.Position = It.IsAny<Vector2>()).Throws<Exception>();

            var cmd = new MoveCommand(moving.Object);

            Assert.Throws<Exception>(() => cmd.Execute());
        }
    }
}