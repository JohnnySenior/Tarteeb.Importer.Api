//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarteeb.Importer.Models.Applicants;
using Tarteeb.Importer.Models.Groups;
using Tarteeb.Importer.Services.Foundations;

namespace Tarteeb.Importer.Services.Processings
{
    public class GroupProcessingService
    {
        private readonly GroupService groupService;

        public GroupProcessingService(GroupService groupService)
        {
            this.groupService = groupService;
        }

        public async Task<List<Applicant>> AllApplicants(List<Applicant> applicants)
        {
            foreach (var applicant in applicants)
            {
                var id = await EnsureGroupExistsAsync(applicant.GroupName);
                applicant.GroupId = id;
            }
            return applicants;
        }

        public async Task<Guid> EnsureGroupExistsAsync(string groupName)
        {
            var ensuredGroup = await this.groupService.GetGroupByNameAsync(groupName);

            if (ensuredGroup == null)
            {
                var newGroup = new Group { GroupName = groupName };
                var createdGroup = await this.groupService.AddGroupAsync(newGroup);

                return createdGroup.GroupId;
            }
            else
            {
                return ensuredGroup.GroupId;
            }
        }
    }
}
