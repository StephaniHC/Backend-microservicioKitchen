-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: nutritionalkitchen
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20241214135032_CreateDatabase','7.0.20');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredients`
--

DROP TABLE IF EXISTS `ingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredients` (
  `id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `name` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients`
--

LOCK TABLES `ingredients` WRITE;
/*!40000 ALTER TABLE `ingredients` DISABLE KEYS */;
INSERT INTO `ingredients` VALUES ('08dd1c46-7e37-40a0-8493-f11bce9fee7f','Tomate'),('08dd1c47-05bb-45e2-8fde-8e4815933ff8','Lechuga'),('08dd1f13-3171-4f75-8d88-7249b3df9b83','test ingredient'),('08dd1fdd-3171-4f75-8d88-7249b3df9b83','test ingredient'),('08dd1fdd-3371-4f83-8d88-7249b3df9b83','Zanahoria'),('08dd1fe0-a140-4da8-861c-d1d61ec2fe5f','Choclo'),('08dd3e90-5c2f-462a-8b77-27bc3d3a65c8','string'),('330b7d71-60d3-4cf1-a2eb-a5447aaa60cd','Iowa'),('3fa85f00-5717-4500-b3fc-2c233f66af00','test ingredient'),('3fa85f00-5717-4522-b3fc-2c233f66af00','test ingredient'),('3fa85f14-5717-4562-b3fc-2c963f66afb5','test ingredient'),('3fa85f64-5717-4562-a7fc-2a763f66afa6','pruebas de front'),('3fa85f64-5717-4562-a7fc-2c963f66afa6','data swagger'),('3fa85f64-5717-4562-b3fc-2c963f66afa4','test ingredient'),('3fa85f64-5717-4562-b3fc-2c963f66afa6','lechuge'),('3fa85f64-5717-4562-b3fc-2c963f66afb5','test ingredient'),('3fa85f64-5717-7462-a7fc-2a763f66afa6','pruebas de front'),('662edee3-f681-4ac8-85b2-99f596cacdb9','Senior'),('7a5230f2-cdfc-4a36-a7df-2cc62d3a7cd2','Games'),('bd828952-e702-4d8d-b805-f92e30f5fca7','disintermediate'),('c9b46fce-2902-4adb-9622-da112754567d','real-time');
/*!40000 ALTER TABLE `ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kitchenmanager`
--

DROP TABLE IF EXISTS `kitchenmanager`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kitchenmanager` (
  `id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `name` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `shift` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kitchenmanager`
--

LOCK TABLES `kitchenmanager` WRITE;
/*!40000 ALTER TABLE `kitchenmanager` DISABLE KEYS */;
INSERT INTO `kitchenmanager` VALUES ('08dd3e90-5c2f-462a-8b77-27bc3d3a65c8','prueba','prueba'),('2fa85f75-5780-4562-b3fc-2c963f66afa6','test integracion','morning'),('3fa85f00-5717-4562-b3fc-2c233f66af00','test integracion','morning'),('3fa85f00-5717-4562-b3fc-2c233f66af22','test integracion','morning'),('3fa85f64-5717-4562-b3fc-2c963f66afa6','Luis','tarde'),('3fa85f64-5728-4562-b3fc-2c963f66afa6','test','morning'),('3fa85f75-5728-4562-b3fc-2c963f66afa6','test integracion','morning'),('bd828952-e702-4d8d-b813-f92e30f5fca7','prueba front','morning');
/*!40000 ALTER TABLE `kitchenmanager` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `label`
--

DROP TABLE IF EXISTS `label`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `label` (
  `batchCode` char(50) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `productionDate` datetime(6) NOT NULL,
  `expirationDate` datetime(6) NOT NULL,
  `detail` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `patientId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `address` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`batchCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `label`
--

LOCK TABLES `label` WRITE;
/*!40000 ALTER TABLE `label` DISABLE KEYS */;
INSERT INTO `label` VALUES ('3fa85f64-1717-4562-b3fc-2c963f66afa6','2025-02-23 15:07:44.000000','2025-04-23 15:07:44.000000','test','3fa85f64-5717-4562-b3fc-2c963f66afa6','test');
/*!40000 ALTER TABLE `label` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `package`
--

DROP TABLE IF EXISTS `package`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `package` (
  `id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `status` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `batchCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `preparedRecipeId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `package`
--

LOCK TABLES `package` WRITE;
/*!40000 ALTER TABLE `package` DISABLE KEYS */;
INSERT INTO `package` VALUES ('0fa85f64-5717-4562-b3fc-2c233f66af75','pending f','3fa85f64-5717-4562-b3fc-2c233f66af75','3fa85f64-5717-4562-b3fc-2c233f66af75'),('2fa25f64-5717-4562-b3fc-2c233f66af75','pending f','3fa85f64-5717-4562-b3fc-2c233f66af75','3fa85f64-5717-4562-b3fc-2c233f66af75'),('3fa84a58-5478-4552-b3ee-2c963f66afd6','pending f','3fa85f64-5717-4562-b3fc-2c233f66af75','3fa85f64-5717-4562-b3fc-2c233f66af75'),('3fa84a58-5728-4552-b3ee-2c963f66afd6','pending f','3fa85f64-5717-4562-b3fc-2c233f66af75','3fa85f64-5717-4562-b3fc-2c233f66af75'),('3fa84a58-5728-4562-b3ee-2c963f66afa6','pending f','3fa85f64-5717-4562-b3fc-2c233f66af75','3fa85f64-5717-4562-b3fc-2c233f66af75'),('3fa84a65-5728-4562-b3ee-2c963f66afa7','pending f','3fa85f64-5717-4562-b3fc-2c233f66af75','3fa85f64-5717-4562-b3fc-2c233f66af75'),('3fa84a75-5728-4562-b3ee-2c963f66afa6','pending f','3fa85f64-5717-4562-b3fc-2c963f66af75','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('3fa84a75-5728-4562-b3fc-2c963f66afa6','pending f','3fa85f64-5717-4562-b3fc-2c963f66af75','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('3fa85f64-5127-4172-b3fc-2c963f66afa6','ok','3fa85f64-5127-4562-b3fc-2c963f66afa6','3fa85f64-5127-4562-b2cd-2c963f66afa6'),('3fa85f64-5717-4562-b3fc-2c963f66afa6','Pending','00254','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('3fa85f64-5717-4562-b8bc-2c963f66afa6','ok','3fa85f64-5717-4562-b3fc-2c963f66af75','3fa85f64-5717-4562-b3fc-2c963f66afa6'),('3fa85f87-5717-4562-b8bc-2c963f66afa6','ok','3fa85f64-5717-4562-b3fc-2c963f66af75','3fa85f64-5717-4562-b3fc-2c963f66afa6');
/*!40000 ALTER TABLE `package` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe`
--

DROP TABLE IF EXISTS `recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe` (
  `id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `name` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `preparationTime` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe`
--

LOCK TABLES `recipe` WRITE;
/*!40000 ALTER TABLE `recipe` DISABLE KEYS */;
INSERT INTO `recipe` VALUES ('3fa85f00-5717-4562-b3fc-2c233f66af75','test integracion data','30'),('3fa85f22-5717-4562-b3fc-2c233f66af75','test integracion data','30'),('3fa85f64-5117-4562-b3fc-2c963f66afa6','tests','40'),('3fa85f64-5127-4562-b3fc-2c963f66afa6','test front','40'),('3fa85f64-5217-4562-b3cd-2c963f66afa6','test integracion data','40'),('3fa85f64-5217-4862-b0ad-2c963f66afa6','test integracion data','30'),('3fa85f64-5717-4562-b3fc-2c963f66afa6','Milaneza','25'),('3fa85f64-5717-4562-c3fc-2c963f66afa6','tests','40'),('3fa85f74-5198-4562-b3cd-2c963f33afa6','test integracion data','30'),('3fa85f74-5217-4562-b3cd-2c963f33afa6','test integracion data','30'),('3fa85f74-5217-4562-b3cd-2c963f66afa6','test integracion data','40'),('3fa85f74-5285-4562-b3cd-2c963f33afa6','test integracion data','30');
/*!40000 ALTER TABLE `recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'nutritionalkitchen'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-22  3:13:45
