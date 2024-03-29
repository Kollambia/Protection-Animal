﻿using Microsoft.EntityFrameworkCore;
using ProjectAnimal.Model.Repository;
using Protection_Animal.Infrastructure.Managers.Interfaces;
using Protection_Animal.Model.Entities;

namespace Protection_Animal.Infrastructure.Managers.Implemetations
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IRepository<ApplicationCategory, int> _repository;

        public CategoryManager(IRepository<ApplicationCategory, int> repository)
        {
            _repository = repository;
        }

        public List<ApplicationCategory> GetAll()
        {
            var allCategories = _repository.GetAll();

            if (allCategories == null)
                return null;

            return allCategories.ToList();
        }

        public ApplicationCategory Create(ApplicationCategory applicationCategory)
        {
            var createCategory = _repository.Create(applicationCategory);

            if (createCategory == null)
                return null;

            return createCategory;
        }
        public ApplicationCategory Update(ApplicationCategory applicationCategory, int id)
        {
            try
            {
                _repository.Update(applicationCategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.IsExists(applicationCategory.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return applicationCategory;
        }
        public ApplicationCategory Delete(int id)
        {
            var deleteCategory = _repository.DeleteById(id);

            if (deleteCategory == null)
                return null;

            return deleteCategory;

        }
        public ApplicationCategory GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool IsExists(int id)
        {
            return _repository.IsExists(id);
        }
    }
}
