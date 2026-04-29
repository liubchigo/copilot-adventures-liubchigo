using System;
using System.Collections.Generic;

/// <summary>
/// Unit Tests for The Scrolls of Eldoria
///
/// Validates the secret-extraction logic that deciphers hidden messages
/// from scroll content using the {* ... *} pattern.
///
/// </summary>
public class EldoriaTests
{
    // ============================================================================
    // SECRET EXTRACTION TESTS
    // ============================================================================

    private static void TestExtractSingleSecret(TestResults testResults)
    {
        Console.WriteLine("\n🧪 Testing single secret extraction...");

        var scrollContent = "Some noise {*hidden treasure*} more noise";
        var secrets = Eldoria.ExtractSecrets(scrollContent);

        testResults.AssertEquals(secrets.Count, 1, "Should find exactly one secret");
        testResults.AssertEquals(secrets[0], "hidden treasure", "Secret value should match");

        Console.WriteLine("✅ Single secret extraction test passed!");
    }

    private static void TestExtractMultipleSecrets(TestResults testResults)
    {
        Console.WriteLine("\n🧪 Testing multiple secret extraction...");

        var scrollContent = "begin {*first secret*} middle {*second secret*} end {*third secret*}";
        var secrets = Eldoria.ExtractSecrets(scrollContent);

        testResults.AssertEquals(secrets.Count, 3, "Should find three secrets");
        testResults.AssertEquals(secrets[0], "first secret", "First secret should match");
        testResults.AssertEquals(secrets[1], "second secret", "Second secret should match");
        testResults.AssertEquals(secrets[2], "third secret", "Third secret should match");

        Console.WriteLine("✅ Multiple secret extraction test passed!");
    }

    private static void TestNoSecretsInContent(TestResults testResults)
    {
        Console.WriteLine("\n🧪 Testing content with no secrets...");

        var scrollContent = "This scroll contains no hidden messages at all.";
        var secrets = Eldoria.ExtractSecrets(scrollContent);

        testResults.AssertEquals(secrets.Count, 0, "Should find no secrets in plain content");

        Console.WriteLine("✅ No-secrets test passed!");
    }

    private static void TestEmptyScrollContent(TestResults testResults)
    {
        Console.WriteLine("\n🧪 Testing empty scroll content...");

        var secrets = Eldoria.ExtractSecrets(string.Empty);

        testResults.AssertEquals(secrets.Count, 0, "Empty content should yield no secrets");

        Console.WriteLine("✅ Empty content test passed!");
    }

    private static void TestSecretWithSpecialCharacters(TestResults testResults)
    {
        Console.WriteLine("\n🧪 Testing secrets with special characters...");

        var scrollContent = "{*The key is: 42!*} and {*path/to/relic*}";
        var secrets = Eldoria.ExtractSecrets(scrollContent);

        testResults.AssertEquals(secrets.Count, 2, "Should find two secrets with special characters");
        testResults.AssertEquals(secrets[0], "The key is: 42!", "Secret with punctuation should match");
        testResults.AssertEquals(secrets[1], "path/to/relic", "Secret with slash should match");

        Console.WriteLine("✅ Special characters test passed!");
    }

    private static void TestPatternDoesNotMatchPartialDelimiters(TestResults testResults)
    {
        Console.WriteLine("\n🧪 Testing that partial delimiters do not match...");

        var scrollContent = "{not a secret} and {*real secret*} and *also not*";
        var secrets = Eldoria.ExtractSecrets(scrollContent);

        testResults.AssertEquals(secrets.Count, 1, "Only the {* *} pattern should match");
        testResults.AssertEquals(secrets[0], "real secret", "Only the correctly delimited secret should be found");

        Console.WriteLine("✅ Partial delimiter test passed!");
    }

    // ============================================================================
    // MAIN TEST RUNNER
    // ============================================================================

    public static bool RunAllTests()
    {
        Console.WriteLine("🧪📜 Starting Test Suite for The Scrolls of Eldoria 📜🧪");
        Console.WriteLine("===============================================================");

        var testResults = new TestResults();

        try
        {
            TestExtractSingleSecret(testResults);
            TestExtractMultipleSecrets(testResults);
            TestNoSecretsInContent(testResults);
            TestEmptyScrollContent(testResults);
            TestSecretWithSpecialCharacters(testResults);
            TestPatternDoesNotMatchPartialDelimiters(testResults);

            Console.WriteLine($"\n📊 Results: {testResults.Passed} passed, {testResults.Failed} failed");

            if (testResults.Failed == 0)
            {
                Console.WriteLine("🎉 ALL ELDORIA TESTS PASSED!");
                Console.WriteLine("✅ Secret extraction logic fully validated");
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

public class EldoriaTestRunner
{
    public static void Run()
    {
        var success = EldoriaTests.RunAllTests();
        if (!success)
        {
            Environment.Exit(1);
        }
    }
}
