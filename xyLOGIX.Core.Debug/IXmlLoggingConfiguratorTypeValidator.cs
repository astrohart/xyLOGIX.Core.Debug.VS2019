namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a validator of
    /// <see cref="T:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType" /> enumeration
    /// values.
    /// </summary>
    /// <remarks>
    /// Specifically, objects that implement this interface ascertain whether
    /// the values of variables fall within the value set that is defined by the
    /// <see cref="T:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType" /> enumeration.
    /// </remarks>
    public interface IXmlLoggingConfiguratorTypeValidator
    {
        /// <summary>
        /// Determines whether the XML logging configurator
        /// <paramref name="type" /> value passed is within the value set that is defined
        /// by the <see cref="T:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType" />
        /// enumeration.
        /// </summary>
        /// <param name="type">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType" /> values that is
        /// to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the XML logging configurator
        /// <paramref name="type" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        bool IsValid(XmlLoggingConfiguratorType type);
    }
}