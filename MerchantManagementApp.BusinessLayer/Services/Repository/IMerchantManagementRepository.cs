using MerchantManagementApp.BusinessLayer.ViewModels;
using MerchantManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MerchantManagementApp.BusinessLayer.Services.Repository
{
    public interface IMerchantManagementRepository
    {
        List<Merchant> GetAllMerchants();
        Task<Merchant> CreateMerchant(Merchant merchant);
        Task<Merchant> GetMerchantById(long id);
        Task<bool> DeleteMerchantById(long id);
        Task<Merchant> UpdateMerchant(MerchantViewModel model);
    }
}
