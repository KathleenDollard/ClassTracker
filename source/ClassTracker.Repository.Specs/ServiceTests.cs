using KadGen.ClassTracker.Domain;
using KadGen.ClassTracker.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadGen.ClassTracker.Repository.Specs
{
    [TestClass]
    public class ServiceTests
    {
        // TODO: As an exercise, improve code reuse across these tests using generic and functional techniques
        //       Hint: You will probably want a store of data to compare
        //       Hint: You can use transactions to temporarily arrange the database for tests
        //       Bonus points: Do this against an in-memory store
        //       Bonus points: Use "data driven" tests to further automate test code (after the above)

        [TestMethod]
        public void Can_retrieve_existing_organization()
        {
            var service = new OrganizationService();
            const string orgName = "Fred's Bar and Grill";
            var id = GetOrgIdCreatingIfNeeded(service, orgName);
            var organizationResult = service.Get(id);
            Assert.IsNotNull(organizationResult);
            Assert.IsTrue(organizationResult.IsSuccessful);
            var organization = organizationResult.Data;
            Assert.AreEqual(orgName, organization.Name);
            Assert.AreEqual(0, organization.Terms.Count);
        }

        [TestMethod]
        public void Can_create_and_delete_organization()
        {
            // This is crappy testing because a failed test requires a manual database clean, it's a sample!
            var service = new OrganizationService();
            const string orgName = "Joe's Fish Shack";

            var id = GetOrgIdCreatingIfNeeded(service, orgName);
            Assert.AreNotEqual (0, id);

            var orgResult = service.Get(id);
            Assert.IsTrue(orgResult.IsSuccessful);
            var org = orgResult.Data;
            Assert.IsNotNull(org);
            Assert.AreEqual(orgName, org.Name);

            var deleteResult = service.Delete(org);
            Assert.IsTrue(orgResult.IsSuccessful);

             orgResult = service.Get(id);
            Assert.IsTrue(orgResult.IsSuccessful);
             org = orgResult.Data;
            Assert.IsNull(org);

        }

        [TestMethod]
        public void Can_update_organization()
        {
            // This is crappy testing because a failed test requires a manual database clean, it's a sample!
            var service = new OrganizationService();
            const string orgNameInitial = "Sam's Number 2 Diner";
            const string orgNameShouldBe = "Sam's Number 3 Diner";

            var id = GetOrgIdCreatingIfNeeded(service, orgNameInitial);
            Assert.AreNotEqual(0, id);

            var orgResult = service.Get(id);
            Assert.IsTrue(orgResult.IsSuccessful);
            var org = orgResult.Data;
            Assert.IsNotNull(org);
            Assert.AreEqual(orgNameInitial, org.Name);

            var updatedOrg  = new Organization(org.Id, orgNameShouldBe);
            var updateResult = service.Update(updatedOrg);
            Assert.IsTrue(updateResult.IsSuccessful);

            orgResult = service.Get(id);
            Assert.IsTrue(orgResult.IsSuccessful);
            org = orgResult.Data;
            Assert.IsNotNull(org);
            Assert.AreEqual(orgNameShouldBe, org.Name);
        }

        private int GetOrgIdCreatingIfNeeded(OrganizationService service, string name)
        {
            var orgResult = service.GetAll();
            Assert.IsTrue(orgResult.IsSuccessful);
            var orgs = orgResult.Data;
            var org = orgs
                .Where(x => x.Name == name)
                .SingleOrDefault();
            if (org == null)
            {
                return CreateOrganization(service, name);
            }
            return org.Id;
        }

        private static int CreateOrganization(OrganizationService service, string name)
        {
            var org = new Organization(0, name);
            var createResult = service.Create(org);
            Assert.IsTrue(createResult.IsSuccessful);
            return createResult.Data;
        }
    }
}
