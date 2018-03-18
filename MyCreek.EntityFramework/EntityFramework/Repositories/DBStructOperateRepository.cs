using MyCreek.Modules.Repository;
using MyCreek.Modules.SysAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dapper.Repositories;
using Abp.Data;
using Dapper;
using Abp.Domain.Entities;
using System.Data;
using Abp.EntityFramework;
using System.Data.Common;
using System.Data.SqlClient;

namespace MyCreek.EntityFramework.Repositories
{


    public class DBStructOperateRepository : MyCreekRepositoryBase<CustomFeatureCoreStruct>, IDBStructOperateRepository
    {

        public DBStructOperateRepository(IDbContextProvider<MyCreekDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
        public async Task CreateDbStruct(CustomFeatureCoreStruct customFeatureCoreStruct)
        {
            //1.判断表是否存在
            var isExist = await IsExist(customFeatureCoreStruct.MenuItemDefine.DBTable);
            if (isExist)
            {

            }
            else
            {
                await CreateTable(customFeatureCoreStruct);
            }
            //2.存在就把现在的表结果和已经有的表结构进行对比，不一致的就放入列表，构造修改的SQL
            throw new NotImplementedException();
        }

        public async Task<bool> IsExist(string tableName)
        {
            try
            {
                var data = await Task.Factory.StartNew<bool>(() =>
                {

                    var sql = "select Total=COUNT(1) from sys.objects where name = @name";
                    var args = new DbParameter[] {
                         new SqlParameter {ParameterName = "name", Value = tableName}
                     };

                    var context = GetDbContext();
                    using (context)
                    {
                        var tmp = context.Database.SqlQuery<int>(sql, args).SingleOrDefault();
                        return tmp > 0;
                    }

                });


                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        public async Task CreateTable(CustomFeatureCoreStruct customFeatureCoreStruct)
        {
            var tableName = customFeatureCoreStruct.MenuItemDefine.DBTable;

            var sql1 = $"CREATE TABLE [dbo].[{tableName}]([Id] [INT] IDENTITY(1,1) NOT NULL,";
            var sql2 = $@"CONSTRAINT [PK_dbo.{tableName}] PRIMARY KEY CLUSTERED 
                        ([Id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                        ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]";

            var strList = new StringBuilder();
            foreach (var item in customFeatureCoreStruct.Fields)
            {
                //item.ColName
                var tmp = item.IsNull ? "NULL" : " NOT NULL";
                var str = $"[{item.ColName}] [NVARCHAR](MAX) {tmp},";
                strList.AppendLine(str);
            }


            var sqlCommand = sql1 + strList.ToString() + sql2;

            var context = GetDbContext();
            using (context)
            {
                var x = await context.Database.ExecuteSqlCommandAsync(sqlCommand);
                Console.WriteLine(x);
            }
        }

    }
}
