using PostSharp.Patterns.Diagnostics;
using System;
using System.IO;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Methods to delete files and folders. </summary>
    internal static class Delete
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.Delete" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Delete() { }

        /// <summary>
        /// Deletes the file having the specified <paramref name="pathname" />, if
        /// it exists.
        /// </summary>
        /// <param name="pathname">
        /// (Required.) A <see cref="T:System.String" /> that
        /// contains the fully-qualified pathname of the file that is to be deleted.
        /// </param>
        /// <remarks>
        /// If the <paramref name="pathname" /> parameter is blank, the
        /// <see cref="F:System.String.Empty" /> value, or <see langword="null" />, then
        /// this method returns <see langword="false" />.
        /// <para />
        /// This method also returns <see langword="false" /> if the file having the specified
        /// <paramref name="pathname" /> does not already exist on the file system.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the file having the specified
        /// <paramref name="pathname" /> was found on the file system and successfully
        /// deleted; <see langword="false" /> otherwise.
        /// </returns>
        internal static bool FileIfExists([NotLogged] string pathname)
        {
            var result = false;

            try
            {
                if (string.IsNullOrWhiteSpace(pathname)) return result;
                if (!File.Exists(pathname)) return result;

                File.Delete(pathname);

                result = !File.Exists(pathname);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = false;
            }

            return result;
        }

        /// <summary> Deletes a log file having the specified <paramref name="pathname" />. </summary>
        /// <param name="pathname">
        /// (Required.) String containing the fully-qualified pathname
        /// of the file that is to be deleted.
        /// </param>
        /// <remarks>
        /// If the <paramref name="pathname" /> parameter is blank or
        /// <see langword="null" />, then this method does nothing.
        /// <para />
        /// This method also takes no action if the file having the specified
        /// <paramref name="pathname" /> does not already exist on the file system.
        /// </remarks>
        internal static void LogFile(string pathname)
        {
            if (string.IsNullOrWhiteSpace(pathname))
                return;

            try
            {
                if (File.Exists(pathname))
                    File.Delete(pathname);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }
        }
    }
}