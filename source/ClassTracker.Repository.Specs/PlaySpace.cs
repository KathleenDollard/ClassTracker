using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KadGen.ClassTracker.Repository;
using KadGen.ClassTracker.Domain;
using System.Linq;
using System.Linq.Expressions;
using Common;

namespace KadGen.ClassTracker.Repository.Specs
{
    [TestClass]
    public class PlaySpace
    {
        [TestMethod]
        public void TestExpressionParts()
        {
            Expression<Func<EfOrganization, int>> expr = org => org.Id;
            var keyName = expr.GetPropNameFromSimpleExpression();
            var keyWhereClaus = expr.WhereClauseForProperty(42);
            Assert.AreEqual("Id", keyName);
            Assert.AreEqual("x => (x.Id == 42)", keyWhereClaus.ToString());
        }


        [TestMethod]
        public void TestDbContext()
        {
            using (var dbContext = new ClassTrackerDbContext())
            {
                var x = dbContext.Organizations.Create();
                dbContext.SaveChanges();
            }
        }

        [TestMethod]
        public void Get_organization()
        {
            var repo = new OrganizationRepository();
            const string orgName = "Fred's Bar and Grill";
            var id = GetOrgIdCreatingIfNeeded(repo, orgName);
            var organizationResult = repo.Get(id);
            Assert.IsNotNull(organizationResult);
            Assert.IsTrue(organizationResult.IsSuccessful);
            var organization = organizationResult.Data;
            Assert.AreEqual(orgName, organization.Name);
            Assert.AreEqual(0, organization.Terms.Count);
        }

        [TestMethod]
        public void Get_organization_via_async()
        {
            var repo = new OrganizationRepository();
            const string orgName = "Fred's Bar and Grill";
            var id = GetOrgIdCreatingIfNeededViaAsync(repo, orgName);
            var organizationResult = repo.Get(id);
            Assert.IsNotNull(organizationResult);
            Assert.IsTrue(organizationResult.IsSuccessful);
            var organization = organizationResult.Data;
            Assert.AreEqual(orgName, organization.Name);
            Assert.AreEqual(0, organization.Terms.Count);
        }
        private int GetOrgIdCreatingIfNeeded(OrganizationRepository repo, string name)
        {
            var orgResult = repo.GetAll();
            Assert.IsTrue(orgResult.IsSuccessful);
            var orgs = orgResult.Data;
            var org = orgs
                .Where(x => x.Name == name)
                .SingleOrDefault();
            if (org == null)
            {
                org = new Organization(0, name);
                var createResult = repo.Create(org);
                Assert.IsTrue(createResult.IsSuccessful);
                return createResult.Data;
            }
            return org.Id;
        }

        private int GetOrgIdCreatingIfNeededViaAsync(OrganizationRepository repo, string name)
        {
            var orgResultTask = repo.GetAllAsync();
            Console.WriteLine("Returm from GetAllAsync");
            var orgResult = orgResultTask.Result;
            Assert.IsTrue(orgResult.IsSuccessful);
            var orgs = orgResult.Data;
            var org = orgs
                .Where(x => x.Name == name)
                .SingleOrDefault();
            if (org == null)
            {
                org = new Organization(0, name);
                var createResult = repo.Create(org);
                Assert.IsTrue(createResult.IsSuccessful);
                return createResult.Data;
            }
            return org.Id;
        }
    }
}
