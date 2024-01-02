
using Moq;
using MerchantManagementApp.BusinessLayer.Services;
using MerchantManagementApp.BusinessLayer.Services.Repository;
using MerchantManagementApp.BusinessLayer.ViewModels;
using MerchantManagementApp.DataLayer;
using MerchantManagementApp.Entities;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using MerchantManagementApp.BusinessLayer.Interfaces;

namespace MerchantManagementApp.Tests.TestCases
{
     public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly MerchantManagementAppDbContext _dbContext;

        private readonly IMerchantManagementService  _merchantService;
        public readonly Mock<IMerchantManagementRepository> merchantservice= new Mock<IMerchantManagementRepository >();

        private readonly Merchant _merchant;
        private readonly MerchantViewModel _merchantViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
             _merchantService = new MerchantManagementService(merchantservice.Object);
           
            _output = output;

            _merchant = new Merchant
            {
                MerchantId = 1,
                Name = "Merchant",
                DateOfBirth = DateTime.Now,
                Age = 2,
                MobileNumber = "6534231234"
            };

            _merchantViewModel = new MerchantViewModel
            {
                MerchantId = 1,
                Name = "Merchant",
                DateOfBirth = DateTime.Now,
                Age = 2,
                MobileNumber = "6534231234"
            };
        }
        
       
        [Fact]
        public async Task<bool> Testfor_Create_Merchant()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                merchantservice.Setup(repos => repos.CreateMerchant(_merchant)).ReturnsAsync(_merchant);
                var result = await  _merchantService.CreateMerchant(_merchant);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        
        [Fact]
        public async Task<bool> Testfor_Update_Merchant()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
           
            //Action
            try
            {
                merchantservice.Setup(repos => repos.UpdateMerchant(_merchantViewModel)).ReturnsAsync(_merchant); 
                var result = await  _merchantService.UpdateMerchant(_merchantViewModel);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
        
        [Fact]
        public async Task<bool> Testfor_GetMerchantById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                merchantservice.Setup(repos => repos.GetMerchantById(id)).ReturnsAsync(_merchant);
                var result = await  _merchantService.GetMerchantById(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_DeleteMerchantById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                merchantservice.Setup(repos => repos.DeleteMerchantById(id)).ReturnsAsync(response);
                var result = await  _merchantService.DeleteMerchantById(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
       
    }
}