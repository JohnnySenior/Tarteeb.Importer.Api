using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tarteeb.Importer.Models.Groups;

namespace Tarteeb.Importer.Brokers.Storages
{
    public partial class StorageBroker
    {
        DbSet<Group> Groups { get; set; }

        public async Task<Group> InsertGroupAsync(Group group)
        {
            await this.Groups.AddAsync(group);
            await this.SaveChangesAsync();

            return group;
        }
    }
}
