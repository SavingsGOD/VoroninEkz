CREATE DATABASE  IF NOT EXISTS `db03` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `db03`;
-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: 10.207.106.12    Database: db03
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
-- Table structure for table `materialproducts`
--

DROP TABLE IF EXISTS `materialproducts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `materialproducts` (
  `idmaterialproducts` int NOT NULL AUTO_INCREMENT,
  `materialtype` int NOT NULL,
  PRIMARY KEY (`idmaterialproducts`,`materialtype`),
  KEY `fk_materialtype_idx` (`materialtype`),
  CONSTRAINT `fk_materialtype` FOREIGN KEY (`materialtype`) REFERENCES `materialtype` (`idmaterialtype`),
  CONSTRAINT `fk_products` FOREIGN KEY (`idmaterialproducts`) REFERENCES `products` (`article`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materialproducts`
--

LOCK TABLES `materialproducts` WRITE;
/*!40000 ALTER TABLE `materialproducts` DISABLE KEYS */;
/*!40000 ALTER TABLE `materialproducts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materialtype`
--

DROP TABLE IF EXISTS `materialtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `materialtype` (
  `idmaterialtype` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `defect_rate` decimal(15,5) NOT NULL,
  PRIMARY KEY (`idmaterialtype`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materialtype`
--

LOCK TABLES `materialtype` WRITE;
/*!40000 ALTER TABLE `materialtype` DISABLE KEYS */;
INSERT INTO `materialtype` VALUES (6,'Тип материала 1',0.00100),(7,'Тип материала 2',0.00950),(8,'Тип материала 3',0.00280),(9,'Тип материала 4',0.00550),(10,'Тип материала 5',0.00340);
/*!40000 ALTER TABLE `materialtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `partnerproducts`
--

DROP TABLE IF EXISTS `partnerproducts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `partnerproducts` (
  `partnerproductsid` int NOT NULL AUTO_INCREMENT,
  `date` date NOT NULL,
  `product` int NOT NULL,
  `partner` int NOT NULL,
  `count` decimal(10,0) NOT NULL,
  PRIMARY KEY (`partnerproductsid`),
  KEY `fk_product_idx` (`product`),
  KEY `fk_partner_idx` (`partner`),
  CONSTRAINT `fk_partner` FOREIGN KEY (`partner`) REFERENCES `partners` (`idpartners`),
  CONSTRAINT `fk_product` FOREIGN KEY (`product`) REFERENCES `products` (`article`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partnerproducts`
--

LOCK TABLES `partnerproducts` WRITE;
/*!40000 ALTER TABLE `partnerproducts` DISABLE KEYS */;
INSERT INTO `partnerproducts` VALUES (1,'2023-03-23',8758385,1,15500),(2,'2023-03-24',7750282,1,12350),(3,'2023-03-25',7028748,1,37400),(4,'2023-03-26',8858958,2,35000),(5,'2023-03-27',5012543,2,1250),(6,'2023-03-28',7750282,2,1000),(7,'2023-03-29',8758385,2,7550),(8,'2023-03-30',8758385,3,7250),(9,'2023-03-31',8858958,3,2500),(10,'2023-04-01',7028748,4,59050),(11,'2023-04-02',7750282,4,37200),(12,'2023-04-03',5012543,4,4500),(13,'2023-04-04',7750282,5,50000),(14,'2023-04-05',7028748,5,670000),(15,'2023-04-06',8758385,5,35000),(16,'2023-04-07',8858958,5,25000);
/*!40000 ALTER TABLE `partnerproducts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `partners`
--

DROP TABLE IF EXISTS `partners`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `partners` (
  `idpartners` int NOT NULL AUTO_INCREMENT,
  `partnertypeid` int NOT NULL,
  `name` varchar(45) NOT NULL,
  `director` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `address` varchar(100) NOT NULL,
  `rating` varchar(5) NOT NULL,
  `INN` varchar(10) NOT NULL,
  PRIMARY KEY (`idpartners`),
  KEY `fddsf_idx` (`partnertypeid`),
  CONSTRAINT `partnertype` FOREIGN KEY (`partnertypeid`) REFERENCES `partnerstype` (`idpartnerstype`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partners`
--

LOCK TABLES `partners` WRITE;
/*!40000 ALTER TABLE `partners` DISABLE KEYS */;
INSERT INTO `partners` VALUES (1,1,'База Строитель','Иванова Александра Ивановна','aleksandraivanova@ml.ru','493 123 45 67','652050, Кемеровская область, город Юрга, ул. Лесная, 15','7','2222455179'),(2,2,'Паркет 29','Петров Василий Петрович','vppetrov@vl.ru','987 123 56 78','164500, Архангельская область, город Северодвинск, ул. Строителей, 18','7','3333888520'),(3,3,'Стройсервис','Соловьев Андрей Николаевич','ansolovev@st.ru','812 223 32 00','188910, Ленинградская область, город Приморск, ул. Парковая, 21','7','4440391035'),(4,4,'Ремонт и отделка','Воробьева Екатерина Валерьевна','ekaterina.vorobeva@ml.ru','444 222 33 11','143960, Московская область, город Реутов, ул. Свободы, 51','5','1111520857'),(5,1,'МонтажПро','Степанов Степан Сергеевич','stepanov@stepan.ru','912 888 33 33','309500, Белгородская область, город Старый Оскол, ул. Рабочая, 122','10','5552431140');
/*!40000 ALTER TABLE `partners` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `partnerstype`
--

DROP TABLE IF EXISTS `partnerstype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `partnerstype` (
  `idpartnerstype` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`idpartnerstype`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partnerstype`
--

LOCK TABLES `partnerstype` WRITE;
/*!40000 ALTER TABLE `partnerstype` DISABLE KEYS */;
INSERT INTO `partnerstype` VALUES (1,'ЗАО'),(2,'ООО'),(3,'ПАО'),(4,'ОАО');
/*!40000 ALTER TABLE `partnerstype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `article` int NOT NULL AUTO_INCREMENT,
  `name` varchar(70) NOT NULL,
  `productstype` int NOT NULL,
  `mincost` decimal(7,3) NOT NULL,
  PRIMARY KEY (`article`),
  KEY `productype_idx` (`productstype`),
  CONSTRAINT `productype` FOREIGN KEY (`productstype`) REFERENCES `productstype` (`idproductstype`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8858959 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (5012543,'Пробковое напольное клеевое покрытие 32 класс 4 мм',3,5450.590),(7028748,'Ламинат Дуб серый 32 класс 8 мм с фаской',2,3890.410),(7750282,'Ламинат Дуб дымчато-белый 33 класс 12 мм',2,1799.330),(8758385,'Паркетная доска Ясень темный однополосная 14 мм',1,4456.900),(8858958,'Инженерная доска Дуб Французская елка однополосная 12 мм',1,7330.990);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productstype`
--

DROP TABLE IF EXISTS `productstype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productstype` (
  `idproductstype` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `coefficient` decimal(45,2) NOT NULL,
  PRIMARY KEY (`idproductstype`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productstype`
--

LOCK TABLES `productstype` WRITE;
/*!40000 ALTER TABLE `productstype` DISABLE KEYS */;
INSERT INTO `productstype` VALUES (1,'Ламинат',2.35),(2,'Массивная доска',5.15),(3,'Паркетная доска',4.34),(4,'Пробковое покрытие',1.50);
/*!40000 ALTER TABLE `productstype` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-01  8:52:57
