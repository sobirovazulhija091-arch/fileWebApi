
// using WebApi.Data;
// using WebApi.Services;
using WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


[Route("api/[controller]")]
[ApiController]
public class CompaniesController(ICompanyService companyService) : ControllerBase
{
    private readonly ICompanyService _companyService = companyService;
  [HttpGet]
  public async Task<List<Company>> GetCompaniesAsync()
    {
        return await _companyService.GetCompaniesAsync();
    }
    [HttpGet("{companyid:int}")]
    public async Task<Response<Company?>> GeCompanyByidAsync(int companyid)
    {
         return await _companyService.GetCompaniesByIdAsync(companyid);
    }
    [HttpPost]
    public async Task<Response<string>> AddAsync(Company company)
    {
        return await _companyService.AddAsync(company);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(Company model)
    {
        return await _companyService.UpdateAsync(model);
    }
    
    [HttpDelete("{comapanyid:int}")]
    public async Task<Response<string>> DeleteAsync(int comapanyid)
    {
        return await _companyService.DeleteAsync(comapanyid);
    }
    [HttpGet("count")]
     public  async Task<int> GetCountCompanyAsync()
    {
         return await _companyService.GetCountCompanyAsync();
    }
     [HttpDelete("namecompany:string")]
    public async Task<Response<string>> DeleteDesAsync(string namecompany)
    {
         return await _companyService.DeleteDesAsync(namecompany);
    }
}

