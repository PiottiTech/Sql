using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PiottiTech.Sql
{
    public class SqlDatabase
    {
        #region Sql Object Methods

        public static SqlConnection GetConnection(string connectionString)
        {
            SqlConnection sqlConn = new SqlConnection(connectionString);
            return sqlConn;
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection sqlConn = GetConnection(DefaultConnectionString());
            return sqlConn;
        }

        public static SqlCommand GetCommand(string storedProc, string connectionString)
        {
            SqlCommand sqlCommand = new SqlCommand(storedProc, GetConnection(connectionString));
            return sqlCommand;
        }

        public static SqlCommand GetCommand(string storedProc)
        {
            SqlCommand sqlCommand = GetCommand(storedProc, DefaultConnectionString());
            return sqlCommand;
        }

        public static SqlCommand GetStoredProcCommand(string storedProc, List<SqlParameter> commandParameters, string connectionString)
        {
            SqlCommand sqlCommand = GetCommand(storedProc, connectionString);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.AttachParameters(commandParameters);
            return sqlCommand;
        }

        public static SqlCommand GetStoredProcCommand(string storedProc, SqlParameter commandParameter, string connectionString)
        {
            SqlCommand sqlCommand = GetCommand(storedProc, connectionString);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(commandParameter);
            return sqlCommand;
        }

        public static SqlCommand GetStoredProcCommand(string storedProc, string connectionString)
        {
            SqlCommand sqlCommand = GetCommand(storedProc, connectionString);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            return sqlCommand;
        }

        public static SqlCommand GetStoredProcCommand(string storedProc, List<SqlParameter> commandParameters)
        {
            SqlCommand sqlCommand = GetCommand(storedProc);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.AttachParameters(commandParameters);
            return sqlCommand;
        }

        public static SqlCommand GetStoredProcCommand(string storedProc, SqlParameter commandParameter)
        {
            SqlCommand sqlCommand = GetCommand(storedProc);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(commandParameter);
            return sqlCommand;
        }

        public static SqlCommand GetStoredProcCommand(string storedProc)
        {
            SqlCommand sqlCommand = GetCommand(storedProc);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            return sqlCommand;
        }

        #endregion Sql Object Methods

        #region Connection String Methods

        public static string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        private static string DefaultConnectionString()
        {
            return GetConnectionString("SqlDatabase");
        }

        #endregion Connection String Methods

        #region ExecuteScalar

        public static object ExecuteScalar(string storedProc, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, connectionString);
            return ExecuteScalar(sqlCommand);
        }

        public static object ExecuteScalar(string storedProc, SqlParameter commandParameter, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameter, connectionString);
            return ExecuteScalar(sqlCommand);
        }

        public static object ExecuteScalar(string storedProc, List<SqlParameter> commandParameters, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameters, connectionString);
            return ExecuteScalar(sqlCommand);
        }

        public static object ExecuteScalar(string storedProc)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc);
            return ExecuteScalar(sqlCommand);
        }

        public static object ExecuteScalar(string storedProc, SqlParameter commandParameter)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameter);
            return ExecuteScalar(sqlCommand);
        }

        public static object ExecuteScalar(string storedProc, List<SqlParameter> commandParameters)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameters);
            return ExecuteScalar(sqlCommand);
        }

        private static object ExecuteScalar(SqlCommand sqlCommand)
        {
            Object scalarResult;
            sqlCommand.Connection.Open();
            scalarResult = sqlCommand.ExecuteScalar();
            sqlCommand.Connection.Close();
            return scalarResult;
        }

        #endregion ExecuteScalar

        #region ExecuteNonquery

        public static void ExecuteNonquery(string storedProc, SqlParameter commandParameter, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameter, connectionString);
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
        }

        public static void ExecuteNonquery(string storedProc, SqlParameter commandParameter)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameter);
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
        }

        public static void ExecuteNonquery(string storedProc, List<SqlParameter> commandParameters, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameters, connectionString);
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
        }

        public static void ExecuteNonquery(string storedProc, List<SqlParameter> commandParameters)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameters);
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
        }

        #endregion ExecuteNonquery

        #region ExecuteReader

        public static SqlDataReader ExecuteReader(string storedProc, List<SqlParameter> commandParameters, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameters, connectionString);
            sqlCommand.Connection.Open();
            return sqlCommand.ExecuteReader();
        }

        public static SqlDataReader ExecuteReader(string storedProc, SqlParameter commandParameter, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameter, connectionString);
            sqlCommand.Connection.Open();
            return sqlCommand.ExecuteReader();
        }

        public static SqlDataReader ExecuteReader(string storedProc, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, connectionString);
            sqlCommand.Connection.Open();
            return sqlCommand.ExecuteReader();
        }

        public static SqlDataReader ExecuteReader(string storedProc, List<SqlParameter> commandParameters)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameters);
            sqlCommand.Connection.Open();
            return sqlCommand.ExecuteReader();
        }

        public static SqlDataReader ExecuteReader(string storedProc, SqlParameter commandParameter)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameter);
            sqlCommand.Connection.Open();
            return sqlCommand.ExecuteReader();
        }

        public static SqlDataReader ExecuteReader(string storedProc)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc);
            sqlCommand.Connection.Open();
            return sqlCommand.ExecuteReader();
        }

        #endregion ExecuteReader

        #region Fill DataSet methods

        public static void FillDataSet(string storedProc, List<SqlParameter> commandParameters, DataSet dataSet, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameters, connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataSet);
            sqlCommand.Connection.Close();
        }

        public static void FillDataSet(string storedProc, SqlParameter commandParameter, DataSet dataSet, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameter, connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataSet);
            sqlCommand.Connection.Close();
        }

        public static void FillDataSet(string storedProc, DataSet dataSet, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataSet);
            sqlCommand.Connection.Close();
        }

        public static void FillDataSet(string storedProc, List<SqlParameter> commandParameters, DataSet dataSet)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameters);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataSet);
            sqlCommand.Connection.Close();
        }

        public static void FillDataSet(string storedProc, SqlParameter commandParameter, DataSet dataSet)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameter);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataSet);
            sqlCommand.Connection.Close();
        }

        public static void FillDataSet(string storedProc, DataSet dataSet)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataSet);
            sqlCommand.Connection.Close();
        }

        #endregion Fill DataSet methods

        #region Fill DataTable methods

        public static void FillDataTable(string storedProc, List<SqlParameter> commandParameters, DataTable dataTable, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameters, connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);
            sqlCommand.Connection.Close();
        }

        public static void FillDataTable(string storedProc, SqlParameter commandParameter, DataTable dataTable, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameter, connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);
            sqlCommand.Connection.Close();
        }

        public static void FillDataTable(string storedProc, DataTable dataTable, string connectionString)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);
            sqlCommand.Connection.Close();
        }

        public static void FillDataTable(string storedProc, List<SqlParameter> commandParameters, DataTable dataTable)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameters);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);
            sqlCommand.Connection.Close();
        }

        public static void FillDataTable(string storedProc, SqlParameter commandParameter, DataTable dataTable)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc, commandParameter);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);
            sqlCommand.Connection.Close();
        }

        public static void FillDataTable(string storedProc, DataTable dataTable)
        {
            SqlCommand sqlCommand = GetStoredProcCommand(storedProc);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);
            sqlCommand.Connection.Close();
        }

        #endregion Fill DataTable methods

        #region Get DataTable methods

        public static DataTable GetDataTable(string storedProc, List<SqlParameter> commandParameters, string connectionString)
        {
            DataTable dtResults = new DataTable();
            FillDataTable(storedProc, commandParameters, dtResults, connectionString);
            return dtResults;
        }

        public static DataTable GetDataTable(string storedProc, SqlParameter commandParameter, string connectionString)
        {
            DataTable dtResults = new DataTable();
            FillDataTable(storedProc, commandParameter, dtResults, connectionString);
            return dtResults;
        }

        public static DataTable GetDataTable(string storedProc, string connectionString)
        {
            DataTable dtResults = new DataTable();
            FillDataTable(storedProc, dtResults, connectionString);
            return dtResults;
        }

        public static DataTable GetDataTable(string storedProc, List<SqlParameter> commandParameters)
        {
            DataTable dtResults = new DataTable();
            FillDataTable(storedProc, commandParameters, dtResults);
            return dtResults;
        }

        public static DataTable GetDataTable(string storedProc, SqlParameter commandParameter)
        {
            DataTable dtResults = new DataTable();
            FillDataTable(storedProc, commandParameter, dtResults);
            return dtResults;
        }

        public static DataTable GetDataTable(string storedProc)
        {
            DataTable dtResults = new DataTable();
            FillDataTable(storedProc, dtResults);
            return dtResults;
        }

        #endregion Get DataTable methods

        #region Get DataSet methods

        public static DataSet GetDataSet(string storedProc, List<SqlParameter> commandParameters, string connectionString)
        {
            DataSet dsResults = new DataSet();
            FillDataSet(storedProc, commandParameters, dsResults, connectionString);
            return dsResults;
        }

        public static DataSet GetDataSet(string storedProc, SqlParameter commandParameter, string connectionString)
        {
            DataSet dsResults = new DataSet();
            FillDataSet(storedProc, commandParameter, dsResults, connectionString);
            return dsResults;
        }

        public static DataSet GetDataSet(string storedProc, string connectionString)
        {
            DataSet dsResults = new DataSet();
            FillDataSet(storedProc, dsResults, connectionString);
            return dsResults;
        }

        public static DataSet GetDataSet(string storedProc, List<SqlParameter> commandParameters)
        {
            DataSet dsResults = new DataSet();
            FillDataSet(storedProc, commandParameters, dsResults);
            return dsResults;
        }

        public static DataSet GetDataSet(string storedProc, SqlParameter commandParameter)
        {
            DataSet dsResults = new DataSet();
            FillDataSet(storedProc, commandParameter, dsResults);
            return dsResults;
        }

        public static DataSet GetDataSet(string storedProc)
        {
            DataSet dsResults = new DataSet();
            FillDataSet(storedProc, dsResults);
            return dsResults;
        }

        #endregion Get DataSet methods
    }

    internal static class SqlDatabaseExtensions
    {
        public static void AttachParameters(this SqlCommand command, List<SqlParameter> commandParameters)
        {
            command.Parameters.AddRange(commandParameters.ToArray());
        }
    }
}