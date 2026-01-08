using WebApi.Entities;
public interface ICompanyService
{
    Task<List<Company>> GetCompaniesAsync();
    Task<Response<Company?>> GetCompaniesByIdAsync(int companyid);
     Task<Response<string>> AddAsync(Company company);
     Task<Response<string>> UpdateAsync(Company model);
     Task<Response<string>> DeleteAsync(int companyid);
     Task<int> GetCountCompanyAsync();
     Task<Response<string>> DeleteDesAsync(string namecompany);
      
}

