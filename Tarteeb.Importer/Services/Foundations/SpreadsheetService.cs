//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Bytescout.Spreadsheet;
using System.Collections.Generic;
using Tarteeb.Importer.Models.Applicants;
using Tarteeb.Provider.Brokers.Spreadsheets;

namespace Tarteeb.Importer.Services.Foundations
{
    public class SpreadsheetService
    {
        private readonly SpreadsheetBroker spreadsheetBroker;

        public SpreadsheetService(SpreadsheetBroker spreadsheetBroker)
        {
            this.spreadsheetBroker = spreadsheetBroker;
        }

        public List<Applicant> GetAllApplicants(string filePath)
        {
            List<Applicant> allApplicants = new List<Applicant>();

            Spreadsheet document = new Spreadsheet();

            document.LoadFromFile(filePath);

            Worksheet worksheet = document.Workbook.Worksheets[0];

            for (int row = 1; row <= worksheet.UsedRangeRowMax; row++)
            {
                var applicant = spreadsheetBroker.ImportApplicantFromExcel(filePath, row);

                allApplicants.Add(applicant);
            }

            return allApplicants;
        }
    }
}
