﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter); // parametre -> filtreleme işlemlerinde entity framework teki lambda ifade
                                                                    // <T, bool> -> giriş değeri T, çıkış değeri bool
                                                                    // örn. adres kontrolü yapıyoruz. ankarayı arıyoruz. ankara varsa filtreleme
                                                                    // yaptığımız veride true dönüyor.
                                                                    // filter ifadesi de gönderdiğmiz parametreyş tutacak.
    }
}
