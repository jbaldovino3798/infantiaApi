-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: infantia
-- ------------------------------------------------------
-- Server version	8.0.32

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
-- Table structure for table `resptempusu`
--

DROP TABLE IF EXISTS `resptempusu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resptempusu` (
  `cedulaCuidador` int NOT NULL,
  `idTemporalidad` int NOT NULL,
  `idValoracion` int NOT NULL,
  `idPregunta` int NOT NULL,
  `idRespuesta` int NOT NULL,
  `fecha` varchar(45) NOT NULL,
  PRIMARY KEY (`cedulaCuidador`,`idTemporalidad`,`idValoracion`,`idPregunta`,`idRespuesta`),
  KEY `fk_Respuesta_has_Temporalidad_Temporalidad1_idx` (`idTemporalidad`),
  KEY `fk_RespTempUsu_Valoracion1_idx` (`idValoracion`),
  KEY `fk_RespTempUsu_Cuidador1_idx` (`cedulaCuidador`),
  KEY `fk_RespTempUsu_Respuesta1_idx` (`idRespuesta`,`idPregunta`),
  CONSTRAINT `fk_RespTempUsu_Cuidador1` FOREIGN KEY (`cedulaCuidador`) REFERENCES `cuidador` (`cedulaCuidador`),
  CONSTRAINT `fk_RespTempUsu_Respuesta1` FOREIGN KEY (`idRespuesta`, `idPregunta`) REFERENCES `respuesta` (`idRespuesta`, `idPregunta`),
  CONSTRAINT `fk_RespTempUsu_Valoracion1` FOREIGN KEY (`idValoracion`) REFERENCES `valoracion` (`idValoracion`),
  CONSTRAINT `fk_Respuesta_has_Temporalidad_Temporalidad1` FOREIGN KEY (`idTemporalidad`) REFERENCES `temporalidad` (`idTemporalidad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resptempusu`
--

LOCK TABLES `resptempusu` WRITE;
/*!40000 ALTER TABLE `resptempusu` DISABLE KEYS */;
/*!40000 ALTER TABLE `resptempusu` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-25 15:58:40
