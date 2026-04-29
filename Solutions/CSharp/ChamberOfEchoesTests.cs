using System;
using System.Collections.Generic;

/// <summary>
/// Unit Tests for The Chamber of Echoes
///
/// Validates the sequence-prediction logic that forecasts the next echo
/// in an arithmetic progression.
///
/// </summary>
public class ChamberOfEchoesTests
{
    // ============================================================================
    // SEQUENCE PREDICTION TESTS
    // ============================================================================

    private static void TestDefaultSequence(TestResults testResults)
    {
        Console.WriteLine("\n🧪 Testing default echo sequence [3, 6, 9, 12]...");

        var echoes = new List<int> { 3, 6, 9, 12 };
        var next = ChamberOfEchoes.PredictNext(echoes);

        testResults.AssertEquals(next, 15, "Next in [3,6,9,12] should be 15");

        Console.WriteLine("✅ Default sequence test passed!");
    }

    private static void TestIncrementByOne(TestResults testResults)
    {
        Console.WriteLine("\n🧪 Testing sequence with increment of 1...");

        var echoes = new List<int> { 1, 2, 3, 4 };
        var next = ChamberOfEchoes.PredictNext(echoes);

        testResults.AssertEquals(next, 5, "Next in [1,2,3,4] should be 5");

        Console.WriteLine("✅ Increment-by-one test passed!");
    }

    private static void TestLargeIncrement(TestResults testResults)
    {
        Console.WriteLine("\n🧪 Testing sequence with large increment...");

        var echoes = new List<int> { 10, 20, 30 };
        var next = ChamberOfEchoes.PredictNext(echoes);

        testResults.AssertEquals(next, 40, "Next in [10,20,30] should be 40");

        Console.WriteLine("✅ Large-increment test passed!");
    }

    private static void TestNegativeIncrement(TestResults testResults)
    {
        Console.WriteLine("\n🧪 Testing descending sequence (negative increment)...");

        var echoes = new List<int> { 10, 8, 6, 4 };
        var next = ChamberOfEchoes.PredictNext(echoes);

        testResults.AssertEquals(next, 2, "Next in [10,8,6,4] should be 2");

        Console.WriteLine("✅ Negative-increment test passed!");
    }

    private static void TestMinimalTwoElementSequence(TestResults testResults)
    {
        Console.WriteLine("\n🧪 Testing minimal two-element sequence...");

        var echoes = new List<int> { 5, 10 };
        var next = ChamberOfEchoes.PredictNext(echoes);

        testResults.AssertEquals(next, 15, "Next in [5,10] should be 15");

        Console.WriteLine("✅ Two-element sequence test passed!");
    }

    private static void TestZeroIncrement(TestResults testResults)
    {
        Console.WriteLine("\n🧪 Testing sequence with no change (increment = 0)...");

        var echoes = new List<int> { 7, 7, 7 };
        var next = ChamberOfEchoes.PredictNext(echoes);

        testResults.AssertEquals(next, 7, "Next in [7,7,7] should be 7");

        Console.WriteLine("✅ Zero-increment test passed!");
    }

    // ============================================================================
    // MAIN TEST RUNNER
    // ============================================================================

    public static bool RunAllTests()
    {
        Console.WriteLine("🧪🔮 Starting Test Suite for The Chamber of Echoes 🔮🧪");
        Console.WriteLine("==============================================================");

        var testResults = new TestResults();

        try
        {
            TestDefaultSequence(testResults);
            TestIncrementByOne(testResults);
            TestLargeIncrement(testResults);
            TestNegativeIncrement(testResults);
            TestMinimalTwoElementSequence(testResults);
            TestZeroIncrement(testResults);

            Console.WriteLine($"\n📊 Results: {testResults.Passed} passed, {testResults.Failed} failed");

            if (testResults.Failed == 0)
            {
                Console.WriteLine("🎉 ALL CHAMBER OF ECHOES TESTS PASSED!");
                Console.WriteLine("✅ Sequence prediction logic fully validated");
            }
            else
            {
                Console.WriteLine("💥 SOME TESTS FAILED:");
                foreach (var error in testResults.Errors)
                    Console.WriteLine($"  - {error}");
            }

            return testResults.Failed == 0;
        }
        catch (Exception error)
        {
            Console.WriteLine($"\n💥 TEST SUITE FAILED! Error: {error.Message}");
            return false;
        }
    }
}

public class ChamberOfEchoesTestRunner
{
    public static void Run()
    {
        var success = ChamberOfEchoesTests.RunAllTests();
        if (!success)
        {
            Environment.Exit(1);
        }
    }
}
