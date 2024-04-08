namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
  using RSMEnterpriseIntegrationsAPI.Domain.Models;

  public interface ISalesOrderHeaderRepository
  {
    Task<SalesOrderHeader?> GetSalesOrderHeaderById(int id);
    Task<IEnumerable<SalesOrderHeader>> GetAllSalesOrderHeaders();
    Task<int> CreateSalesOrderHeader(SalesOrderHeader salesOrderHeader);
    Task<int> UpdateSalesOrderHeader(SalesOrderHeader salesOrderHeader);
    Task<int> DeleteSalesOrderHeader(SalesOrderHeader salesOrderHeader);
  }
}