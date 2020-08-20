﻿using ClosedXML.Excel;
using EmailMarketing.Framework.Entities;
using EmailMarketing.Framework.Entities.Contacts;
using EmailMarketing.Framework.Repositories.Contacts;
using EmailMarketing.Framework.UnitOfWorks.Contacts;
using EmailMarketing.Framework.UnitOfWorks.Groups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmailMarketing.Framework.Services.Contacts
{
    public class ContactExportService : IContactExportService
    {
        private IContactExportUnitOfWork _contactExportUnitOfWork;
        private IContactUnitOfWork _contactUnitOfWork;
        private IGroupUnitOfWork _groupUnitOfWork;
        public ContactExportService(IContactExportUnitOfWork contactExportUnitOfWork, IContactUnitOfWork contactUnitOfWork, IGroupUnitOfWork groupUnitOfWork)
        {
            _contactExportUnitOfWork = contactExportUnitOfWork;
            _contactUnitOfWork = contactUnitOfWork;
            _groupUnitOfWork = groupUnitOfWork;
        }

        public async Task<IList<Contact>> GetAllContactsAsync(Guid? userId)
        {
            var contacts = await _contactUnitOfWork.ContactRepository.GetAsync<Contact>(
                x => x, x => (!userId.HasValue || x.UserId == userId.Value), null, x => x.Include(i => i.ContactValueMaps).ThenInclude(i => i.FieldMap)
                .Include(i => i.ContactGroups).ThenInclude(i => i.Group), true
                );
            return contacts;
        }

        public async Task<IList<ContactGroup>> GetAllGroupsByIdAsync(int groupId)
        {
            var contacts = await _contactUnitOfWork.GroupContactRepository.GetAsync<ContactGroup>(
                x => x, x => (x.GroupId == groupId), null, x => x.Include(i => i.Contact).ThenInclude(i => i.ContactValueMaps).ThenInclude(i => i.FieldMap).Include(i=>i.Group), true
                );
            return contacts;
        }
        public async Task<Contact>  GetContactById(int contactId)
        {
            var contact = await _contactUnitOfWork.ContactRepository.GetByIdAsync(contactId);
            return contact;
        }
        

        public async Task<IList<(int Value, string Text, int Count)>> GetAllGroupsAsync(Guid? userId)
        {
            return (await _groupUnitOfWork.GroupRepository.GetAsync(x => new { Value = x.Id, Text = x.Name, Count = x.ContactGroups.Count() },
                                                   x => !x.IsDeleted && x.IsActive &&
                                                   (!userId.HasValue || x.UserId == userId.Value), x => x.OrderBy(o => o.Name), null, true))
                                                   .Select(x => (Value: x.Value, Text: x.Text, Count: x.Count)).ToList();
        }

        public async Task SaveDownloadQueueAsync(DownloadQueue downloadQueue)
        {
            await _contactExportUnitOfWork.DownloadQueueRepository.AddAsync(downloadQueue);
            await _contactExportUnitOfWork.SaveChangesAsync();
        }
        public async Task AddDownloadQueueSubEntities(IList<DownloadQueueSubEntity> downloadQueueSubEntities)
        {
            await _contactExportUnitOfWork.DownloadQueueSubEntityRepository.AddRangeAsync(downloadQueueSubEntities);
            await _contactExportUnitOfWork.SaveChangesAsync();
        }
        public async Task<IList<DownloadQueue>> GetDownloadQueue()
        {
            var result = await _contactExportUnitOfWork.DownloadQueueRepository.GetAsync(x => x, x => x.IsProcessing == true && x.IsSucceed == false, null, x => x.Include(x => x.DownloadQueueSubEntities), true);
            return result;
        }

        public async Task<DownloadQueue> GetDownloadQueueByIdAsync(int contactUploadId)
        {
            var contactUpload = await _contactExportUnitOfWork.DownloadQueueRepository.GetFirstOrDefaultAsync(x => x, x => x.Id == contactUploadId,
                                    null, true);

            return contactUpload;
        }
        public async Task UpdateDownloadQueueAync(DownloadQueue downloadQueue)
        {
            await _contactExportUnitOfWork.DownloadQueueRepository.UpdateAsync(downloadQueue);
            await _contactExportUnitOfWork.SaveChangesAsync();
        }

        public async Task ExcelExportForAllContacts(DownloadQueue downloadQueue)
        {
            using (var workbook = new XLWorkbook())
            {
                var contacts = await GetAllContactsAsync(downloadQueue.UserId);

                var worksheet = workbook.Worksheets.Add("Contacts");
                var currentRow = 1;
                int i = 3;

                worksheet.Cell(currentRow, 1).Value = "Contact Email Address";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;

                worksheet.Cell(currentRow, 2).Value = "Groups";
                worksheet.Cell(currentRow, 2).Style.Font.Bold = true;

                var fieldmaplist = contacts.SelectMany(x => x.ContactValueMaps).Select(x => x.FieldMap.DisplayName).Distinct().ToList();

                int currentColumn = 3, columnCount = 2;
                Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

                for (int j = 0; j < fieldmaplist.Count(); j++)
                {
                    worksheet.Cell(currentRow, j + currentColumn).Value = fieldmaplist[j];
                    worksheet.Cell(currentRow, j + currentColumn).Style.Font.Bold = true;
                    keyValuePairs.Add(fieldmaplist[j], j + currentColumn);
                    columnCount++;
                }


                foreach (var item1 in contacts)
                {
                    i++; currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item1.Email;

                    string group = string.Join(", ", item1.ContactGroups.Select(x => x.Group.Name));


                    worksheet.Cell(currentRow, 2).Value = group;

                    for (int j = 0; j < item1.ContactValueMaps.Count(); j++)
                    {
                        var key = item1.ContactValueMaps.Select(x => x.FieldMap.DisplayName).ToArray()[j];
                        if (keyValuePairs.ContainsKey(key))
                        {
                            worksheet.Cell(currentRow, keyValuePairs[key]).Value = item1.ContactValueMaps[j].Value;

                        }

                    }
                }
                //need to change
                worksheet.Columns("1", columnCount.ToString()).AdjustToContents();

                var memory = new MemoryStream();
                using (var stream = new FileStream(Path.Combine(downloadQueue.FileUrl, downloadQueue.FileName), FileMode.Create))
                {
                    workbook.SaveAs(stream);
                }
            }
        }

        public void Dispose()
        {
            _contactUnitOfWork.Dispose();
        }
    }
}
