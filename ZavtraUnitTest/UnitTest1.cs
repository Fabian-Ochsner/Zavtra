using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zavtra;

namespace ZavtraUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFarmLevelUpgrade()
        {
            //Arrange
            var farm = new Farm();


            //Act

            farm.upgrade();


            //Assert
            Assert.IsTrue(farm.level == 2, "Farm.level != 2!");
        }

        [TestMethod]
        public void TestFarmWoodStoneCostUpgrade()
        {
            //Arrange
            var farm = new Farm();


            //Act

            farm.upgrade();


            //Assert
            Assert.IsTrue(farm.costWood == 10000 &&farm.costStone == 10000, "Farm.costWood != 10'000! or FarmcostStone != 10'000");
        }

        [TestMethod]
        public void TestFarmMultipleUpgrade()
        {
            //Arrange
            var farm = new Farm();


            //Act

            farm.upgrade();
            farm.upgrade();
            farm.upgrade();
            farm.upgrade();
            farm.upgrade();


            //Assert
            Assert.IsTrue(farm.level == 6 && farm.costWood == 30000 && farm.costStone == 30000, "Farm.Level != 6 or Farm.costWood != 30'000! or FarmcostStone != 30'000");
        }


        [TestMethod]
        public void TestFarmOutputUpgrade()
        {
            //Arrange
            var farm = new Farm();


            //Act

            farm.upgrade();
            farm.upgrade();



            //Assert
            Assert.IsTrue(farm.output == 270, "Farm.output != 270");
        }


        [TestMethod]
        public void TestTownhallMaxBuilding()
        {
            //Arrange
            var townhall = new Townhall();


            //Act

            townhall.upgrade();
            townhall.upgrade();



            //Assert
            Assert.IsTrue(townhall.MaxBuildings == 20, "Townhall.MaxBuilding != 20");
        }


        [TestMethod]
        public void TestStorehouseFood()
        {
            //Arrange
            var storehouse = new Storehouse();


            //Act

            storehouse.upgrade();
            storehouse.upgrade();



            //Assert
            Assert.IsTrue(storehouse.maxFood == 90000, "Storehouse.maxFood != 90'000");
        }

        [TestMethod]
        public void TestStorehouseWood()
        {
            //Arrange
            var storehouse = new Storehouse();


            //Act

            storehouse.upgrade();
            storehouse.upgrade();



            //Assert
            Assert.IsTrue(storehouse.maxWood == 90000, "Storehouse.maxWood != 90'000");
        }


        [TestMethod]
        public void TestResidenceUpgrade()
        {
            //Arrange
            var residence = new Residence();


            //Act

            residence.upgrade();
            residence.upgrade();



            //Assert
            Assert.IsTrue(residence.maxResident == 9, "residence.maxResidenc != 9");
        }

        [TestMethod]
        public void TestTownBuildStructure()
        {
            //Arrange
            var town = new Town();


            //Act

            town.BuildStructure(BuildingType.quarry);
                

            //Assert
            Assert.IsTrue(town.structures.Count == 4, "town.structure.Count != 4");
        }


        [TestMethod]
        public void TestTownUpdateResourceData()
        {
            //Arrange
            var town = new Town();
            long currentWood = 0;
            long currentStone = 0;
            long resultWood = 27500;
            long resultStone = 29000;

            //Act

            town.BuildStructure(BuildingType.quarry);
            foreach (var ressource in town.ressource)
            {
                switch (ressource.ressourceType)
                {
                    case RessourceType.stone:
                        currentStone = ressource.currentRessource;
                        break;
                    case RessourceType.wood:
                        currentWood = ressource.currentRessource;
                        break;
                }
            }

            //Assert



            Assert.IsTrue(currentStone == resultStone && currentWood == resultWood, "cuttentStone or currentWood != result");
        }
    }
}
