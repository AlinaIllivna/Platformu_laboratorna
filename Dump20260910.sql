-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: library_db
-- ------------------------------------------------------
-- Server version	9.3.0

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
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `books` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(150) NOT NULL,
  `Author` varchar(100) NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

LOCK TABLES `books` WRITE;
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` VALUES (1,'Кобзар','Тарас Шевченко',350.00),(2,'Захар Беркут','Іван Франко',280.00),(3,'Лісова пісня','Леся Українка',220.00),(4,'Тіні забутих предків','Михайло Коцюбинський',260.00),(5,'Теорія алгоритмів','Дмитро Кнут',600.00),(6,'Чистий код','Роберт Мартін',750.00),(7,'Паттерни проектування','Еріх Гамма',800.00);
/*!40000 ALTER TABLE `books` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loans`
--

DROP TABLE IF EXISTS `loans`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `loans` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `ReaderID` int DEFAULT NULL,
  `BookID` int DEFAULT NULL,
  `IssueDate` date NOT NULL,
  `ReturnDate` date DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ReaderID` (`ReaderID`),
  KEY `BookID` (`BookID`),
  CONSTRAINT `loans_ibfk_1` FOREIGN KEY (`ReaderID`) REFERENCES `readers` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `loans_ibfk_2` FOREIGN KEY (`BookID`) REFERENCES `books` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loans`
--

LOCK TABLES `loans` WRITE;
/*!40000 ALTER TABLE `loans` DISABLE KEYS */;
INSERT INTO `loans` VALUES (1,1,1,'2026-02-01','2026-02-15'),(2,1,2,'2026-02-10',NULL),(3,1,5,'2026-02-18',NULL),(4,2,2,'2026-01-15','2026-02-01'),(5,2,3,'2026-02-05',NULL),(6,3,3,'2026-02-01',NULL),(7,3,4,'2026-02-12',NULL),(8,3,6,'2026-02-15','2026-04-21'),(9,3,7,'2026-02-20',NULL),(10,4,4,'2026-01-20','2026-02-10'),(11,4,5,'2026-02-11',NULL),(12,5,5,'2026-02-03',NULL),(13,5,6,'2026-02-14',NULL),(14,5,1,'2026-02-22','2026-04-01'),(15,6,6,'2026-01-10','2026-01-25'),(16,6,7,'2026-02-08','2026-06-23'),(17,7,7,'2026-02-02',NULL),(18,7,1,'2026-02-13','2026-03-23'),(19,7,2,'2026-02-25',NULL);
/*!40000 ALTER TABLE `loans` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `readers`
--

DROP TABLE IF EXISTS `readers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `readers` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `TicketNumber` varchar(20) NOT NULL,
  `FullName` varchar(100) NOT NULL,
  `Address` varchar(200) DEFAULT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `BirthDate` date DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `TicketNumber` (`TicketNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `readers`
--

LOCK TABLES `readers` WRITE;
/*!40000 ALTER TABLE `readers` DISABLE KEYS */;
INSERT INTO `readers` VALUES (1,'RD-001','Семенюк Тарас Степанович','м. Чернівці, вул. Університетська, 23','+380971112233','1995-03-09'),(2,'RD-002','Токарчук Степан Васильович','м. Чернівці, вул. Франка, 15','+380932223344','1998-08-27'),(3,'RD-003','Бойко Аліна Іллівна','м. Чернівці, вул. Лесі, 10','+380503334455','2006-02-25'),(4,'RD-004','Перепелиця Інна Іванівна','м. Чернівці, вул. Сонячна, 5','+380674445566','1992-09-17'),(5,'RD-005','Думич Микола Ярославович','м. Чернівці, вул. Садова, 12','+380635556677','1990-12-03'),(6,'RD-006','Літовський Владислав Сергійович','м. Чернівці, вул. Гоголя, 4','+380986667788','2001-11-25'),(7,'RD-007','Карпова Евеліна Сергіївна','м. Чернівці, вул. Польова, 8','+380997778899','1997-01-06');
/*!40000 ALTER TABLE `readers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-09-10 10:38:41
