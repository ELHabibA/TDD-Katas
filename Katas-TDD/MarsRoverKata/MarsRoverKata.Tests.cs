using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas_TDD.MarsRoverKata
{
    public class MarsRoverKataTests
    {
        [Theory]
        [InlineData("11E", "F", "12E", new string[] { "23" }, "")]
        [InlineData("11E", "FF", "13E", new string[] { "23" }, "")]
        [InlineData("11E", "FFF", "14E", new string[] { "23" }, "")]
        [InlineData("11S", "F", "21S", new string[] { "23" }, "")]
        [InlineData("11S", "FF", "31S", new string[] { "23" }, "")]
        [InlineData("11S", "FFF", "41S", new string[] { "23" }, "")]
        [InlineData("12W", "F", "11W", new string[] { "23" }, "")]
        [InlineData("14W", "FF", "12W", new string[] { "23" }, "")]
        [InlineData("15W", "FFF", "12W", new string[] { "23" }, "")]
        [InlineData("21N", "F", "11N", new string[] { "23" }, "")]
        [InlineData("41N", "FF", "21N", new string[] { "23" }, "")]
        [InlineData("51N", "FFF", "21N", new string[] { "23" }, "")]
        [InlineData("22N", "FL", "12W", new string[] { "11" }, "")]
        [InlineData("33N", "F", "33N", new string[] { "23" }, "")]
        [InlineData("35S", "FF", "45S", new string[] { "55" }, "")]
        [InlineData("33E", "FFLF", "35N", new string[] { "25" }, "")]
        [InlineData("33W", "F", "33W", new string[] { "32" }, "")]
        [InlineData("55N", "FFLFFFRFRRFLFFRFFF", "11N", new string[] { "14", "23", "32" }, "")]
        [InlineData("51W", "F", "51W", new string[] { "55" }, "")]
        public void When_RverMovesForward(string startingPoint, string interaction, string endposition, string[] obs, string obsMessage)
        {
            var rover = new MarsRoverKata(startingPoint, obs);
            var newPosition = rover.Move(interaction, obsMessage);
            Assert.Equal(endposition, newPosition.newPosition);
        }

        [Theory]
        [InlineData("42N", "F", "42N", new string[] { "32" }, "Obs at : 32")]
        public void When_RverMovesForward_ObsMessageMustBeShown(string startingPoint, string interaction, string endposition, string[] obs, string obsMessage)
        {
            var rover = new MarsRoverKata(startingPoint, obs);
            var newPosition = rover.Move(interaction, obsMessage);
            Assert.Equal(endposition, newPosition.newPosition);
            Assert.Equal(obsMessage, newPosition.obstacleMessage);
        }

        [Theory]
        [InlineData("123E", "F", new string[] { "23" }, "")]
        [InlineData("1SS", "FF", new string[] { "23" }, "")]
        [InlineData("E1S", "FLF", new string[] { "23" }, "")]
        [InlineData("123", "FFF", new string[] { "23" }, "")]
        [InlineData("12M", "F", new string[] { "23" }, "")]

        public void When_InvalidStartingPointIsProvided(string startingPoint, string interaction, string[] obs, string obsMessage)
        {
            var rover = new MarsRoverKata(startingPoint, obs);
            var exception = Record.Exception(() => rover.Move(interaction, obsMessage));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("Enter a valid Position", exception.Message);
        }

        [Theory]
        [InlineData("12E", "ABC", new string[] { "23" }, "")]
        [InlineData("111W", "123", new string[] { "23" }, "")]
        [InlineData("32N", "FB1", new string[] { "23" }, "")]
        public void When_InvalidInteractionIsProvided(string startingPoint, string interaction, string[] obs, string obsMessage)
        {
            var rover = new MarsRoverKata(startingPoint, obs);
            var exception = Record.Exception(() => rover.Move(interaction, obsMessage));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("Enter a valid Interaction", exception.Message);
        }
    }
}
