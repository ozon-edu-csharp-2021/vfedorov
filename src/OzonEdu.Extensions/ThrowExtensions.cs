namespace OzonEdu.Extensions
{
    using System;

    public static class ThrowExtensions
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the specified argument is null
        /// </summary>
        /// <typeparam name="TArg">Type of argument, should be class</typeparam>
        /// <param name="value">Argument value to check</param>
        /// <param name="parmName">Parameter name to include into exception</param>
        /// <exception cref="ArgumentNullException">When specified <paramref name="value"/> is null</exception>
        public static void ThrowIfNull<TArg>(this TArg value, string parmName)
            where TArg : class
        {
            if (value is null)
            {
                throw new ArgumentNullException(parmName);
            }
        }

        public static void ThrowIfNull<TArg, TException>(this TArg value, TException exception)
            where TException : Exception
        {
            if (value is null)
            {
                throw exception;
            }
        }
    }
}
