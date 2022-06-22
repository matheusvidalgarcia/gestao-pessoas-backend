﻿using core.Repository.Mongo;
using core.Repository.UnitOfWork;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa.Infra.Data.Context
{
    public sealed class PessoaContext : IMongoContext, IUnitOfWork
    {
        private IMongoDatabase Database { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _commands;
        public IClientSessionHandle Session { get; set; }
        public PessoaContext(IConfiguration configuration)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();

            RegisterConventions();

            // Configure mongo (You can inject the config, just to simplify)
            MongoClient = new MongoClient(Environment.GetEnvironmentVariable("MONGOCONNECTION") ?? configuration.GetSection("MongoSettings").GetSection("Connection").Value);
            Database = MongoClient.GetDatabase(Environment.GetEnvironmentVariable("DATABASENAME") ?? configuration.GetSection("MongoSettings").GetSection("DatabaseName").Value);

        }

        private void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };

            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }

        public async Task<int> SaveChanges()
        {
            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public async Task<bool> Commit()
        {
            var changeAmount = await this.SaveChanges();

            return changeAmount > 0;
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}