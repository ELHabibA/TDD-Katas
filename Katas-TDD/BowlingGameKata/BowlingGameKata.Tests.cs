

namespace Katas_TDD.BowlingGameKata
{
    public class BowlingGameKataTests
    {
        BowlingGameKata game = new BowlingGameKata();


        [Fact]
        public void When_RollZero_TheScoreShouldbeZero()
        {
            game.roll(0);

            Assert.Equal(0, game.score());
        }



        [Fact]
        public void When_OppenFrame_TheScoreAdds()
        {
            game.roll(3);
            game.roll(5);

            Assert.Equal(8, game.score());
        }

        [Fact]
        public void When_Spare_TheScoreAddsPinsknockedDownInTheNextBall()
        {
            game.roll(3);
            game.roll(7);
            game.roll(5);

            Assert.Equal(20, game.score());
        }

        [Fact]
        public void When_TenInTwoFrames_TheScoreDoesntAdd()
        {
            game.roll(2);
            game.roll(7);
            game.roll(3);
            game.roll(4);

            Assert.Equal(16, game.score());
        }

        [Fact]
        public void When_Strike_TheScoreAddsPinsknockedDownInTheNextTwoBalls()
        {
            game.roll(10);
            game.roll(2);
            game.roll(3);

            Assert.Equal(20, game.score());
        }

        [Fact]
        public void When_PerfectGame_TheScoreIs300()
        {
            for (int i = 0; i < 12; i++)
            {
                game.roll(10);
            }

            Assert.Equal(300, game.score());
        }
    }
}
