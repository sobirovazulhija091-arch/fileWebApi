
using System.Net;
using Dapper;
using Npgsql;
using WebApi.Entities;
public class CompanyService(ApplicationDbContext dbContext) : ICompanyService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    public Response<string> Add(Company company)
    {
        try
        {
             using var  context = _dbContext.Connection();
             var query="insert into companies(name,description) values(@name,@description)";
             var result = context.Execute(query, new{name=company.Name,description=company.Description});
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


    public Response<string> Delete(int companyid)
    {
       try
       {
          using var context=_dbContext.Connection();
         var query = "delete from companies where id=@Id";
         var result =context.Execute(query,new{Id=companyid});
         return result==0? new Response<string>(HttpStatusCode.InternalServerError,"Company data not delete")
         : new Response<string>(HttpStatusCode.OK,"Company data successfully delete !");
       }
       catch (System.Exception ex)
       {
         Console.WriteLine(ex);
         return new Response<string>(HttpStatusCode.InternalServerError,"nternal Server Error");
       }
    }

    public List<Company> GetCompanies()
    {
       using var context = _dbContext.Connection();
       var query = "select * from companies";
       var companies = context.Query<Company>(query).ToList();
       return companies;
    }

    public Response<Company?> GetCompaniesById(int companyid)
    {
        try
        {
            using var context = _dbContext.Connection();
            var query = "select * from companies where id =@Id";
            var  company = context.QueryFirstOrDefault<Company>(query,new{Id=companyid});
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

    public Response<string> Update(Company model)
    {
       try
       {
          using var context = _dbContext.Connection();
          var query = "update companies set name=@name,description=@discription where id=@Id";
           var result =context.Execute(query,model);
          return result == 0?new Response<string>(HttpStatusCode.InternalServerError,"Company data not update") : new Response<string>(HttpStatusCode.OK,"Company data successfully updated !");
       }
       catch (System.Exception ex)
       {
         Console.WriteLine(ex);
         return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
       }
    }

}