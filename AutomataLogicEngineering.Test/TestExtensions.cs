namespace AutomataLogicEngineering.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class TestExtensions
    {
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
    }
}
