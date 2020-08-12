﻿using EmailMarketing.Common.Services;
using EmailMarketing.Framework.Entities.Contacts;
using EmailMarketing.Framework.Services.Contacts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmailMarketing.Web.Areas.Member.Models.Contacts
{
    public class FieldMapModel : ContactsBaseModel
    {
        public Guid? UserId { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public bool IsStandard { get; set; }
        public FieldMapModel(IFieldMapService fieldMapService,
            ICurrentUserService currentUserService) : base(fieldMapService, currentUserService)
        {

        }
        public FieldMapModel() : base()
        {

        }
        public async Task<object> GetAllFieldMapAsync(DataTablesAjaxRequestModel tableModel)
        {
            var result = await _fieldMapService.GetAllAsync(
                _currentUserService.UserId,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "DisplayName" }),
                tableModel.PageIndex, tableModel.PageSize);


            return new
            {
                recordsTotal = result.Total,
                recordsFiltered = result.TotalFilter,
                data = (from item in result.Items
                        select new string[]
                        {
                            item.DisplayName,
                            item.Id.ToString()
                        }).ToArray()

            };
        }

        public async Task<string> DeleteFieldMapAsync(int id)
        {
            var name = await _fieldMapService.DeleteAsync(id);
            return name.DisplayName;
        }

        public async Task AddFieldMapAsync()
        {

            var entity = new FieldMap
            {
                DisplayName = this.DisplayName,
                UserId = _currentUserService.UserId,
                IsStandard = false
            };
            await _fieldMapService.AddAsync(entity);
        }

        public async Task LoadByIdAsync(int id)
        {
            var result = await _fieldMapService.GetByIdAsync(id);
            this.UserId = result.UserId;
            this.DisplayName = result.DisplayName;
            this.IsStandard = result.IsStandard;
        }

        public async Task UpdateFieldMapAsync()
        {
            var entity = new FieldMap
            {
                DisplayName = this.DisplayName,
                UserId = _currentUserService.UserId,
                IsStandard = false
            };
            await _fieldMapService.UpdateAsync(entity);
        }
    }
}
