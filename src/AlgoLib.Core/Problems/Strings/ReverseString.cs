using System;

namespace AlgoLib.Core.Problems.Strings;

public static class ReverseString
{
    public static string ReverseUsingArray(string testString)
    {
        char[] chars = new char[testString.Length];
        for (int i = 0; i < testString.Length; i++)
        {
            chars[i] = testString[testString.Length - 1 - i];
        }
        return new string(chars);
    }


    public static string ReverseUsingIndexFromEnd(string testString)
    {
        char[] chars = new char[testString.Length];
        for (int i = 0; i < testString.Length; i++)
        {
            chars[i] = testString[^(i + 1)];
        }
        return new string(chars);
    }


    public static string ReverseUsingSpan(string testString)
    {
        Span<char> buffer = stackalloc char[testString.Length];
        for (int i = 0; i < testString.Length; i++)
        {
            buffer[i] = testString[testString.Length - 1 - i];
        }
        return new string(buffer);
    }


    public static string ReverseUsingStringCreate(string testString)
    {
        return string.Create(testString.Length, testString, (span, str) =>
        {
            for (int i = 0; i < str.Length; i++)
            {
                span[str.Length - i - 1] = str[i];
            }
        });
    }



    public static string ReverseUsingSwap(string testString)
    {
        char[] inp = testString.ToCharArray();
        int len = inp.Length;
        for (int i = 0; i < len / 2; i++)
        {
            var temp = inp[i];
            inp[i] = inp[len - i - 1];
            inp[len - i - 1] = temp;
        }
        return new string(inp);
    }


    public static string ReverseUsingArrayReverse(string testString)
    {
        char[] inp = testString.ToCharArray();
        Array.Reverse(inp);
        return new string(inp);
    }

    /// <summary>
    /// Reversing using span seems to be best option if strings are not too large
    /// </summary>
    /// <returns></returns>
    public static string ReverseUsingSpanReverse(string testString)
    {
        Span<char> span = stackalloc char[testString.Length];
        testString.AsSpan().CopyTo(span);
        span.Reverse();
        return new string(span);
    }
}
