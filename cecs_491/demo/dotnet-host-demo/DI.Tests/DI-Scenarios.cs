using LibAccount;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Tests
{
    [TestClass]
    public class Scenarios
    {

        [TestMethod]
        public void ObjectWithNestedDependencies()
        {

            var authDAO = new AuthDAO();
            var authChecker = new AuthChecker(authDAO);
            var accountManager = new AccountManager(authChecker);

            Assert.IsNotNull(accountManager);
        }



        [TestMethod]
        public void ObjectWithNestedDependencies_DI()
        {

            IServiceCollection services = new ServiceCollection();

            // Registration of dependencies to be controlled by DI container
            services.AddTransient<AuthDAO>();
            services.AddTransient<AuthChecker>();
            services.AddTransient<AccountManager>();


            IServiceProvider provider = services.BuildServiceProvider();

            var accountManager = provider.GetRequiredService<AccountManager>();

            Assert.IsNotNull(accountManager);
        }


        [TestMethod]
        public void VerifyingServiceLifetime()
        {

            var authDAO = AuthDAO.CreateInstance();
            var authChecker = new AuthChecker(authDAO);
            var accountManager = new AccountManager(authChecker);
            var accountManager2 = new AccountManager(authChecker);

            Assert.IsNotNull(accountManager);
            Assert.IsTrue(AuthDAO._instanceCounter == 1);
        }


        [TestMethod]
        public void VerifyingTransientServiceLifetime_DI()
        {

            IServiceCollection services = new ServiceCollection();

            // Registration of dependencies to be controlled by DI container
            services.AddTransient<AuthDAO>((sp) =>
            {
                return AuthDAO.CreateInstance();
            });
            services.AddTransient<AuthChecker>();
            services.AddTransient<AccountManager>();


            IServiceProvider provider = services.BuildServiceProvider();

            var accountManager = provider.GetRequiredService<AccountManager>();
            var accountManager2 = provider.GetRequiredService<AccountManager>();

            Assert.IsNotNull(accountManager);
            Assert.IsNotNull(accountManager2);
            Assert.IsTrue(AuthDAO._instanceCounter == 2);
        }


        [TestMethod]
        public void VerifyingSingletonServiceLifetime_DI()
        {

            IServiceCollection services = new ServiceCollection();

            // Registration of dependencies to be controlled by DI container
            services.AddSingleton<AuthDAO>((sp) =>
            {
                return AuthDAO.CreateInstance();
            });
            services.AddTransient<AuthChecker>();
            services.AddTransient<AccountManager>();


            IServiceProvider provider = services.BuildServiceProvider();

            var accountManager = provider.GetRequiredService<AccountManager>();
            var accountManager2 = provider.GetRequiredService<AccountManager>();

            Assert.IsNotNull(accountManager);
            Assert.IsNotNull(accountManager2);
            Assert.IsTrue(AuthDAO._instanceCounter == 1);
        }


        [TestMethod]
        public void VerifyingScopedServiceLifetime_Failed_DI()
        {

            IServiceCollection services = new ServiceCollection();

            // Registration of dependencies to be controlled by DI container
            services.AddScoped<AuthDAO>((sp) =>
            {
                return AuthDAO.CreateInstance();
            });
            services.AddTransient<AuthChecker>();
            services.AddTransient<AccountManager>();


            IServiceProvider provider = services.BuildServiceProvider();

            var accountManager = provider.GetRequiredService<AccountManager>();
            var accountManager2 = provider.GetRequiredService<AccountManager>();

            Assert.IsNotNull(accountManager);
            Assert.IsNotNull(accountManager2);
            Assert.IsTrue(AuthDAO._instanceCounter == 1);

            Assert.IsTrue(accountManager._authChecker._authDAO.InstanceId != accountManager2._authChecker._authDAO.InstanceId);
        }


        [TestMethod]
        public void VerifyingScopedServiceLifetime_Pass_DI()
        {

            IServiceCollection services = new ServiceCollection();

            // Registration of dependencies to be controlled by DI container
            services.AddScoped<AuthDAO>((sp) =>
            {
                return AuthDAO.CreateInstance();
            });
            services.AddTransient<AuthChecker>();
            services.AddTransient<AccountManager>();


            IServiceProvider provider = services.BuildServiceProvider();

            var accountManager = provider.GetRequiredService<AccountManager>();

            var scope = provider.CreateScope();

            var accountManager2 = scope.ServiceProvider.GetRequiredService<AccountManager>();

            Assert.IsNotNull(accountManager);
            Assert.IsNotNull(accountManager2);
            //Assert.IsTrue(AuthDAO._instanceCounter == 1);

            Assert.IsTrue(accountManager._authChecker._authDAO.InstanceId != accountManager2._authChecker._authDAO.InstanceId);
        }

    }
}