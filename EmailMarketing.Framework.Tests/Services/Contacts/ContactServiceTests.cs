﻿
using Autofac.Extras.Moq;
using DocumentFormat.OpenXml.Bibliography;
using EmailMarketing.Framework.Entities.Groups;
using EmailMarketing.Framework.Entities.Contacts;
using EmailMarketing.Framework.Enums;
using EmailMarketing.Framework.Repositories.Contacts;
using EmailMarketing.Framework.Repositories.Groups;
using EmailMarketing.Framework.Services.Contacts;
using EmailMarketing.Framework.UnitOfWorks.Contacts;
using EmailMarketing.Framework.UnitOfWorks.Groups;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmailMarketing.Framework.Entities;
using EmailMarketing.Common.Exceptions;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EmailMarketing.Framework.Tests.Services.Contacts
{
    [ExcludeFromCodeCoverage]
    public class ContactServiceTests
    {
        private AutoMock _mock;
        private Mock<IGroupRepository> _groupRepositoryMock;
        private Mock<IGroupContactRepository> _groupContactRepositoryMock;
        private Mock<IContactRepository> _contactRepositoryMock;
        private Mock<IContactValueMapRepository> _contactValueMapRepositoryMock;
        private Mock<IFieldMapRepository> _fieldMapRepositoryMock;

        private Mock<IContactUnitOfWork> _contactUnitOfWorkMock;
        private Mock<IGroupUnitOfWork> _groupUnitOfWorkMock;

        private IContactService _contactService;

        [OneTimeSetUp]
        public void ClassSetup()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassCleanUp()
        {
            _mock?.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            _groupRepositoryMock = _mock.Mock<IGroupRepository>();
            _groupContactRepositoryMock = _mock.Mock<IGroupContactRepository>();
            _contactRepositoryMock = _mock.Mock<IContactRepository>();
            _contactValueMapRepositoryMock = _mock.Mock<IContactValueMapRepository>();
            _fieldMapRepositoryMock = _mock.Mock<IFieldMapRepository>();

            _groupUnitOfWorkMock = _mock.Mock<IGroupUnitOfWork>();
            _contactUnitOfWorkMock = _mock.Mock<IContactUnitOfWork>();

            _contactService = _mock.Create<ContactService>();
        }

        [TearDown]
        public void Clean()
        {
            _groupRepositoryMock.Reset();
            _groupContactRepositoryMock.Reset();
            _contactRepositoryMock.Reset();
            _contactValueMapRepositoryMock.Reset();
            _fieldMapRepositoryMock.Reset();

            _groupUnitOfWorkMock.Reset();
            _contactUnitOfWorkMock.Reset();
        }

        [Test]
        public void GetContactValueMapByIdAsync_ForContactValueMapId_ReturnsContactValueMapObject()
        {
            //Arrange
            var contactValueMap = new ContactValueMap()
            {
                Id = 1,
                ContactId = 1,
                FieldMapId = 2,
                Value = "Team A"
            };
            int id = 1; 
            
            _contactUnitOfWorkMock.Setup(x => x.ContactValueMapRepository).Returns(_contactValueMapRepositoryMock.Object);
            _contactValueMapRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(contactValueMap).Verifiable();

            //Act
            var returnedDownloadQueue = _contactService.GetContactValueMapByIdAsync(id);

            //Assert
            _contactValueMapRepositoryMock.Verify();
        }

        [Test]
        public void DeleteContactGroupAsync_ForInvalidId_ThrowsException()
        {
            //Arrange
            var contactGroup = new ContactGroup()
            {
                Id = 1,
                GroupId = 2,
                ContactId = 1
            };
            int groupId = 2, contactId = 1;
            ContactGroup? nullContactGroup = null;

            _contactUnitOfWorkMock.Setup(x => x.GroupContactRepository).Returns(_groupContactRepositoryMock.Object);
            _groupContactRepositoryMock.Setup(x => x.GetFirstOrDefaultAsync(
                It.Is<Expression<Func<ContactGroup,ContactGroup>>>(y => y.Compile()(new ContactGroup()) is ContactGroup),
                It.Is<Expression<Func<ContactGroup,bool>>>(y => y.Compile()(contactGroup)),
                null,
                true)).ReturnsAsync(nullContactGroup).Verifiable();

            //Act
            Should.Throw<NotFoundException>(
            () => _contactService.DeleteContactGroupAsync(groupId,contactId)
            );

            //Assert
            _groupContactRepositoryMock.VerifyAll();
        }

        [Test]
        public void DeleteContactGroupAsync_ForValidId_DeleteContactGroup()
        {
            //Arrange
            var contactGroup = new ContactGroup()
            {
                Id = 1,
                GroupId = 2,
                ContactId = 1
            };

            var contactGroupToMatch = new ContactGroup()
            {
                Id = 1,
                GroupId = 2,
                ContactId = 1
            };

            int groupId = 2, contactId = 1;

            _contactUnitOfWorkMock.Setup(x => x.GroupContactRepository).Returns(_groupContactRepositoryMock.Object);
            _groupContactRepositoryMock.Setup(x => x.GetFirstOrDefaultAsync(
                It.Is<Expression<Func<ContactGroup, ContactGroup>>>(y => y.Compile()(new ContactGroup()) is ContactGroup),
                It.Is<Expression<Func<ContactGroup, bool>>>(y => y.Compile()(contactGroupToMatch)),
                null,
                true)).ReturnsAsync(contactGroup).Verifiable();

            _groupContactRepositoryMock.Setup(x => x.DeleteAsync(contactGroup.Id)).Returns(Task.CompletedTask).Verifiable();
            _groupUnitOfWorkMock.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask).Verifiable();

            //Act
            _contactService.DeleteContactGroupAsync(groupId, contactId);

            //Assert
            _groupContactRepositoryMock.VerifyAll();
            _contactUnitOfWorkMock.VerifyAll();

        }

        [Test]
        public void UpdateAsync_ForInvalidContact_ThrowsException()
        {
            //Assign
            var contact = new Contact
            {
                Id = 1,
                Email = "teamA@gmail.com"
            };
            var contactToMatch = new Contact
            {
                Id = 2,
                Email = "teamA@gmail.com"
            };
            _contactUnitOfWorkMock.Setup(x => x.ContactRepository).Returns(_contactRepositoryMock.Object);
            _contactRepositoryMock.Setup(x => x.IsExistsAsync(
                It.Is<Expression<Func<Contact,bool>>>(y => y.Compile()(contactToMatch))
                )).ReturnsAsync(true).Verifiable();

            //Act
            Should.Throw<DuplicationException>(
                () => _contactService.UpdateAsync(contact));

            //Assert
            _contactRepositoryMock.VerifyAll();
        }

        [Test]
        public void UpdateAsync_ForValidContactId_UpdateContact()
        {
            //Assign
            var existingContact = new Contact
            {
                Id = 1,
                Email = "teama@gmail.com"
            };
            var contactToUpdate = new Contact
            {
                Id = 1,
                Email = "teamA@gmail.com"
            };
            var contactToMatch = new Contact
            {
                Id = 2,
                Email = "teamA@gmail.com"
            };
            _contactUnitOfWorkMock.Setup(x => x.ContactRepository).Returns(_contactRepositoryMock.Object);

            _contactRepositoryMock.Setup(x => x.IsExistsAsync(
                It.Is<Expression<Func<Contact, bool>>>(y => y.Compile()(contactToMatch))
                )).ReturnsAsync(false).Verifiable();

            _contactRepositoryMock.Setup(x => x.GetFirstOrDefaultAsync(
                It.Is<Expression<Func<Contact, Contact>>>(y => y.Compile()(new Contact()) is Contact),
                It.Is<Expression<Func<Contact, bool>>>(y => y.Compile()(existingContact)),
                It.IsAny<Func<IQueryable<Contact>,IIncludableQueryable<Contact,object>>>(),
                true
                )).ReturnsAsync(existingContact).Verifiable();

            _contactRepositoryMock.Setup(x => x.UpdateAsync(existingContact)).Returns(Task.CompletedTask).Verifiable();
            _contactUnitOfWorkMock.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask).Verifiable();

            //Act
            _contactService.UpdateAsync(contactToUpdate);

            //Assert
            _contactRepositoryMock.VerifyAll();
            _contactUnitOfWorkMock.VerifyAll();
        }

        [Test]
        public void GetAllContactValueMapsCustom_ForUserId_ReturnsFieldMapList()
        {
            var userId = Guid.NewGuid();
            var list = new List<Object>
            {
                new { Value = 1, Text = "Email"},
                new { Value = 2, Text = "Address"},
                new { Value = 3, Text = "Date of Birth"},
            };
            var fieldMapTemp = new FieldMap
            {
                IsActive = true,
                IsDeleted = false,
                IsStandard = false,
                UserId = userId
            };

            _contactUnitOfWorkMock.Setup(x => x.FieldMapRepository).Returns(_fieldMapRepositoryMock.Object);
            _fieldMapRepositoryMock.Setup(x => x.GetAsync(
                It.IsAny<Expression<Func<FieldMap,Object>>>(),
                It.Is<Expression<Func<FieldMap, bool>>>(y => y.Compile()(fieldMapTemp)),
                null,
                null,
                true
               )).ReturnsAsync(list).Verifiable();

            //Act
            var result = _contactService.GetAllContactValueMapsCustom(userId);

            ////Assert
            _fieldMapRepositoryMock.VerifyAll();

        }
        [Test]
        public void GetAllContactAsync_ForUserId_ShowContactList()
        {
            //Assign
            int pageIndex = 1;
            int pageSize = 10;
            var searchText = "team";
            var userId = Guid.NewGuid();
            var orderBy = "asc";
            
            var contactListToReturn = new List<Contact>
            {
                new Contact
                {
                    Id = 1,
                    Email = "teamA@gmail.com"
                },
                new Contact
                {
                    Id = 2,
                    Email= "teamB@gmail.com"
                },
                new Contact
                {
                    Id = 3,
                    Email = "teamC@gmail.com"
                }
            };

            var contactToMatch = new Contact
            {
                UserId = userId,
                Email = "team"
            };

            var columnsMap = new Dictionary<string, Expression<Func<Entities.Contacts.Contact, object>>>()
            {
                ["Email"] = v => v.Email
            };

            _contactUnitOfWorkMock.Setup(x => x.ContactRepository).Returns(_contactRepositoryMock.Object);
            _contactRepositoryMock.Setup(x => x.GetAsync<Contact>(
                It.Is<Expression<Func<Contact, Contact>>>(y => y.Compile()(new Contact()) is Contact),
                It.Is<Expression<Func<Contact, bool>>>(y => y.Compile()(contactToMatch)),
                It.IsAny<Func<IQueryable<Contact>, IOrderedQueryable<Contact>>>(),
                It.IsAny<Func<IQueryable<Contact>, IIncludableQueryable<Contact, object>>>(),
                pageIndex,
                pageSize,
                true
            )).ReturnsAsync((contactListToReturn,4,3)).Verifiable();

            //Act
            var result = _contactService.GetAllContactAsync(userId, searchText, orderBy, pageIndex, pageSize);
            result.Result.ShouldBe((contactListToReturn, 4,3));

            //Assert
            _contactRepositoryMock.VerifyAll();
        }
    }
}


