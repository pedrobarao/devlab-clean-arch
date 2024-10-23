using System.Data;
using Dapper;

namespace Lab.Customers.Infra.Extensions;

public class DapperDateOnlyTypeExtension : SqlMapper.TypeHandler<DateOnly>
{
    public override DateOnly Parse(object value)
    {
        return DateOnly.FromDateTime((DateTime)value);
    }

    public override void SetValue(IDbDataParameter parameter, DateOnly value)
    {
        parameter.Value = value.ToDateTime(new TimeOnly(0, 0));
        parameter.DbType = DbType.Date;
    }
}