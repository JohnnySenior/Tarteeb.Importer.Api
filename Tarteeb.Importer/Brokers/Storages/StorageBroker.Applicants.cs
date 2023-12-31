﻿//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<Applicant> SelectApplicantByIdAsync(Guid applicantId) =>
            await this.Applicants.FindAsync(applicantId);

        public IQueryable<Applicant> SelectApplicantAll() =>
            this.Applicants.AsQueryable();
    }
}
