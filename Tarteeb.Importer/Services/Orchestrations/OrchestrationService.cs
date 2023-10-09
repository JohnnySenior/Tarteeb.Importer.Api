//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using System.Threading.Tasks;
using Tarteeb.Importer.Models.Applicants;
using Tarteeb.Importer.Services.Processings;

namespace Tarteeb.Importer.Services.Orchestrations
{
    public class OrchestrationService
    {
        private readonly SpreadsheetProcessingService spreadsheetProcessingService;
        private readonly GroupProcessingService groupProcessingService;
        private readonly ProcessingApplicantService applicantProcessningService;

        public OrchestrationService(
            SpreadsheetProcessingService spreadsheetProcessingService,
            GroupProcessingService groupProcessingService,
            ProcessingApplicantService applicantProcessningService)
        {
            this.spreadsheetProcessingService = spreadsheetProcessingService;
            this.groupProcessingService = groupProcessingService;
            this.applicantProcessningService = applicantProcessningService;
        }

        public async Task<List<Applicant>> InsertedApplicant(string filePath)
        {
            var readyApplicants = await FullApplicants(filePath);

            var insertedApplicants = await
                applicantProcessningService.AddApplicantAsync(readyApplicants);

            return insertedApplicants;
        }

        public async Task<List<Applicant>> FullApplicants(string filePath)
        {
            var importedApplicants = ImportFromExcel(filePath);

            var fullAplicants = await
                groupProcessingService.AllApplicants(importedApplicants);

            return fullAplicants;
        }

        public List<Applicant> ImportFromExcel(string filePath) =>
            spreadsheetProcessingService.ValidateInvalidApplicants(filePath);
    }
}
