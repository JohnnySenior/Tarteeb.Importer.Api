//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tarteeb.Importer.Models.Applicants;
using Tarteeb.Importer.Services.Orchestrations;

namespace Tarteeb.Importer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : Controller
    {
        private readonly OrchestrationService orchestrationService;
        string filePath = @"C:\Users\icom\Desktop\.net.xlsx";

        public ApplicantController(OrchestrationService orchestrationService)
        {
            this.orchestrationService = orchestrationService;
        }

        [HttpGet("ImportFromExcel")]
        public ActionResult<List<Applicant>> GetApplicantsFromExcel()
        {
            return Ok(this.orchestrationService.ImportFromExcel(filePath));
        }
    }
}
