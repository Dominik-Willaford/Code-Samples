using CodeSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeSamples.Service
{
    public interface IDatabaseFunctionService
    {
        void CreateEntry(UserInfo model);
        List<UserInfo> GetEntries();
    }
    public class DatabaseFunctionService : IDatabaseFunctionService
    {
        private readonly DemoEntities _entities;

        public DatabaseFunctionService(DemoEntities entities)
        {
            _entities = entities;
        }

        public void CreateEntry(UserInfo model)
        {
            _entities.UserInfoes.Add(model);
            _entities.SaveChanges();
        }

        public List<UserInfo> GetEntries()
        {
            return _entities.UserInfoes.ToList();
        }
    }
}