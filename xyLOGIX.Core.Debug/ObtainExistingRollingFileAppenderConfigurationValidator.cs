using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    public class
        ObtainExistingRollingFileAppenderConfigurationValidator :
        RollingFileAppenderConfigurationValidatorBase
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static ObtainExistingRollingFileAppenderConfigurationValidator() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected ObtainExistingRollingFileAppenderConfigurationValidator() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfigurationValidator" />
        /// interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.AppenderRetrievalMode.ObtainExisting" /> use
        /// case.
        /// </summary>
        public static IRollingFileAppenderConfigurationValidator Instance
        {
            [DebuggerStepThrough] get;
        } = new ObtainExistingRollingFileAppenderConfigurationValidator();

        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" />
        /// enumeration value that identifies how this
        /// <c>Rolling File Appender Configuration Validator</c> operates.
        /// </summary>
        public override AppenderRetrievalMode Mode
        {
            [DebuggerStepThrough] get;
        } = AppenderRetrievalMode.ObtainExisting;
    }
}