using MazeBuilderGame;
using Xunit;

namespace maze.test
{
    public class MazeSlotTest
    {
        [Theory]
        [InlineData(1, 0, WallPosition.Down)]
        [InlineData(1, 2, WallPosition.Up)]
        [InlineData(0, 1, WallPosition.Left)]
        [InlineData(2, 1, WallPosition.Rigth)]
        public void ShouldSetCorrectWallOnDestroyWall(int anotherX, int anotherY, WallPosition expectedPosition)
        {
            MazeSlot slot = new MazeSlot(1, 1);
            MazeSlot anotherSlot = new MazeSlot(anotherX, anotherY);

            slot.DestroyWall(anotherSlot);

            Assert.Single(slot.DestroyedWalls);
            Assert.Contains(expectedPosition, slot.DestroyedWalls);
        }

        [Fact]
        public void ShouldIgnoreSamePositionOnDestroyWall()
        {
            MazeSlot slot = new MazeSlot(1, 1);
            MazeSlot anotherSlot = new MazeSlot(1, 1);

            slot.DestroyWall(anotherSlot);

            Assert.Empty(slot.DestroyedWalls);
        }
    }
}
