using System;
using System.Collections.Generic;

/// <summary>
/// Shared test utilities used across the CopilotAdventures test suites.
/// </summary>
public class TestResults
{
    public int Passed { get; set; } = 0;
    public int Failed { get; set; } = 0;
    public List<string> Errors { get; set; } = new();

    public void AssertTrue(bool condition, string message)
    {
        if (condition)
        {
            Console.WriteLine($"✅ PASS: {message}");
            Passed++;
        }
        else
        {
            Console.WriteLine($"❌ FAIL: {message}");
            Failed++;
            Errors.Add(message);
        }
    }

    public void AssertEquals<T>(T actual, T expected, string message)
    {
        if (EqualityComparer<T>.Default.Equals(actual, expected))
        {
            Console.WriteLine($"✅ PASS: {message}");
            Passed++;
        }
        else
        {
            Console.WriteLine($"❌ FAIL: {message} - Expected '{expected}', got '{actual}'");
            Failed++;
            Errors.Add($"{message} - Expected '{expected}', got '{actual}'");
        }
    }
}
