﻿//-----------------------------------------------------------------------------
// <copyright file="SqlQuery.TryExecuteXmlReader.cs" company="genuine">
//     Copyright (c) J.Baltikauskas. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------
//  Author:     J.Baltikauskas
//  Date:       04/14/2010
//-----------------------------------------------------------------------------
namespace Vodca
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Xml;
    using System.Xml.Linq;

    /// <content>
    ///     Contains Sql operation where return result is XmlReader or XElement
    ///  </content>
    /// <example>View code: <br />
    /// <code source="..\Vodca.Core\Vodca.SqlQuery\SqlQuery.TryExecuteXmlReader.cs" title="SqlQuery.TryExecuteXmlReader.cs" lang="C#" />
    /// </example>
    public static partial class SqlQuery
    {
        /// <summary>
        ///     Select all records from the Sql table. NO caching involved.
        /// </summary>  
        /// <param name="type">Specifies how a command string is interpreted. Command Type (CommandType.StoredProcedure OR CommandType.Text )</param>
        /// <param name="sql">The name of a stored procedure or an SQL text command</param>
        /// <param name="parameters">Represents parameters to a SqlCommand</param>
        /// <returns>
        ///     The returns XmlReader from Sql.
        /// </returns>
        /// <example>View code: <br />
        /// <code lang="xml" title="web.config">
        /// <![CDATA[
        /// /* Add connection string named "SqlQueryConnection" to the web.config file in order use Data Access Library! */
        /// <connectionStrings>
        ///     <remove name="LocalSqlServer"/>
        ///     <add name="SqlQueryConnection" connectionString="Data Source=SERVER_NAME;Initial Catalog=DATABASE_NAME;Persist Security Info=True;User ID=USER_NAME;Password=USER_PASSWORD" providerName="System.Data.SqlClient"/>
        /// </connectionStrings> 
        /// ]]>
        /// </code>
        /// <code title="C# File" lang="C#">
        /// ASP.NET Page
        /// {
        ///     const string Sql = @"
        ///                         SELECT 
        ///                              [ProductID]
        ///                             ,[ProductName]
        ///                         FROM 
        ///                             [Current Product List]
        ///                             FOR XML PATH('Product'), ELEMENTS, ROOT('Products')
        ///                     ";
        ///     // Get Data              
        ///     var reader = SqlQuery.TryExecuteXmlReader(CommandType.Text, Sql);
        ///     // Do something 
        /// }
        /// </code>
        /// <code source="..\Vodca.Core\Vodca.SqlQuery\SqlQuery.TryExecuteXmlReader.cs" title="SqlQuery.TryExecuteXmlReader.cs" lang="C#" />
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "User must use Sql Stored procedure or sql parameterized command")]
        public static XmlReader TryExecuteXmlReader(CommandType type, string sql, params SqlParameter[] parameters)
        {
            try
            {
                return ExecuteXmlReader(type, sql, parameters);
            }
            catch (SqlException sqlex)
            {
                VLog.LogException(sqlex);
            }
            catch (Exception ex)
            {
                VLog.LogException(ex);
            }

            return null;
        }

        /// <summary>
        ///     Select all records from the Sql table. NO caching involved.
        /// </summary>  
        /// <param name="type">Specifies how a command string is interpreted. Command Type (CommandType.StoredProcedure OR CommandType.Text )</param>
        /// <param name="sql">The name of a stored procedure or an SQL text command</param>
        /// <param name="parameters">Represents parameters to a SqlCommand</param>
        /// <returns>
        ///     The returns XElement from Sql.
        /// </returns>
        /// <example>View code: <br />
        /// <code lang="xml" title="web.config">
        /// <![CDATA[
        /// /* Add connection string named "SqlQueryConnection" to the web.config file in order use Data Access Library! */
        /// <connectionStrings>
        ///     <remove name="LocalSqlServer"/>
        ///     <add name="SqlQueryConnection" connectionString="Data Source=SERVER_NAME;Initial Catalog=DATABASE_NAME;Persist Security Info=True;User ID=USER_NAME;Password=USER_PASSWORD" providerName="System.Data.SqlClient"/>
        /// </connectionStrings> 
        /// ]]>
        /// </code>
        /// <code title="C# File" lang="C#">
        /// ASP.NET Page
        /// {
        ///     const string Sql = @"
        ///                         SELECT 
        ///                              [ProductID]
        ///                             ,[ProductName]
        ///                         FROM 
        ///                             [Current Product List]
        ///                             FOR XML PATH('Product'), ELEMENTS, ROOT('Products')
        ///                     ";
        ///     // Get Data              
        ///     var xelement = SqlQuery.ExecuteXElementReader(CommandType.Text, Sql);
        ///     // Do something 
        /// }
        /// </code>
        /// <code source="..\Vodca.Core\Vodca.SqlQuery\SqlQuery.TryExecuteXmlReader.cs" title="SqlQuery.TryExecuteXmlReader.cs" lang="C#" />
        /// </example>
        public static XNode TryExecuteXElementReader(CommandType type, string sql, params SqlParameter[] parameters)
        {
            try
            {
                return ExecuteXElementReader(type, sql, parameters);
            }
            catch (SqlException sqlex)
            {
                VLog.LogException(sqlex);
            }
            catch (Exception ex)
            {
                VLog.LogException(ex);
            }

            return null;
        }
    }
}
