using log4net.Repository.Hierarchy;
using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    public static class HierarchyExtensions
    {
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
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = false;
            }

            return result;
        }
    }
}