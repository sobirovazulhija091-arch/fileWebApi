using WebApi.Entities;
public interface ICompanyService
{
    List<Company> GetCompanies();
    Response<Company?> GetCompaniesById(int companyid);
     Response<string> Add(Company company);
     Response<string> Update(Company model);
     Response<string> Delete(int companyid);
}

