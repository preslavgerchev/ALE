namespace AutomataLogicEngineering.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// A static text extensions class.
    /// </summary>
    public static class TestExtensions
    {
        /// <summary>
        /// Verifies if the given <paramref name="action"/> will throw <typeparamref name="TException" />. If
        /// this does not happen the test fails with <see cref="AssertFailedException"/>.
        /// </summary>
        /// <typeparam name="TException">The expected exception type.</typeparam>
        /// <param name="action">The action that should throw <typeparamref name="TException"/>.</param>
        public static void Throws<TException>(Action action) where TException : Exception
        {
            try
            {
                action();
                throw new AssertFailedException(
                    $"The action did not throw expected exception of type {typeof(TException)}");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType(), typeof(TException));
            }
        }

        /// <summary>
        /// Verifies if the given <paramref name="action"/> will throw <typeparamref name="TException" /> that will contain
        /// <paramref name="expectedMessage"/>. If this does not happen the test fails with <see cref="AssertFailedException"/>.
        /// </summary>
        /// <typeparam name="TException">The expected exception type.</typeparam>
        /// <param name="action">The action that should throw <typeparamref name="TException"/>.</param>
        /// <param name="expectedMessage">The expected message for the <typeparamref name="TException"/>.</param>
        public static void Throws<TException>(Action action, string expectedMessage) where TException : Exception
        {
            try
            {
                action();
                throw new AssertFailedException(
                    $"The action did not throw expected exception of type {typeof(TException)}");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType(), typeof(TException));
                Assert.IsTrue(ex.Message.Contains(expectedMessage));
            }
        }
    }
}
