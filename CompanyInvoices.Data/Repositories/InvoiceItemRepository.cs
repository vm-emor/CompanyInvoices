using System.Data;
using CompanyInvoices.Abstractions.Interfaces;
using CompanyInvoices.Contracts.Models;
using Dapper;

namespace CompanyInvoices.Data.Repositories;

public class InvoiceItemRepository : IInvoiceItemRepository
{
    private readonly DbConnectionFactory _factory;

    public InvoiceItemRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<InvoiceItemView>> GetByInvoiceAsync(int invoiceId)
    {
        using var conn = _factory.Create();
        return await conn.QueryAsync<InvoiceItemView>("sp_InvoiceItem_GetByInvoice", new { InvoiceId = invoiceId }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertAsync(int invoiceId, InvoiceItemEdit item)
    {
        using var conn = _factory.Create();
        return await conn.QuerySingleAsync<int>("sp_InvoiceItem_Insert", new
        {
            InvoiceId = invoiceId,
            item.Description,
            item.Quantity,
            item.UnitPrice
        }, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateAsync(int id, InvoiceItemEdit item)
    {
        using var conn = _factory.Create();
        await conn.ExecuteAsync("sp_InvoiceItem_Update", new
        {
            Id = id,
            item.Description,
            item.Quantity,
            item.UnitPrice
        }, commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteAsync(int id)
    {
        using var conn = _factory.Create();
        await conn.ExecuteAsync("sp_InvoiceItem_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteByInvoiceAsync(int invoiceId)
    {
        using var conn = _factory.Create();
        await conn.ExecuteAsync("sp_InvoiceItem_DeleteByInvoice", new { InvoiceId = invoiceId }, commandType: CommandType.StoredProcedure);
    }
}
