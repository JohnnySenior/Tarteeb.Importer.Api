//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tarteeb.Importer.Models.Applicants;

namespace Tarteeb.Importer.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Applicant> Applicants { get; set; }

        public async Task<Applicant> InsertApplicantAsync(Applicant applicant)
        {
            await this.Applicants.AddAsync(applicant);
            await this.SaveChangesAsync();

            return applicant;
        }
    }
}
