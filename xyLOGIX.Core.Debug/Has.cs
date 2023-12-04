using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Linq;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> methods to determine whether a console window
    /// is
    /// present.
    /// </summary>
    [ExplicitlySynchronized]
    public static class Has
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.Has" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Has() { }

        /// <summary>
        /// Gets or sets a value that is initialized with a <see cref="T:System.Boolean" />
        /// that indicates whether the calling application is a Windows GUI app or a
        /// console app.
        /// </summary>
        /// <remarks>
        /// We use this property to avoid re-determining the nature of the current app if
        /// the <see cref="M:xyLOGIX.Core.Debug.Has.WindowsGui" /> method is called more
        /// than once.
        /// </remarks>
        private static bool? IsWindowsGUI { get; set; }

        /// <summary>
        /// Determines whether the application is currently running in a console
        /// window.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if the application is running in a console
        /// window; <see langword="false" /> otherwise.
        /// </returns>
        /// <remarks>
        /// This method first tries to get the value of the
        /// <see cref="P:System.Console.WindowHeight" /> property.  If this throws an
        /// exception, we return <see langword="false" /> since we aren't running in a
        /// console window.
        /// <para />
        /// If that check passes, then we return the negation of the return value of the
        /// <see cref="M:xyLOGIX.Core.Debug.Has.WindowsGui" /> method.
        /// <para />
        /// This algorithm assures us we get an accurate response, i.e.,
        /// <see langword="false" />, from this method if the caller is not running in a
        /// console and is NOT GUI-based; i.e., it is like a console app but it is set to
        /// <c>Windows Application</c> application type in the <b>Project Properties</b>
        /// window in Visual Studio, but it never creates a window (at least, not using WPF
        /// or WinForms; this method cannot detect native Win32 P/Invoke calls to create a
        /// main window).
        /// </remarks>
        public static bool ConsoleWindow()
        {
            bool result;

            try
            {
                _ = Console.WindowHeight;

                result = !WindowsGui();
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Determines whether the calling assembly (or the entry assembly, if
        /// <paramref name="useEntryAssembly" /> is set to <see langword="true" />, which
        /// it is not by default) is a Windows GUI application written with either WPF or
        /// WinForms.
        /// </summary>
        /// <param name="useEntryAssembly">
        /// (Optional.) Default is <see langword="false" />
        /// .  If <see langword="true" />, uses the entry-point assembly of the application
        /// to make its determination. Setting this parameter to <see langword="false" />
        /// means the calling assembly is used instead.
        /// </param>
        /// <returns>
        /// A value that indicates whether the calling assembly (or the entry
        /// assembly, if <paramref name="useEntryAssembly" /> is set to
        /// <see langword="true" />, which it is not by default) is a Windows GUI
        /// application written with either WPF or WinForms.
        /// </returns>
        /// <remarks>
        /// This method works by assessing whether the entry or calling assembly,
        /// per the value of the <paramref name="useEntryAssembly" /> parameter's argument,
        /// references either WPF or WinForm system framework assemblies.
        /// </remarks>
        public static bool WindowsGui(bool useEntryAssembly = false)
        {
            if (IsWindowsGUI.HasValue)
                return IsWindowsGUI.Value;

            IsWindowsGUI = false;

            try
            {
                var assemblyToCheck = useEntryAssembly
                    ? Assembly.GetEntryAssembly()
                    : Assembly.GetCallingAssembly();

                if (assemblyToCheck == null)
                    return IsWindowsGUI.Value;

                var wpfAssemblies = new[]
                {
                    "PresentationFramework", "PresentationCore",
                    "WindowsBase"
                };
                var winFormsAssemblies = new[] { "System.Windows.Forms" };

                var referencedAssemblies =
                    assemblyToCheck.GetReferencedAssemblies();
                if (referencedAssemblies == null || !referencedAssemblies.Any())
                    return IsWindowsGUI.Value;

                foreach (var assemblyName in referencedAssemblies)
                {
                    if (assemblyName == null ||
                        string.IsNullOrWhiteSpace(assemblyName.Name))
                        return IsWindowsGUI.Value;

                    if (wpfAssemblies.Contains(assemblyName.Name))
                    {
                        IsWindowsGUI = true; // WPF
                        break;
                    }

                    if (!winFormsAssemblies.Contains(assemblyName.Name))
                        continue;

                    IsWindowsGUI = true; // WinForms
                    break;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                IsWindowsGUI = false;
            }

            return IsWindowsGUI.Value;
        }
    }
}