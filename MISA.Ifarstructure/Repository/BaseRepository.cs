using Dapper;
using MISA.Core.Interfaces.Infrastructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Ifarstructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        #region Field
        string _connectionString = "" +
            "Host = 47.241.69.179;" +
            "Port = 3306;" +
            "Database = MF_FS_CukCuk;" +
            "User Id = nvmanh;" +
            "Password = 12345678";
        protected IDbConnection DbConnection;
        protected string ClassName = string.Empty;
        #endregion

        #region Constructor
        public BaseRepository()
        {
            DbConnection = new MySqlConnection(_connectionString);
            ClassName = typeof(MISAEntity).Name;
        }
        #endregion

        #region Methods
        public List<MISAEntity> GetAll()
        {
            var sqlCommand = $"Select * from {ClassName}";
            var entitis = DbConnection.Query<MISAEntity>(sqlCommand).ToList();
            return entitis;
        }

        public MISAEntity GetById(Guid entityId)
        {
            // câu leenhk truy vấn
            var sqlCommand = $"Select * from {ClassName} where {ClassName}Id = @{ClassName}Id";

            // tạo dynamicparam
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add($"@{ClassName}Id", entityId);

            // thực hiện truy vấn
            var entity = DbConnection.Query<MISAEntity>(sqlCommand, dynamic).FirstOrDefault();

            // trả về kết quả
            return entity;
        }

        public int Insert(MISAEntity entity)
        {
            // tạo dynamic param
            DynamicParameters dynamic = new DynamicParameters();

            var sqlCommandField = string.Empty;
            var sqlCommandValue = string.Empty;

            var properties = entity.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var propName = prop.Name;

                var propValue = prop.GetValue(entity);
                if (propName == $"{ClassName}Id")
                {
                    propValue = Guid.NewGuid();
                }

                sqlCommandField += $"{propName},";
                sqlCommandValue += $"@{propName},";

                dynamic.Add($"@{propName}", propValue);
            }

            // tạo câu lệnh truy vấn (thêm 1 bản ghi vào csdl)
            var sqlQuery = $"INSERT INTO {ClassName}({sqlCommandField.Substring(0, sqlCommandField.Length - 1)})" +
                $"VALUES({sqlCommandValue.Substring(0, sqlCommandValue.Length - 1)})";

            // thực hiện truy vấn và trả về kết quả
            var rowAffect = DbConnection.Execute(sqlQuery, param: dynamic);
            return rowAffect;
        }

        public int Update(MISAEntity entity, Guid entityId)
        {
            // tạo dynamic param
            DynamicParameters dynamic = new DynamicParameters();
            var sqlCommand = string.Empty;

            var properties = entity.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var propName = prop.Name;

                if (propName != $"{ClassName}Id")
                {
                    var propValue = prop.GetValue(entity);

                    sqlCommand += $"{propName}=@{propName},";

                    dynamic.Add($"@{propName}", propValue);
                }
            }
            
            // build câu lệnh truy vấn
            var sqlQuery = $"Update {ClassName} SET " + sqlCommand.Substring(0, sqlCommand.Length - 1) + $" WHERE {ClassName}Id = '{entityId.ToString()}' ";

            //thực thi truy vấn và trả về kết quả
            var res = DbConnection.Execute(sqlQuery, param: dynamic);
            return res;
        }

        public int Delete(Guid entityId)
        {
            // tạo câu lệnh truy vấn (xóa 1 bản ghi)
            var sqlCommand = $"Delete from {ClassName} where {ClassName}Id = @{ClassName}Id";

            // tạo dynamic param
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add($"@{ClassName}Id", entityId);

            // thực thi truy vấn vả trả về kết quả
            var rowAffects = DbConnection.Execute(sqlCommand, dynamic);
            return rowAffects;
        }

        #endregion
    }
}
