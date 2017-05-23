using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Text.RegularExpressions;

namespace ContentManagementSystemDatabase.Configuration
{
    public class CMSFormatter : DatabaseLogFormatter
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        private static readonly int COMMAND_INDENT = 40;

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public CMSFormatter( DbContext context, Action<string> writeAction ) : base( context, writeAction )
        {
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="command"></param>
        /// <param name="interceptionContext"></param>
        public override void LogCommand<TResult>( DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext )
        {

            if ( this.Context == null ) return;

            var test = this;
            var commandText = command.CommandText.Replace( Environment.NewLine, "" );
            var regex = new Regex( @" FROM[ ]+\[dbo\].\[(?<table>[\w_]+)\]" );
            var groups = regex.Match( commandText ).Groups;
            var table = groups[ "table" ];

            if ( table != null && table.Success )
            {
                var prefix = string.Format( "-> {0} {1} ", this.Context.GetType().Name, this.Stopwatch.Elapsed.TotalSeconds.ToString( "N3" ) );
                this.Write( ( prefix + string.Format( "\"{0}\"", groups[ "table" ].Value ) ).PadRight( COMMAND_INDENT ) + commandText );
            }

            else
            {
                this.Write( "-> ".PadRight( COMMAND_INDENT ) + commandText );
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="interceptionContext"></param>
        public override void Opened( DbConnection connection, DbConnectionInterceptionContext interceptionContext )
        {
            //base.Opened( connection, interceptionContext );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="interceptionContext"></param>
        public override void Closed( DbConnection connection, DbConnectionInterceptionContext interceptionContext )
        {
            //base.Closed( connection, interceptionContext );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="interceptionContext"></param>
        public override void BeganTransaction( DbConnection connection, BeginTransactionInterceptionContext interceptionContext )
        {
            //base.BeganTransaction( connection, interceptionContext );
        }

        public override void Disposing( DbTransaction transaction, DbTransactionInterceptionContext interceptionContext )
        {
            //base.Disposing( transaction, interceptionContext );
        }

        public override void Committed( DbTransaction transaction, DbTransactionInterceptionContext interceptionContext )
        {
            //var prefix = string.Format( "-> {0} {1} ", this.Context.GetType().Name, this.Stopwatch.Elapsed.TotalSeconds.ToString( "N3" ) );
            //this.Write( prefix.PadRight( COMMAND_INDENT ) + "Committed Transaction" );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="command"></param>
        /// <param name="interceptionContext"></param>
        public override void LogResult<TResult>( DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext )
        {

        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
