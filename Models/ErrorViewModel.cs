#region USING STATEMENTS
using System;
#endregion
namespace NETD3202_F2022_InstrumentShop.Models
{
    /// <summary>
    /// Represents a view model for displaying error messages.
    /// </summary>
    public class ErrorViewModel
    {
        #region Properties
        /// <summary>
        /// The unique identifier for the error.
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// A flag indicating whether the RequestId should be displayed.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        #endregion
    }
}
