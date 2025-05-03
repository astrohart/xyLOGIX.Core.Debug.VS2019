namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a validator of
    /// <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" /> enumeration
    /// values.
    /// </summary>
    /// <remarks>
    /// Specifically, objects that implement this interface ascertain whether
    /// the values of variables fall within the value set that is defined by the
    /// <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" /> enumeration.
    /// </remarks>
    public interface IRootLoggerProvisioningStrategyValidator
    {
        /// <summary>
        /// Determines whether the root-logger provisioning
        /// <paramref name="strategy" /> value passed is within the value set that is
        /// defined by the
        /// <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" /> enumeration.
        /// </summary>
        /// <param name="strategy">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" /> values that
        /// is to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the root-logger provisioning
        /// <paramref name="strategy" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        bool IsValid(RootLoggerProvisioningStrategy strategy);
    }
}