//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Tarteeb.Importer.Brokers.Storages;
using Tarteeb.Importer.Models.Groups;

namespace Tarteeb.Importer.Services.Foundations
{
    public class GroupService
    {
        private readonly StorageBroker storageBroker;

        public GroupService(StorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async Task<Group> AddGroupAsync(Group group) =>
            await this.storageBroker.InsertGroupAsync(group);

        public async Task<Group> GetGroupByNameAsync(string groupName) =>
            await this.storageBroker.SelectGroupByNameAsync(groupName);
    }
}
