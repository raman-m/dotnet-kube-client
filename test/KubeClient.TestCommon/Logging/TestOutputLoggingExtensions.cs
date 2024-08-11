using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace KubeClient.TestCommon.Logging
{
    /// <summary>
    ///     Extension methods for logging to Xunit text output.
    /// </summary>
    public static class TestOutputLoggingExtensions
    {
        static readonly LogLevel DefaultMinLogLevel = LogLevel.Information;

        /// <summary>
        ///     Log to test output.
        /// </summary>
        /// <param name="logging">
        ///     The global logging configuration.
        /// </param>
        /// <param name="testOutput">
        ///     Output for the current test.
        /// </param>
        /// <param name="minLogLevel">
        ///     The minimum level to log at.
        /// </param>
        public static void AddTestOutput(this ILoggingBuilder logging, ITestOutputHelper testOutput, LogLevel? minLogLevel = null)
        {
            if (logging == null)
                throw new ArgumentNullException(nameof(logging));

            if (testOutput == null)
                throw new ArgumentNullException(nameof(testOutput));
            
            logging.AddProvider(
                new TestOutputLoggerProvider(testOutput, minLogLevel ?? DefaultMinLogLevel)
            );
        }

        /// <summary>
        ///     Log to test output.
        /// </summary>
        /// <param name="loggers">
        ///     The logger factory.
        /// </param>
        /// <param name="testOutput">
        ///     Output for the current test.
        /// </param>
        /// <param name="minLogLevel">
        ///     The minimum level to log at.
        /// </param>
        /// <returns>
        ///     The logger factory (enables inline use / method-chaining).
        /// </returns>
        public static ILoggerFactory AddTestOutput(this ILoggerFactory loggers, ITestOutputHelper testOutput, LogLevel? minLogLevel = null)
        {
            if (loggers == null)
                throw new ArgumentNullException(nameof(loggers));
            
            if (testOutput == null)
                throw new ArgumentNullException(nameof(testOutput));
            
            loggers.AddProvider(
                new TestOutputLoggerProvider(testOutput, minLogLevel ?? DefaultMinLogLevel)
            );

            return loggers;
        }
    }
}