using ACT.Core.Interfaces.Common;
using ACT.Core.Interfaces.DataAccess;
using System.Data.SqlClient;

/// <summary>
/// Execute PROC_JOB_CREATE
/// </summary>
/// <returns>I_QueryResult</returns>


namespace NameSpace.ACT_DriveCache.PROC.JOB.CREATE
{
    public static class Execute
    {
        public static I_Result Proc(Guid? @JobID_VALUE, Guid? @SearchDefinitionID_VALUE, string @JobProcessingPath_VALUE, DateTime? @DateInitiated_VALUE, int? @PathCount_VALUE, int? @FileCount_VALUE, string Conn = "")
        {
            SqlConnection conn = new SqlConnection("");
            using (var DataAccess = CurrentCore<I_DataAccess>.GetCurrent())
            {
                if (Conn == "")
                {
                    DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
                }
                else
                {
                    DataAccess.Open(Conn);
                }
                List<System.Data.IDataParameter> _Params = new List<System.Data.IDataParameter>();
                #region Param Values
                if (@JobID_VALUE == null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("@JobID", DBNull.Value));
                }
                else
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("@JobID", @JobID_VALUE));
                }
                if (@SearchDefinitionID_VALUE == null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("@SearchDefinitionID", DBNull.Value));
                }
                else
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("@SearchDefinitionID", @SearchDefinitionID_VALUE));
                }
                if (@JobProcessingPath_VALUE == null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("@JobProcessingPath", DBNull.Value));
                }
                else
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("@JobProcessingPath", @JobProcessingPath_VALUE));
                }
                if (@DateInitiated_VALUE == null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("@DateInitiated", DBNull.Value));
                }
                else
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("@DateInitiated", @DateInitiated_VALUE));
                }
                if (@PathCount_VALUE == null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("@PathCount", DBNull.Value));
                }
                else
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("@PathCount", @PathCount_VALUE));
                }
                if (@FileCount_VALUE == null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("@FileCount", DBNull.Value));
                }
                else
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("@FileCount", @FileCount_VALUE));
                }
                #endregion
                var _Result = DataAccess.RunCommand("[dbo].PROC_JOB_CREATE", _Params, true, System.Data.CommandType.StoredProcedure);
                return _Result;
            }
        }
    }

}
