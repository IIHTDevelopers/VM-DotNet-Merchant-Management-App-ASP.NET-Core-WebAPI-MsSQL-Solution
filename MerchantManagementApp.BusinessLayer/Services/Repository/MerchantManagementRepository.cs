using Microsoft.EntityFrameworkCore;
using MerchantManagementApp.BusinessLayer.ViewModels;
using MerchantManagementApp.DataLayer;
using MerchantManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MerchantManagementApp.BusinessLayer.Services.Repository
{
    public class MerchantManagementRepository : IMerchantManagementRepository
    {
        private readonly MerchantManagementAppDbContext _dbContext;
        public MerchantManagementRepository(MerchantManagementAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Merchant> CreateMerchant(Merchant MerchantModel)
        {
            try
            {
                var result = await _dbContext.Merchants.AddAsync(MerchantModel);
                await _dbContext.SaveChangesAsync();
                return MerchantModel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteMerchantById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Merchants.Single(a => a.MerchantId== id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Merchant> GetAllMerchants()
        {
            try
            {
                var result = _dbContext.Merchants.
                OrderByDescending(x => x.MerchantId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Merchant> GetMerchantById(long id)
        {
            try
            {
                return await _dbContext.Merchants.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
        public async Task<Merchant> UpdateMerchant(MerchantViewModel model)
        {
            var Merchant = await _dbContext.Merchants.FindAsync(model.MerchantId);
            try
            {

                _dbContext.Merchants.Update(Merchant);
                await _dbContext.SaveChangesAsync();
                return Merchant;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}