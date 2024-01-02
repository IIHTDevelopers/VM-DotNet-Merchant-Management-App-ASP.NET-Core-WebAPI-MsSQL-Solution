
using Moq;
using MerchantManagementApp.BusinessLayer.Interfaces;
using MerchantManagementApp.BusinessLayer.Services.Repository;
using MerchantManagementApp.BusinessLayer.Services;
using MerchantManagementApp.BusinessLayer.ViewModels;
using MerchantManagementApp.DataLayer;
using MerchantManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MerchantManagementApp.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly MerchantManagementAppDbContext _dbContext;

        private readonly IMerchantManagementService  _merchantService;
        public readonly Mock<IMerchantManagementRepository> merchantservice = new Mock<IMerchantManagementRepository>();

        private readonly Merchant _merchant;
        private readonly MerchantViewModel _merchantViewModel;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_MerchantName_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                merchantservice.Setup(repo => repo.CreateMerchant(_merchant)).ReturnsAsync(_merchant);
                var result = await  _merchantService.CreateMerchant(_merchant);
                var actualLength = _merchant.Name.ToString().Length;
                if (result.Name.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_MerchantAge_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                merchantservice.Setup(repo => repo.CreateMerchant(_merchant)).ReturnsAsync(_merchant);
                var result = await  _merchantService.CreateMerchant(_merchant);
                var actualLength = _merchant.Age.ToString().Length;
                if (result.Age.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_MerchantDateOfBirth_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                merchantservice.Setup(repo => repo.CreateMerchant(_merchant)).ReturnsAsync(_merchant);
                var result = await  _merchantService.CreateMerchant(_merchant);
                var actualLength = _merchant.DateOfBirth.ToString().Length;
                if (result.DateOfBirth.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_MerchantId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                merchantservice.Setup(repo => repo.CreateMerchant(_merchant)).ReturnsAsync(_merchant);
                var result = await  _merchantService.CreateMerchant(_merchant);
                var actualLength = _merchant.MerchantId.ToString().Length;
                if (result.MerchantId.ToString().Length == actualLength)
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