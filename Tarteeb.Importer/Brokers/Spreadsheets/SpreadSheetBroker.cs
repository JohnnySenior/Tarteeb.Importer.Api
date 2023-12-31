﻿//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using Bytescout.Spreadsheet;
using System;
using Tarteeb.Importer.Models.Applicants;

namespace Tarteeb.Provider.Brokers.Spreadsheets
{
    public class SpreadsheetBroker
    {
        public Applicant ImportApplicantFromExcel(string filePath, int row)
        {
            Spreadsheet document = new Spreadsheet();

            document.LoadFromFile(filePath);

            Worksheet worksheet = document.Workbook.Worksheets[0];

            Applicant applicant = new Applicant();

            applicant.ApplicantId = Guid.NewGuid();
            applicant.FirstName = worksheet.Cell(row, 1).ToString();
            applicant.LastName = worksheet.Cell(row, 2).ToString();
            applicant.PhoneNumber = worksheet.Cell(row, 3).ToString();
            applicant.Email = worksheet.Cell(row, 4).ToString();

            string dateString = worksheet.Cell(row, 5).ToString();
            if (DateTimeOffset.TryParse(dateString, out DateTimeOffset date))
            {
                applicant.BirthDate = date;
            }

            applicant.GroupName = worksheet.Cell(row, 6).ToString();
            applicant.GroupId = Guid.NewGuid();

            document.Close();

            return applicant;
        }
    }
}
