using log4net.Repository.Hierarchy;
using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    public static class HierarchyExtensions
    {
        /// <summary>
        /// Attempts to close all the <c>Appender</c>(s) that are associated with the
        /// specified <paramref name="hierarchy" />.
        /// </summary>
        /// <param name="hierarchy">
        /// (Required.) Reference to an instance of
        /// <see cref="T:log4net.Repository.Hierarchy.Hierarchy" /> that contains the
        /// <c>Appender</c>(s) that are to be closed.
        /// </param>
        /// <returns></returns>
        public static bool CloseAllAppenders(
            [NotLogged] this Hierarchy hierarchy
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "HierarchyExtensions.CloseAllAppenders: Checking whether the 'hierarchy' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, hierarchy, is null. If it is, send an
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (hierarchy == null)
                {
                    // The parameter, 'hierarchy', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "HierarchyExtensions.CloseAllAppenders: *** ERROR *** A null reference was passed for the 'hierarchy' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** HierarchyExtensions.CloseAllAppenders: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "HierarchyExtensions.CloseAllAppenders: *** SUCCESS *** We have been passed a valid object reference for the 'hierarchy' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "HierarchyExtensions.CloseAllAppenders: Checking whether the property, 'hierarchy.Root', has a null reference for a value..."
                );

                // Check to see if the required property, 'hierarchy.Root', has a null reference for a value.
                // If that is the case, then we will write an error message to the Debug output, and then
                // terminate the execution of this method, while returning the default return value.
                if (hierarchy.Root == null)
                {
                    // The property, 'hierarchy.Root', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "HierarchyExtensions.CloseAllAppenders: *** ERROR *** The property, 'hierarchy.Root', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** HierarchyExtensions.CloseAllAppenders: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "HierarchyExtensions.CloseAllAppenders: *** SUCCESS *** The property, 'hierarchy.Root', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "HierarchyExtensions.CloseAllAppenders: Checking whether the property, 'hierarchy.Root.Appenders', has a null reference for a value..."
                );

                // Check to see if the required property, 'hierarchy.Root.Appenders', has a null reference for a value.
                // If that is the case, then we will write an error message to the Debug output, and then
                // terminate the execution of this method, while returning the default return value.
                if (hierarchy.Root.Appenders == null)
                {
                    // The property, 'hierarchy.Root.Appenders', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "HierarchyExtensions.CloseAllAppenders: *** ERROR *** The property, 'hierarchy.Root.Appenders', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** HierarchyExtensions.CloseAllAppenders: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "HierarchyExtensions.CloseAllAppenders: *** SUCCESS *** The property, 'hierarchy.Root.Appenders', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** HierarchyExtensions.CloseAllAppenders: Checking whether the 'hierarchy.Root.Appenders' collection contains greater than zero elements..."
                );

                // Check to see whether the 'hierarchy.Root.Appenders' collection contains greater than
                // zero elements.  Otherwise, write an error message to the Debug output, return
                // the default return value, and then terminate the execution of this method.
                if (hierarchy.Root.Appenders.Count <= 0)
                {
                    // The 'hierarchy.Root.Appenders' collection contains zero elements.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'hierarchy.Root.Appenders' collection contains zero elements.  Stopping..."
                    );

                    /*
                     * Return TRUE so that the caller of this method does not
                     * fall over.
                     */

                    System.Diagnostics.Debug.WriteLine(
                        $"HierarchyExtensions.CloseAllAppenders: Result = {true}"
                    );

                    // stop.
                    return true;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"HierarchyExtensions.CloseAllAppenders: *** SUCCESS *** {hierarchy.Root.Appenders.Count} element(s) were found in the 'hierarchy.Root.Appenders' collection.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "HierarchyExtensions.CloseAllAppenders: *** FYI *** Iterating over all the currently-configured Appender(s), and closing each one of them..."
                );

                foreach (var appender in hierarchy.Root.Appenders.ToArray())
                {
                    System.Diagnostics.Debug.WriteLine(
                        "HierarchyExtensions.CloseAllAppenders: Checking whether the variable 'appender' has a null reference for a value..."
                    );

                    // Check to see if the variable, 'appender', is null. If it is, send an error to
                    // the Debug output and continue to the next loop iteration.
                    if (appender == null)
                    {
                        // the variable appender is required to have a valid object reference.
                        System.Diagnostics.Debug.WriteLine(
                            "HierarchyExtensions.CloseAllAppenders: *** ERROR ***  The 'appender' variable has a null reference.  Skipping to the next loop iteration..."
                        );

                        // continue to the next loop iteration.
                        continue;
                    }

                    // We can use the variable, appender, because it's not set to a null reference.
                    System.Diagnostics.Debug.WriteLine(
                        "HierarchyExtensions.CloseAllAppenders: *** SUCCESS *** The 'appender' variable has a valid object reference for its value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"HierarchyExtensions.CloseAllAppenders: *** FYI *** Closing the Appender, '{appender.Name}'..."
                    );

                    appender.Close();
                }

                /*
                 * If we made it this far with no Exception(s) getting caught, then
                 * assume that the operation(s) succeeded.
                 */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"HierarchyExtensions.CloseAllAppenders: Result = {result}"
            );

            return result;
        }
    }
}