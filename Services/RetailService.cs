using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public interface IRetailService
    {
        void UploadHousholds(IList<Households> households);
        void UploadProducts(IList<Products> products);
        void UploadTransactions(IList<Transactions> transactions);
        IEnumerable<Transactions> GetByHshdNum(int hshdNum);
        Households GetById(int id);    
        void Delete(int id);
    }

    public class RetailService : IRetailService
    {
        private DataContext _context;

        public RetailService(DataContext context)
        {
            _context = context;
        }

        public void UploadHousholds(IList<Households> households){
            try {
                _context.ChangeTracker.AutoDetectChangesEnabled = false;
                   var count = 0;
                    foreach (var household in households)
                    {
                        _context.Households.Add(household);
                        count++;
                        if (count > 1000)
                        {
                            _context.SaveChanges();
                            count = 0;
                        }
                    }
                    if (count > 0){
                         _context.SaveChanges();
                    }
                }    
            finally
            {
                _context.ChangeTracker.AutoDetectChangesEnabled = true;
            }
          
           // _context.Households.AddRange(households);
           // _context.SaveChanges();
        }
         public void UploadProducts(IList<Products> products){
             try {
                _context.ChangeTracker.AutoDetectChangesEnabled = false;
                  var count = 0;
                    foreach (var product in products)
                    {
                        _context.Products.Add(product);
                        count++;
                        if (count > 1000)
                        {
                            _context.SaveChanges();
                            count = 0;
                        }
                    }
                    if (count > 0){
                         _context.SaveChanges();
                    }
             }   
            finally
            {
                _context.ChangeTracker.AutoDetectChangesEnabled = true;
            }
           // _context.Products.AddRange(products);
            //_context.SaveChanges();
        }
         public void UploadTransactions(IList<Transactions> transactions){
             try {
                    _context.ChangeTracker.AutoDetectChangesEnabled = false;
                   var count = 0;
                    foreach (var transaction in transactions)
                    {
                        _context.Transactions.Add(transaction);
                        count++;
                        if (count > 1000)
                        {
                            _context.SaveChanges();
                            count = 0;
                        }
                    }
                    if (count > 0){
                         _context.SaveChanges();
                    }
                //_context.Configuration.ValidateOnSaveEnabled = false;
                //_context.Transactions.AddRange(transactions);
               // _context.SaveChanges();
             }
            finally
            {
                _context.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }
        public Households GetById(int id)
        {
            return _context.Households.Find(id);
        }

        public IEnumerable<Transactions> GetByHshdNum(int hshdNum)
        {

            return _context.Transactions.Where(trans => trans.Hshd_Num == hshdNum).
            Include(hshd => hshd.Households).
            Include(prds => prds.Products).
            OrderBy(trans => trans.Hshd_Num).
            ThenBy(trans => trans.Basket_num).
            ThenBy(trans => trans.Purchase).
            ThenBy(trans => trans.Product_num).
            ThenBy(trans => trans.Products.Department).
            ThenBy(trans => trans.Products.Comodity).ToList();

        }
        public void Delete(int id)
        {
            var trans = _context.Transactions.Find(id);
            if (trans != null)
            {
                _context.Transactions.Remove(trans);
                _context.SaveChanges();
            }
        }
    }
      
}