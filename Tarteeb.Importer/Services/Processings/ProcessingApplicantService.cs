//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using System.Threading.Tasks;
using Tarteeb.Importer.Models.Applicants;
using Tarteeb.Importer.Services.Foundations;

namespace Tarteeb.Importer.Services.Processings
{
    public class ProcessingApplicantService
    {
        private readonly ApplicantService applicantService;

        public ProcessingApplicantService(ApplicantService applicantService)
        {
            this.applicantService = applicantService;
        }

        public async Task<List<Applicant>> AddApplicantAsync(List<Applicant> applicants)
        {
            foreach (var applicant in applicants)
            {
                await this.applicantService.AddApplicantAsync(applicant);
            }
            return applicants;
        }
    }
}
