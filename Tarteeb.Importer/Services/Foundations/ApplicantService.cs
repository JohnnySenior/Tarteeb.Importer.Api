//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Tarteeb.Importer.Brokers.Storages;
using Tarteeb.Importer.Models.Applicants;

namespace Tarteeb.Importer.Services.Foundations
{
    public class ApplicantService
    {
        private readonly StorageBroker storageBroker;

        public ApplicantService(StorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async Task<Applicant> AddApplicantAsync(Applicant applicant) =>
            await this.storageBroker.InsertApplicantAsync(applicant);
    }
}
