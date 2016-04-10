using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystemDatabase.BaseClasses;

namespace ContentManagementSystemDatabase
{
    [Table( "[Domain]" )]
    public partial class Domain : EntityBase
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int DomainId { get; set; }

        public string DomainUrl { get; set; }

        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public Guid UploadFolder { get; set; }

        public string Name { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
