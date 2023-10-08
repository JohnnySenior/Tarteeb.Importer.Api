//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Xeptions;

namespace Tarteeb.Importer.Models.Exceptions
{
    public class InvalidApplicantException : Xeption
    {
        public InvalidApplicantException()
            : base(message: "Applicant is invalid")
        { }
    }
}
