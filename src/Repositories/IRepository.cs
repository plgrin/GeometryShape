using System;
using System.Collections.Generic;
using GeometricShape.Entities;
using GeometricShape.Specifications;

namespace GeometricShape.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(ISpecification<T> specification);
    }
}
