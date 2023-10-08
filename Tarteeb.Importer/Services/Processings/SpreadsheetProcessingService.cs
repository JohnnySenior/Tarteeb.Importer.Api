//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using System;
using Tarteeb.Importer.Models.Applicants;
using Tarteeb.Importer.Services.Foundations;
using Tarteeb.Importer.Models.Exceptions;

namespace Tarteeb.Importer.Services.Processings
{
    public class SpreadsheetProcessingService
    {
        InvalidApplicantException invalidApplicantException = new InvalidApplicantException();
        SpreadsheetService spreadsheetService = new SpreadsheetService();

        public List<Applicant> ValidateInvalidApplicants(string filePath)
        {
            var notNullApplicants = this.spreadsheetService.GetAllApplicants(filePath);
            var validApplicants = new List<Applicant>();

            foreach (var applicant in notNullApplicants)
            {
                try
                {
                    Validate(
                        (Rule: IsInvalid(applicant.ApplicantId), Parameter: nameof(Applicant.ApplicantId)),
                        (Rule: IsInvalid(applicant.FirstName), Parameter: nameof(Applicant.FirstName)),
                        (Rule: IsInvalid(applicant.LastName), Parameter: nameof(Applicant.LastName)),
                        (Rule: IsInvalid(applicant.Email), Parameter: nameof(Applicant.Email)),
                        (Rule: IsInvalid(applicant.PhoneNumber), Parameter: nameof(Applicant.PhoneNumber)),
                        (Rule: IsInvalid(applicant.BirthDate), Parameter: nameof(Applicant.BirthDate)),
                        (Rule: IsInvalid(applicant.GroupName), Parameter: nameof(Applicant.GroupName)),
                        (Rule: IsInvalid(applicant.GroupId), Parameter: nameof(Applicant.GroupId)));

                    if (invalidApplicantException.Data.Count == 0)
                    {
                        Console.WriteLine($"{applicant.FirstName} is Validated");

                        validApplicants.Add(applicant);
                    }
                }
                catch (InvalidApplicantException ex)
                {
                    Console.Write($"{applicant.FirstName} => " );
                    Console.WriteLine(ex.Message);

                    invalidApplicantException.Data.Clear();
                    continue;
                }
            }

            return validApplicants;
        }

        private dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidApplicantException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidApplicantException.ThrowIfContainsErrors();
        }
    }
}
