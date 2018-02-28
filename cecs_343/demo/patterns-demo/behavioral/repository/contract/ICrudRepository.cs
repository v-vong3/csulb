namespace patterns_demo.behavioral.repository.contract
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines contract for Create, Read, Update, Delete operations (CRUD)
    /// </summary>
    /// <remarks>
    /// Add, Update, and Delete(s) returns a boolean value indicating if the operation was successful or not.
    /// For Get and GetAll(s) the presence of data indicates a success fetch, othewise the a null value or empty array will
    /// be returned respectively.   
    /// </remarks>
    public interface ICrudRepository<T> where T : class, new() // Restricts T to being a class with a default constructor
    {
        // CREATE
        bool Add(T entity);

        // READ
        T Get (int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Predicate<T> predicate);

        // UPDATE
        bool Update(T entity);

        // DELETE
        bool Delete(int id);
        bool Delete(T entity);
    }
}