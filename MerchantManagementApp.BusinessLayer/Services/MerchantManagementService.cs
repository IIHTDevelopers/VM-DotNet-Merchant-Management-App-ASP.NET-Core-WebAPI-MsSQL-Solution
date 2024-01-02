using MerchantManagementApp.BusinessLayer.Interfaces;
using MerchantManagementApp.BusinessLayer.Services.Repository;
using MerchantManagementApp.BusinessLayer.ViewModels;
using MerchantManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MerchantManagementApp.BusinessLayer.Services
{
    public class MerchantManagementService : IMerchantManagementService
    {
        private readonly IMerchantManagementRepository _repo;

        public MerchantManagementService(IMerchantManagementRepository repo)
        {
            _repo = repo;
        }

        public async Task<Merchant> CreateMerchant(Merchant employeeMerchant)
        {
            return await _repo.CreateMerchant(employeeMerchant);
        }

        public async Task<bool> DeleteMerchantById(long id)
        {
            return await _repo.DeleteMerchantById(id);
        }

        public List<Merchant> GetAllMerchants()
        {
            return  _repo.GetAllMerchants();
        }

        public async Task<Merchant> GetMerchantById(long id)
        {
            return await _repo.GetMerchantById(id);
        }

        public async Task<Merchant> UpdateMerchant(MerchantViewModel model)
        {
           return await _repo.UpdateMerchant(model);
        }
    }
}
