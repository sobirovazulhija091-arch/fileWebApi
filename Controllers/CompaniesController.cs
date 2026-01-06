
// using WebApi.Data;
// using WebApi.Services;
using WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


[Route("api/[controller]")]
[ApiController]
public class CompaniesController(ICompanyService companyService) : ControllerBase
{
    private readonly ICompanyService _companyService = companyService;
  [HttpGet]
  public List<Company> GetCompanies()
    {
        return _companyService.GetCompanies();
    }
    [HttpGet("{companyid:int}")]
    public Response<Company?> GeCompanyByid(int companyid)
    {
         return _companyService.GetCompaniesById(companyid);
    }
    [HttpPost]
    public Response<string> Add(Company company)
    {
        return _companyService.Add(company);
    }
    [HttpPut]
    public Response<string> Update(Company model)
    {
        return _companyService.Update(model);
    }
    
    [HttpDelete("{comapanyid:int}")]
    public Response<string> Delete(int comapanyid)
    {
        return _companyService.Delete(comapanyid);
    }
}

