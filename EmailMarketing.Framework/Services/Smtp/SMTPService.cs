﻿using EmailMarketing.Common.Exceptions;
using EmailMarketing.Framework.Entities;
using EmailMarketing.Framework.UnitOfWork.Smtp;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EmailMarketing.Common.Extensions;

namespace EmailMarketing.Framework.Services.Smtp
{
    public class SMTPService : ISmtpService
    {
        private ISMTPUnitOfWork _smtpUnitOfWork;

        public SMTPService(ISMTPUnitOfWork smtpUnitOfWork)
        {
            _smtpUnitOfWork = smtpUnitOfWork;
        }

        public async Task<(IList<Entities.SMTPConfig> Items, int Total, int TotalFilter)> GetAllAsync(
            string searchText, string orderBy, int pageIndex, int pageSize)
        {
            var columnsMap = new Dictionary<string, Expression<Func<Entities.SMTPConfig, object>>>()
            {
                ["server"] = v => v.Server,
                ["port"] = v => v.Port,
                ["senderName"] = v => v.SenderName,
                ["senderEmail"] = v => v.SenderEmail,
                ["userName"] = v => v.UserName,
                ["password"] = v => v.Password,
                ["enableSSL"] = v => v.EnableSSL
            };

            var result = await _smtpUnitOfWork.SMTPRepository.GetAsync<Entities.SMTPConfig>(
                x => x, x => x.Server.Contains(searchText),
                x => x.ApplyOrdering(columnsMap, orderBy), null,
                pageIndex, pageSize, true);

            return (result.Items, result.Total, result.TotalFilter);
        }

        public async Task<Entities.SMTPConfig> GetByIdAsync(Guid id)
        {
            return await _smtpUnitOfWork.SMTPRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Entities.SMTPConfig entity)
        {
            var isExists = await _smtpUnitOfWork.SMTPRepository.IsExistsAsync(x => x.Server == entity.Server && x.Id != entity.Id);
            if (isExists)
                throw new DuplicationException(nameof(entity.Server));

            await _smtpUnitOfWork.SMTPRepository.AddAsync(entity);
            await _smtpUnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Entities.SMTPConfig entity)
        {
            var isExists = await _smtpUnitOfWork.SMTPRepository.IsExistsAsync(x => x.Server == entity.Server && x.Id != entity.Id);
            if (isExists)
                throw new DuplicationException(nameof(entity.Server));

            var updateEntity = await GetByIdAsync(entity.Id);
            updateEntity.Server = entity.Server;
            updateEntity.Port = entity.Port;
            updateEntity.SenderName = entity.SenderName;
            updateEntity.SenderEmail = entity.SenderEmail;
            updateEntity.UserName = entity.UserName;
            updateEntity.Password = entity.Password;
            updateEntity.EnableSSL = entity.EnableSSL;

            await _smtpUnitOfWork.SMTPRepository.UpdateAsync(updateEntity);
            await _smtpUnitOfWork.SaveChangesAsync();
        }

        public async Task<SMTPConfig> DeleteAsync(Guid id)
        {
            var smtp = await GetByIdAsync(id);
            await _smtpUnitOfWork.SMTPRepository.DeleteAsync(id);
            await _smtpUnitOfWork.SaveChangesAsync();
            return smtp;
        }

        public void Dispose()
        {
            _smtpUnitOfWork?.Dispose();
        }
    }
}