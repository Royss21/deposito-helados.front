﻿namespace DepositoHelados.Domain.Commons.Interfaces;

public interface ICreateRepository<T> where T : class
{
    void Add(T t);
    void Add(IEnumerable<T> t);

    Task AddAsync(T t);
    Task AddAsync(IEnumerable<T> t);

}

