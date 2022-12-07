﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectAnimal.Model.Repository;
using Protection_Animal.Infrastructure.Managers.Interfaces;
using Protection_Animal.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protection_Animal.Infrastructure.Managers.Implemetations
{
    public class ClientManager : IClientManager
    {
        private readonly IRepository<Client, string> _repository;
        public ClientManager(IRepository<Client, string> repository)
        {
            _repository= repository;
        }

        public List<Client> GetAll()
        {
            var allClients = _repository.ReadAll();

            if (allClients == null)
                return null;

            return allClients.ToList();
        }

        public Client GetById(string id)
        {

            return _repository.ReadById(id);
        }

        public Client Delete(string id)
        {
            var deleteClient = _repository.DeleteById(id);

            if (deleteClient == null)
                return null;

            return deleteClient;
        }
        public Client Create(Client client)
        {
            var createClient = _repository.Create(client);

            if (createClient == null)
                return null;

            return createClient;
        }
    }
}