using  Microsoft.Extensions.DependencyInjection;
using  Microsoft.Extensions.Configuration;

using Repo.Repository.Factory;
using Repo.Repository.Repository;
using Repo.Repository.Repositories.Interfaces;
using CodeGen.Repository.Repositories.Interfaces;
using CodeGen.Repository.Repository;
using JwtLogin.Repository.Repositories.Interfaces;
using JwtLogin.Repository.Repository;
namespace Repo.Repository.Container
{
	public static class CustomContainer
	{
		public static void AddCustomContainer(this IServiceCollection services, IConfiguration configuration)
		{
		IWizTestConnectionFactory WizTestconnectionFactory=new WizTestConnectionFactory(configuration.GetConnectionString("DBconnectionWizTest"));


		services.AddSingleton<IWizTestConnectionFactory> (WizTestconnectionFactory);

		services.AddScoped<IModOneRepository, ModOneRepository>();
		services.AddScoped<ICodeGenLoginRepository, CodeGenLoginRepository>();
		services.AddScoped<ISendSMSRepository, SendSMSRepository>();
		services.AddScoped<IModTwoRepository, ModTwoRepository>();
		services.AddScoped<IHierarchyServiceProviderRepository, HierarchyServiceProviderRepository>();
		services.AddScoped<ILevelServiceProvider, LevelServiceProvider>();
		services.AddScoped<ILevelDetailsServiceProvider, LeveDetailslServiceProvider>();
		services.AddScoped<IDesignationServiceProvider, DesignationServiceProvider>();
		services.AddScoped<IFuncServiceProvider, FuncServiceProviderNew>();
		services.AddScoped<IProjectLinkServiceProvider, ProjectLinkServiceProvider>();
		services.AddScoped<IGblLinkServiceProvider, GblLinkServiceProvider>();
		services.AddScoped<IPriLinkServiceProvider, PriLinkServiceProvider>();
		services.AddScoped<ISetPermissionServiceProvider, SetPermissionServiceProvider>();
		services.AddScoped<IUserServiceProvider, UserServiceProvider>();
		services.AddScoped<IJwtRepository, JWTloginRepository>();
			//Write code here
		}
	}
}
