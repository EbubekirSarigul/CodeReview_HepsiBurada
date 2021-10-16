using CodeReview_HepsiBurada;
using NUnit.Framework;
using System;

namespace CodeReview_HepsiBurada_Unit_Tests
{
    [TestFixture]
    public class ExplorationTests
    {
        [Test]
        public void OneRoverTest()
        {
            var input = "5 5\n" +
                        "1 2 N\n" +
                        "LMLMLMLMM";

            Exploration sut = new Exploration();
            var result = sut.Explore(input);

            var roverResults = result.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.That(roverResults.Length, Is.EqualTo(1));
            Assert.That(roverResults[0], Is.EqualTo("1 3 N"));
        }

        [Test]
        public void TwoRoverTest()
        {
            var input = "5 5\n" +
                        "1 2 N\n" +
                        "LMLMLMLMM\n" +
                        "3 3 E\n" +
                        "MMRMMRMRRM";

            Exploration sut = new Exploration();
            var result = sut.Explore(input);

            var roverResults = result.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.That(roverResults.Length, Is.EqualTo(2));
            Assert.That(roverResults[0], Is.EqualTo("1 3 N"));
            Assert.That(roverResults[1], Is.EqualTo("5 1 E"));
        }

        [Test]
        public void LengthOfTheXAxisIsInvalid()
        {
            var input = "a 5\n" +
                        "1 2 N\n" +
                        "LMLMLMLMM\n" +
                        "3 3 E\n" +
                        "MMRMMRMRRM";

            Exploration sut = new Exploration();
            var result = sut.Explore(input);

            Assert.That(result, Is.EqualTo("::ErrorOccured::Length of the x axis is invalid:a"));
        }

        [Test]
        public void LengthOfTheYAxisIsInvalid()
        {
            var input = "5 abc\n" +
                        "1 2 N\n" +
                        "LMLMLMLMM\n" +
                        "3 3 E\n" +
                        "MMRMMRMRRM";

            Exploration sut = new Exploration();
            var result = sut.Explore(input);

            Assert.That(result, Is.EqualTo("::ErrorOccured::Length of the y axis is invalid:abc"));
        }

        [Test]
        public void InitialXIsInvalid()
        {
            var input = "5 5\n" +
                        "a 2 N\n" +
                        "LMLMLMLMM\n" +
                        "3 3 E\n" +
                        "MMRMMRMRRM";

            Exploration sut = new Exploration();
            var result = sut.Explore(input);

            Assert.That(result, Is.EqualTo("::ErrorOccured::Initial X is invalid:a"));
        }

        [Test]
        public void InitialYIsInvalid()
        {
            var input = "5 5\n" +
                        "1 a N\n" +
                        "LMLMLMLMM\n" +
                        "3 3 E\n" +
                        "MMRMMRMRRM";

            Exploration sut = new Exploration();
            var result = sut.Explore(input);

            Assert.That(result, Is.EqualTo("::ErrorOccured::Initial Y is invalid:a"));
        }

        [Test]
        public void InitialDirectionIsInvalid()
        {
            var input = "5 5\n" +
                        "1 2 O\n" +
                        "LMLMLMLMM\n" +
                        "3 3 E\n" +
                        "MMRMMRMRRM";

            Exploration sut = new Exploration();
            var result = sut.Explore(input);

            Assert.That(result, Is.EqualTo("::ErrorOccured::Invalid input! Following direction is invalid:O"));
        }

        [Test]
        public void RoverWentOutOfThePlateau()
        {
            var input = "5 5\n" +
                        "1 2 N\n" +
                        "LMMLMLMLMM\n" +
                        "3 3 E\n" +
                        "MMRMMRMRRM";

            Exploration sut = new Exploration();
            var result = sut.Explore(input);

            Assert.That(result, Is.EqualTo("::ErrorOccured::Invalid movement! Rover went out of the plateau."));
        }

        [Test]
        public void RoverWentOutOfThePlateau2()
        {
            var input = "5 5\n" +
                        "1 2 N\n" +
                        "LMLMLMLMM\n" +
                        "3 3 E\n" +
                        "MMMRMMRMRRM";

            Exploration sut = new Exploration();
            var result = sut.Explore(input);

            Assert.That(result, Is.EqualTo("::ErrorOccured::Invalid movement! Rover went out of the plateau."));
        }

        [Test]
        public void InvalidCommandInInstructions()
        {
            var input = "5 5\n" +
                        "1 2 N\n" +
                        "LMLMLMLMM\n" +
                        "3 3 E\n" +
                        "MMUMMRMRRM";

            Exploration sut = new Exploration();
            var result = sut.Explore(input);

            Assert.That(result, Is.EqualTo("::ErrorOccured::Invalid command in instructions:U"));
        }
    }
}
