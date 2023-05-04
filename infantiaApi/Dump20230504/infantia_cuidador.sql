-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: infantia
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cuidador`
--

DROP TABLE IF EXISTS `cuidador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cuidador` (
  `cedulaCuidador` int NOT NULL,
  `nombreCuidador` varchar(45) NOT NULL,
  `edad` varchar(45) NOT NULL,
  `direccion` varchar(45) NOT NULL,
  `barrio` varchar(45) NOT NULL,
  `estrato` varchar(45) NOT NULL,
  `telefono` varchar(45) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `estadoCivil` varchar(45) NOT NULL,
  `parejaDiferente` varchar(45) NOT NULL,
  `grupoEtnico` varchar(45) NOT NULL,
  `nivelEducativo` varchar(45) NOT NULL,
  `ocupacion` varchar(45) NOT NULL,
  `nombreNiño` varchar(45) NOT NULL,
  `parentesco` varchar(45) NOT NULL,
  `idPerfil` int NOT NULL,
  PRIMARY KEY (`cedulaCuidador`,`idPerfil`),
  KEY `fk_Cuidador_Perfil1_idx` (`idPerfil`),
  CONSTRAINT `fk_Cuidador_Perfil1` FOREIGN KEY (`idPerfil`) REFERENCES `perfil` (`idPerfil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuidador`
--

LOCK TABLES `cuidador` WRITE;
/*!40000 ALTER TABLE `cuidador` DISABLE KEYS */;
INSERT INTO `cuidador` VALUES (13515616,'asdfasdf','1','asdfasdfasdf','asdfasdfas','1','15616161717','asdfasf@gmail.com','asdfasdfasdf','1','asdfasgagh','asdfasdga','asdfasdzxcxczxcz','zxcvzxcvzxcv','zxvbzbv',21),(111111111,'asdfasagzxc','11','asdfasgxcgz','asgasgasg','1','11111111111','asdf@gmail.com','asdfasdfasdfas','1','zxcvzxcvxzcv','zxcvzxcvxzc','bzxcvbvb','nxbnxcbn','xcnbxcn',12);
/*!40000 ALTER TABLE `cuidador` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-04 13:01:20
