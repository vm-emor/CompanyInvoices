using System.Data;
using CompanyInvoices.Core.Interfaces;
using CompanyInvoices.Core.Models;
using Dapper;

namespace CompanyInvoices.Data.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly DbConnectionFactory _factory;

    public CompanyRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<CompanyView>> GetAllAsync()
    {
        using var conn = _factory.Create();
        return await conn.QueryAsync<CompanyView>("sp_Company_GetAll", commandType: CommandType.StoredProcedure);
    }

    public async Task<CompanyView?> GetByIdAsync(int id)
    {
        using var conn = _factory.Create();
        return await conn.QuerySingleOrDefaultAsync<CompanyView>("sp_Company_GetById", new { Id = id }, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        using var conn = _factory.Create();
        var count = await conn.ExecuteScalarAsync<int>("SELECT COUNT(1) FROM Companies WHERE Id = @Id", new { Id = id });
        return count > 0;
    }

    public async Task<int> InsertAsync(CompanyEdit company)
    {
        using var conn = _factory.Create();
        return await conn.QuerySingleAsync<int>("sp_Company_Insert", new
        {
            company.Name,
            company.TaxNumber,
            company.Address,
            company.Email
        }, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateAsync(int id, CompanyEdit company)
    {
        using var conn = _factory.Create();
        await conn.ExecuteAsync("sp_Company_Update", new
        {
            Id = id,
            company.Name,
            company.TaxNumber,
            company.Address,
            company.Email
        }, commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteAsync(int id)
    {
        using var conn = _factory.Create();
        await conn.ExecuteAsync("sp_Company_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
    }
}
