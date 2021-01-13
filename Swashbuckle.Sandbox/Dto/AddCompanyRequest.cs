using Swashbuckle.Model;

namespace Swashbuckle.Sandbox.Dto
{
    /// <summary>
    /// Defines the input for adding a company to an existing scenario.
    /// </summary>
    public class AddCompanyRequest
    {
        /// <summary>
        /// The company to add.
        /// </summary>
        public Company Company { get; set; }
    }
}