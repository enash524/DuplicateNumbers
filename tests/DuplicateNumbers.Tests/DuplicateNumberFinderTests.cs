using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DuplicateNumbers.Tests
{
    public class DuplicateNumberFinderTests
    {
        private readonly IDuplicateNumberFinder _duplicateNumberFinder;
        private readonly Mock<ILogger<DuplicateNumberFinder>> _logger;

        public DuplicateNumberFinderTests()
        {
            _logger = new Mock<ILogger<DuplicateNumberFinder>>();
            _duplicateNumberFinder = new DuplicateNumberFinder(_logger.Object);
        }

        public static IEnumerable<object[]> FindDuplicateNumbersTestData =>
           new List<object[]>
           {
                new object[]
                {
                    new int[6] { 1, 2, 2, 3, 3, 3 },
                    new Dictionary<int, int>
                    {
                        { 2, 1 },
                        { 3, 2 }
                    }
                }
           };

        [Fact]
        public void FindDuplicateNumbers_EmptyInput_Test()
        {
            // Arrange
            const string expected = "Collection cannot be empty (Parameter 'numbers')";
            int[] input = Array.Empty<int>();

            // Act
            Action actual = () => _duplicateNumberFinder.FindDuplicateNumbers(input);

            // Assert
            actual
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(expected);

            _logger.Invocations.Count
                .Should()
                .Be(1);

            _logger.Invocations[0].Arguments[0]
                .Should()
                .Be(LogLevel.Error);

            _logger
                .Verify(x => x.Log(LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((x, t) => string.Equals(x.ToString(), expected)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                    Times.Once());
        }

        [Fact]
        public void FindDuplicateNumbers_NullInput_Test()
        {
            // Arrange
            const string expected = "Collection cannot be null (Parameter 'numbers')";

            // Act
            Action actual = () => _duplicateNumberFinder.FindDuplicateNumbers(null);

            // Assert
            actual
                .Should()
                .Throw<ArgumentNullException>()
                .WithMessage(expected);

            _logger.Invocations.Count
                .Should()
                .Be(1);

            _logger.Invocations[0].Arguments[0]
                .Should()
                .Be(LogLevel.Error);

            _logger
                .Verify(x => x.Log(LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((x, t) => string.Equals(x.ToString(), expected)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                    Times.Once());
        }

        [Theory]
        [MemberData(nameof(FindDuplicateNumbersTestData))]
        public void FindDuplicateNumbersTest(int[] numbers, Dictionary<int, int> expected)
        {
            // Arrange

            // Act
            Dictionary<int, int> actual = _duplicateNumberFinder.FindDuplicateNumbers(numbers);

            // Assert
            actual
                .Should()
                .NotBeNull()
                .And
                .NotContainKey(1)
                .And
                .BeEquivalentTo(expected);
        }
    }
}