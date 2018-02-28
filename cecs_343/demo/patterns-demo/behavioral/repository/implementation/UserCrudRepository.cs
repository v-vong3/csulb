namespace patterns_demo.behavioral.repository.implementation
{
    using System;
    using System.Collections.Generic;
    using patterns_demo.behavioral.repository.contract;

    /// <summary>
    /// Implementation of ICrudRepository for the User domain object
    /// </summary>
    public class UserCrudRepository : ICrudRepository<User>
    {
        public bool Add(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll(Predicate<User> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}