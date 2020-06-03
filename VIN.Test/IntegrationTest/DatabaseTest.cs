using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using VIN.Infra.Data.Context.Db;
using VIN.Test.TestFixtures;
using Xunit;

namespace VIN.Test.IntegrationTest
{
    public class DataBaseFactoryTest : IClassFixture<DependenciesFixture>
    {
        private readonly DependenciesFixture fixture;

        public DataBaseFactoryTest(DependenciesFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CreateSqlServerDatabaseTest()
        {
            //using (var context = new SqlServerContext().SelectContext())
            //{
            //    Assert.NotNull(context);
            //    Assert.NotEmpty(context.ConnectionStringName);

            //    Assert.IsType<SqlConnection>(context.Connection);
            //}
        }

    }
}
