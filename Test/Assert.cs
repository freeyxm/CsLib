using System;
using System.Diagnostics;

namespace Test
{
    static class Assert
    {
        public static void Fail(string msg = "failed")
        {
            Debug.Fail(msg);
        }

        public static void True(bool condition)
        {
            Debug.Assert(condition, $"Expected: {condition}");
        }

        public static void AreEqual(int expected, int actual)
        {
            Debug.Assert(expected == actual, $"Expected: {expected}, Actual: {actual}");
        }

        public static void AreEqual(bool expected, bool actual)
        {
            Debug.Assert(expected == actual, $"Expected: {expected}, Actual: {actual}");
        }

        public static void AreEqual(object expected, object actual)
        {
            Debug.Assert(Equals(expected, actual), $"Expected: {expected}, Actual: {actual}");
        }

        public static void Catch<T>(Action action) where T : Exception
        {
            bool catchException = false;
            try
            {
                action();
            }
            catch (T)
            {
                catchException = true;
            }

            if (!catchException)
            {
                Fail($"Expected exception of type {typeof(T).Name} was not thrown.");
            }
        }
    }
}
