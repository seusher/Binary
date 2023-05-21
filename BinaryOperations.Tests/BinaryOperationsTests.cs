namespace BinaryOperations.Tests;

using System;
using System.Collections;
using System.Collections.Generic;
using BinaryOperations;

public class BinaryOperationsTest
{
    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    private void BasicTestCase(int a, int b, int expectedOverflow)
    {
        var result = BinaryOp.Add(a, b);
        Assert.Equal(a + b, result.Value);
        Assert.Equal(expectedOverflow, result.OverUnderflow);
    }
}

public class TestDataGenerator : IEnumerable<object[]>
{
    // The initial set of test cases to run.
    private readonly List<object[]> _data = new()
    {
        new object[] {0, 0, 0},
        new object[] {500, -75, 0},
        new object[] {-250, 44, 0},
        new object[] {-250, -44, 0},
        new object[] {Int32.MaxValue, Int32.MaxValue, 1},
        new object[] {Int32.MaxValue, 1, 1},
        new object[] {Int32.MaxValue - 1, 1, 0},
        new object[] {Int32.MaxValue, -Int32.MaxValue, 0},
        new object[] {-Int32.MaxValue, -Int32.MaxValue, 1},
    };

    public TestDataGenerator()
    {
        // Add some random values in for the tests to keep us honest.
        var rand = new Random();

        foreach (var i in Enumerable.Range(0, 1000))
        {
            var a = rand.Next();
            var b = rand.Next();

            // In C#, an overflow results in a number lower than the initial numbers.
            int overflow = (a + b) < a ? 1 : 0;

            _data.Add(new object[] {a, b, overflow});
        }

        foreach (int i in Enumerable.Range(0, 1000))
        {
            int a = rand.Next(int.MinValue, 0);
            int b = rand.Next(int.MinValue, 0);

            // In C#, an underflow results in a number larger than the initial numbers.
            // These numbers are negative or 0, so still use the '+' operator.
            int underflow = (a + b) > a ? 1 : 0;

            _data.Add(new object[] {a, b, underflow});
        }
    }

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}