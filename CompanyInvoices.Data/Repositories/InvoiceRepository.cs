using System.Data;
using CompanyInvoices.Core.Interfaces;
using CompanyInvoices.Core.Models;
using Dapper;

namespace CompanyInvoices.Data.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly DbConnectionFactory _factory;
    private readonly IInvoiceItemRepository _items;

    public InvoiceRepository(DbConnectionFactory factory, IInvoiceItemRepository items)
    {
        _factory = factory;
        _items = items;
    }

    public async Task<IEnumerable<InvoiceView>> GetAllAsync()
    {
        using var conn = _factory.Create();
        var invoices = (await conn.QueryAsync<InvoiceView>("sp_Invoice_GetAll", commandType: CommandType.StoredProcedure)).ToList();
        foreach (var invoice in invoices)
        {
            invoice.Items = (await _items.GetByInvoiceAsync(invoice.Id)).ToList();
        }
        return invoices;
    }

    public async Task<InvoiceView?> GetByIdAsync(int id)
    {
        using var conn = _factory.Create();
        var invoice = await conn.QuerySingleOrDefaultAsync<InvoiceView>("sp_Invoice_GetById", new { Id = id }, commandType: CommandType.StoredProcedure);
        if (invoice is null)
        {
            return null;
        }

        invoice.Items = (await _items.GetByInvoiceAsync(invoice.Id)).ToList();
        return invoice;
    }

    public async Task<IEnumerable<InvoiceView>> GetByCompanyAsync(int companyId)
    {
        using var conn = _factory.Create();
        var invoices = (await conn.QueryAsync<InvoiceView>("sp_Invoice_GetByCompany", new { CompanyId = companyId }, commandType: CommandType.StoredProcedure)).ToList();
        foreach (var invoice in invoices)
        {
            invoice.Items = (await _items.GetByInvoiceAsync(invoice.Id)).ToList();
        }
        return invoices;
    }

    public async Task<bool> NumberExistsAsync(string number, int? excludeId = null)
    {
        using var conn = _factory.Create();
        return await conn.ExecuteScalarAsync<bool>("sp_Invoice_NumberExists", new { Number = number, ExcludeId = excludeId }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertAsync(InvoiceEdit invoice)
    {
        using var conn = _factory.Create();
        var totalAmount = invoice.Items.Sum(x => x.Quantity * x.UnitPrice);
        var id = await conn.QuerySingleAsync<int>("sp_Invoice_Insert", new
        {
            invoice.CompanyId,
            invoice.Number,
            invoice.InvoiceDate,
            TotalAmount = totalAmount
        }, commandType: CommandType.StoredProcedure);

        foreach (var item in invoice.Items)
        {
            await _items.InsertAsync(id, item);
        }

        return id;
    }

    public async Task UpdateAsync(int id, InvoiceEdit invoice)
    {
        using var conn = _factory.Create();
        var totalAmount = invoice.Items.Sum(x => x.Quantity * x.UnitPrice);

        await conn.ExecuteAsync("sp_Invoice_Update", new
        {
            Id = id,
            invoice.CompanyId,
            invoice.Number,
            invoice.InvoiceDate,
            TotalAmount = totalAmount
        }, commandType: CommandType.StoredProcedure);

        await _items.DeleteByInvoiceAsync(id);
        foreach (var item in invoice.Items)
        {
            await _items.InsertAsync(id, item);
        }
    }

    public async Task DeleteAsync(int id)
    {
        using var conn = _factory.Create();
        await _items.DeleteByInvoiceAsync(id);
        await conn.ExecuteAsync("sp_Invoice_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
    }
}
