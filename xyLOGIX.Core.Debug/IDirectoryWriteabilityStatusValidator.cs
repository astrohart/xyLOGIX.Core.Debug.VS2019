namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a validator of
    /// <see cref="T:xyLOGIX.Core.Debug.DirectoryWriteabilityStatus" /> enumeration
    /// values.
    /// </summary>
    /// <remarks>
    /// Specifically, objects that implement this interface ascertain whether
    /// the values of variables fall within the value set that is defined by the
    /// <see cref="T:xyLOGIX.Core.Debug.DirectoryWriteabilityStatus" /> enumeration.
    /// </remarks>
    public interface IDirectoryWriteabilityStatusValidator
    {
        /// <summary>
        /// Determines whether the directory writeability
        /// <paramref name="status" /> value passed is within the value set that is defined
        /// by the <see cref="T:xyLOGIX.Core.Debug.DirectoryWriteabilityStatus" />
        /// enumeration.
        /// </summary>
        /// <param name="status">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.DirectoryWriteabilityStatus" /> values that is
        /// to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the directory writeability
        /// <paramref name="status" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        bool IsValid(DirectoryWriteabilityStatus status);
    }
}