using System;
using Jb.Dapper.Infrastructure;
using Xunit;

namespace Jb.Dapper.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            var mockRepositoty = new MockRepository(new DbSqlConnection(new DbConfiguration("conexionecfd")));
        }
    }
}
