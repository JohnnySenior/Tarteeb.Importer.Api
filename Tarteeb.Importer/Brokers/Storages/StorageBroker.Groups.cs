using Microsoft.EntityFrameworkCore;
using Tarteeb.Importer.Models.Groups;

namespace Tarteeb.Importer.Brokers.Storages
{
    public partial class StorageBroker
    {
        DbSet<Group> Groups { get; set; }
    }
}
