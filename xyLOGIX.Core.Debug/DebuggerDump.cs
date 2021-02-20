﻿using System;
using System.IO;
using xyLOGIX.Core.Debug.Properties;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Methods to send objects to the log by calling an extension method called
    /// 'Dump', like in LINQpad.
    /// </summary>
    public static class DebuggerDump
    {
        /// <summary>
        /// Dumps the specified object, a reference to which is in the <paramref
        /// name="element"/> parameter, to the log.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to the object whose contents are to be dumped.
        /// </param>
        /// <exception cref="T:ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="element"/>, is
        /// passed a <c>null</c> value.
        /// </exception>
        public static void Dump(this object element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            ObjectDumper.Write(element);
        }

        /// <summary>
        /// Dumps the specified object, a reference to which is in the <paramref
        /// name="element"/> parameter, to the log.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to the object whose contents are to be dumped.
        /// </param>
        /// ///
        /// <param name="depth">
        /// (Required.) Integer value specifying the depth to which the object
        /// should be dumped.
        /// </param>
        /// <exception cref="T:ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="element"/>, is
        /// passed a <c>null</c> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="depth"/> parameter is less than zero.
        /// </exception>
        public static void Dump(this object element, int depth)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (depth < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(depth), Resources.Error_DepthMustBeNonNegative
                );
            ObjectDumper.Write(element, depth);
        }

        /// <summary>
        /// Dumps the specified object, a reference to which is in the <paramref
        /// name="element"/> parameter, to the log.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to the object whose contents are to be dumped.
        /// </param>
        /// <param name="depth">
        /// (Required.) Integer value specifying the depth to which the object
        /// should be dumped.
        /// </param>
        /// <param name="log">
        /// (Required.) Reference to an instance of <see
        /// cref="T:System.IO.TextWriter"/> that is open on the target log file.
        /// </param>
        /// <exception cref="T:ArgumentNullException">
        /// Thrown if the either of the required parameters, <paramref
        /// name="element"/> or <paramref name="log"/>, are passed a <c>null</c> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="depth"/> parameter is less than zero.
        /// </exception>
        public static void Dump(this object element, int depth, TextWriter log)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (depth < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(depth), Resources.Error_DepthMustBeNonNegative
                );
            if (log == null) throw new ArgumentNullException(nameof(log));
            ObjectDumper.Write(element, depth, log);
        }

        /// <summary>
        /// Dumps the specified object, a reference to which is in the <paramref
        /// name="element"/> parameter, to the log, followed by a newline character.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to the object whose contents are to be dumped.
        /// </param>
        /// <exception cref="T:ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="element"/>, is
        /// passed a <c>null</c> value.
        /// </exception>
        public static void DumpLines(this object element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            ObjectDumper.WriteLine(element);
        }

        /// <summary>
        /// Dumps the specified object, a reference to which is in the <paramref
        /// name="element"/> parameter, to the log, followed by a newline character.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to the object whose contents are to be dumped.
        /// </param>
        /// <param name="depth">
        /// (Required.) Integer value specifying the depth to which the object
        /// should be dumped.
        /// </param>
        /// <exception cref="T:ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="element"/>, is
        /// passed a <c>null</c> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="depth"/> parameter is less than zero.
        /// </exception>
        public static void DumpLines(this object element, int depth)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (depth < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(depth), Resources.Error_DepthMustBeNonNegative
                );
            ObjectDumper.WriteLine(element, depth);
        }

        /// <summary>
        /// Dumps the specified object, a reference to which is in the <paramref
        /// name="element"/> parameter, to the log.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to the object whose contents are to be dumped.
        /// </param>
        /// <param name="depth">
        /// (Required.) Integer value specifying the depth to which the object
        /// should be dumped.
        /// </param>
        /// <param name="log">
        /// (Required.) Reference to an instance of <see
        /// cref="T:System.IO.TextWriter"/> that is open on the target log file.
        /// </param>
        /// <exception cref="T:ArgumentNullException">
        /// Thrown if the either of the required parameters, <paramref
        /// name="element"/> or <paramref name="log"/>, are passed a <c>null</c> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="depth"/> parameter is less than zero.
        /// </exception>
        public static void DumpLines(this object element, int depth,
            TextWriter log)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (depth < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(depth), Resources.Error_DepthMustBeNonNegative
                );
            if (log == null) throw new ArgumentNullException(nameof(log));
            ObjectDumper.WriteLine(element, depth, log);
        }
    }
}