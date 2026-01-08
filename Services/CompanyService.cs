
using System.Net;
using Dapper;
using Npgsql;
using WebApi.Entities;
public class CompanyService(ApplicationDbContext dbContext) : ICompanyService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    public async Task<Response<string>> AddAsync(Company company)
    {
        try
        {
             using var  context = _dbContext.Connection();
             var query="insert into companies(name,description) values(@name,@description)";
             var result =await context.ExecuteAsync(query, new{name=company.Name,description=company.Description});
             return result==0?
              new Response<string>(HttpStatusCode.InternalServerError,"Company data  not added!")
             : new Response<string>(HttpStatusCode.OK,"Company  data successfully added!");
        }
        catch (System.Exception ex)
        {
             Console.WriteLine(ex);
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
    }


    public async Task<Response<string>> DeleteAsync(int companyid)
    {
       try
       {
          using var context=_dbContext.Connection();
         var query = "delete from companies where id=@Id";
         var result = await context.ExecuteAsync(query,new{Id=companyid});
         return result==0? new Response<string>(HttpStatusCode.InternalServerError,"Company data not delete")
         : new Response<string>(HttpStatusCode.OK,"Company data successfully delete !");
       }
       catch (System.Exception ex)
       {
         Console.WriteLine(ex);
         return new Response<string>(HttpStatusCode.InternalServerError,"nternal Server Error");
       }
    }

    public async Task<List<Company>> GetCompaniesAsync()
    {
       using var context = _dbContext.Connection();
       var query = "select * from companies";
       var companies =await context.QueryAsync<Company>(query);
       return companies.ToList();
    }

    public async Task<Response<Company?>> GetCompaniesByIdAsync(int companyid)
    {
        try
        {
            using var context = _dbContext.Connection();
            var query = "select * from companies where id =@Id";
            var  company = await context.QueryFirstOrDefaultAsync<Company>(query,new{Id=companyid});
            return company == null
            ?  new Response<Company?>(HttpStatusCode.InternalServerError,"Company not found !")
            : new Response<Company?>(HttpStatusCode.OK,"Company found !",company);
        }
        catch (System.Exception ex)
        {
             Console.WriteLine(ex);
              return new Response<Company?>(HttpStatusCode.InternalServerError,"Internal Server Error");
        };
    }

    public  async Task<Response<string>> UpdateAsync(Company model)
    {
       try
       {
          using var context = _dbContext.Connection();
          var query = "update companies set name=@Name,description=@Description where id=@Id";
           var result =await context.ExecuteAsync(query,model);
          return result == 0?new Response<string>(HttpStatusCode.InternalServerError,"Company data not update") : new Response<string>(HttpStatusCode.OK,"Company data successfully updated !");
       }
       catch (System.Exception ex)
       {
         Console.WriteLine(ex);
         return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
       }
    }

}