//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Microsoft.EntityFrameworkCore;
using Tarteeb.Importer.Models.Applicants;

namespace Tarteeb.Importer.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Applicant> Applicants { get; set; }
    }
}
