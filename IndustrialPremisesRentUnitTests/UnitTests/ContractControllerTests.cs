using IndustrialPremisesRent.Controllers;
using IndustrialPremisesRent.Models;
using IndustrialPremisesRentUnitTests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IndustrialPremisesRentUnitTests.UnitTests
{
    [TestClass]
    public class ContractControllerTests
    {
        [DataTestMethod]
        [DataRow(1, 3, DisplayName = "Get contract by id")]
        [DataRow(0, 0, DisplayName = "Get non-existing contract")]
        public void ContractControllerTests_GetContract(int id, int equipmentAmount)
        {
            // Arrange
            var mockService = new Mock<FakeContractControllerService>();
            var controller = new ContractController(mockService.Object);

            // Act
            var result = controller.Get(id).Result.Value;

            // Assert
            Assert.IsInstanceOfType(result, typeof(Contract));
            Assert.AreEqual(equipmentAmount, result.EquipmentAmount);
        }

        [TestMethod]
        public void ContractControllerTests_GetContractList()
        {
            // Arrange
            var mockService = new Mock<FakeContractControllerService>();
            var controller = new ContractController(mockService.Object);

            // Act
            var result = controller.Get().Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Contract>));
            Assert.AreEqual(result.Count(), 2);
        }

        [DataTestMethod]
        [DataRow(1, 1, 3, "Microsoft.AspNetCore.Mvc.OkResult", DisplayName = "All valid")]
        [DataRow(1, 3, 4, "Microsoft.AspNetCore.Mvc.NotFoundResult", DisplayName = "Wrong equipment")]
        [DataRow(2, 2, 15, "Microsoft.AspNetCore.Mvc.NotFoundResult", DisplayName = "Wrong square")]
        public void ContractControllerTests_CreateContract(int premiseCode, int equipmentCode, int equipmentAmount, string expectedResult)
        {
            // Arrange
            var mockService = new Mock<FakeContractControllerService>();
            var controller = new ContractController(mockService.Object);

            // Act
            var result = controller.Add(premiseCode, equipmentCode, equipmentAmount).Result.ToString();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}