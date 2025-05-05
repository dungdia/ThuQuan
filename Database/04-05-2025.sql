CREATE DATABASE  IF NOT EXISTS `thuquan` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `thuquan`;
-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: thuquan
-- ------------------------------------------------------
-- Server version	8.4.4

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
-- Table structure for table `chitietphieudat`
--

DROP TABLE IF EXISTS `chitietphieudat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chitietphieudat` (
  `id_phieudat` int NOT NULL,
  `id_vatdung` int NOT NULL,
  PRIMARY KEY (`id_phieudat`,`id_vatdung`),
  KEY `id_vatdung` (`id_vatdung`),
  CONSTRAINT `chitietphieudat_ibfk_1` FOREIGN KEY (`id_phieudat`) REFERENCES `phieudat` (`id`),
  CONSTRAINT `chitietphieudat_ibfk_2` FOREIGN KEY (`id_vatdung`) REFERENCES `vatdung` (`id`),
  CONSTRAINT `chitietphieudat_ibfk_3` FOREIGN KEY (`id_phieudat`) REFERENCES `phieudat` (`id`),
  CONSTRAINT `chitietphieudat_ibfk_4` FOREIGN KEY (`id_vatdung`) REFERENCES `vatdung` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chitietphieudat`
--

LOCK TABLES `chitietphieudat` WRITE;
/*!40000 ALTER TABLE `chitietphieudat` DISABLE KEYS */;
INSERT INTO `chitietphieudat` VALUES (16,6),(17,8),(18,9),(17,11),(19,13),(19,14),(22,17),(23,19);
/*!40000 ALTER TABLE `chitietphieudat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chitietphieumuon`
--

DROP TABLE IF EXISTS `chitietphieumuon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chitietphieumuon` (
  `id_phieumuon` int NOT NULL,
  `id_vatdung` int NOT NULL,
  PRIMARY KEY (`id_phieumuon`,`id_vatdung`),
  KEY `id_vatdung` (`id_vatdung`),
  CONSTRAINT `chitietphieumuon_ibfk_1` FOREIGN KEY (`id_vatdung`) REFERENCES `vatdung` (`id`),
  CONSTRAINT `chitietphieumuon_ibfk_2` FOREIGN KEY (`id_phieumuon`) REFERENCES `phieumuon` (`id`),
  CONSTRAINT `chitietphieumuon_ibfk_3` FOREIGN KEY (`id_vatdung`) REFERENCES `vatdung` (`id`),
  CONSTRAINT `chitietphieumuon_ibfk_4` FOREIGN KEY (`id_phieumuon`) REFERENCES `phieumuon` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chitietphieumuon`
--

LOCK TABLES `chitietphieumuon` WRITE;
/*!40000 ALTER TABLE `chitietphieumuon` DISABLE KEYS */;
INSERT INTO `chitietphieumuon` VALUES (4,8),(3,9),(4,11),(5,13),(2,17),(6,21);
/*!40000 ALTER TABLE `chitietphieumuon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chitietphieuphat`
--

DROP TABLE IF EXISTS `chitietphieuphat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chitietphieuphat` (
  `id_phieuphat` int NOT NULL,
  `id_vatdung` int NOT NULL,
  `ghichu` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_phieuphat`,`id_vatdung`),
  KEY `id_vatdung` (`id_vatdung`),
  CONSTRAINT `chitietphieuphat_ibfk_1` FOREIGN KEY (`id_phieuphat`) REFERENCES `phieuphat` (`id`),
  CONSTRAINT `chitietphieuphat_ibfk_2` FOREIGN KEY (`id_vatdung`) REFERENCES `vatdung` (`id`),
  CONSTRAINT `chitietphieuphat_ibfk_3` FOREIGN KEY (`id_phieuphat`) REFERENCES `phieuphat` (`id`),
  CONSTRAINT `chitietphieuphat_ibfk_4` FOREIGN KEY (`id_vatdung`) REFERENCES `vatdung` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chitietphieuphat`
--

LOCK TABLES `chitietphieuphat` WRITE;
/*!40000 ALTER TABLE `chitietphieuphat` DISABLE KEYS */;
INSERT INTO `chitietphieuphat` VALUES (1,21,'');
/*!40000 ALTER TABLE `chitietphieuphat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chitietphieutra`
--

DROP TABLE IF EXISTS `chitietphieutra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chitietphieutra` (
  `id_phieutra` int NOT NULL,
  `id_vatdung` int NOT NULL,
  `tinhtrang` enum('Nguyên vẹn','Hư hỏng','Bị Mất') NOT NULL,
  PRIMARY KEY (`id_phieutra`,`id_vatdung`),
  KEY `id_vatdung` (`id_vatdung`),
  CONSTRAINT `chitietphieutra_ibfk_1` FOREIGN KEY (`id_vatdung`) REFERENCES `vatdung` (`id`),
  CONSTRAINT `chitietphieutra_ibfk_2` FOREIGN KEY (`id_phieutra`) REFERENCES `phieutra` (`id`),
  CONSTRAINT `chitietphieutra_ibfk_3` FOREIGN KEY (`id_vatdung`) REFERENCES `vatdung` (`id`),
  CONSTRAINT `chitietphieutra_ibfk_4` FOREIGN KEY (`id_phieutra`) REFERENCES `phieutra` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chitietphieutra`
--

LOCK TABLES `chitietphieutra` WRITE;
/*!40000 ALTER TABLE `chitietphieutra` DISABLE KEYS */;
INSERT INTO `chitietphieutra` VALUES (1,6,'Nguyên vẹn'),(5,17,'Nguyên vẹn'),(6,21,'Hư hỏng');
/*!40000 ALTER TABLE `chitietphieutra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lichsu`
--

DROP TABLE IF EXISTS `lichsu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lichsu` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_thanhvien` int NOT NULL,
  `thoigianvao` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_thanhvien` (`id_thanhvien`),
  CONSTRAINT `lichsu_ibfk_1` FOREIGN KEY (`id_thanhvien`) REFERENCES `thanhvien` (`id`),
  CONSTRAINT `lichsu_ibfk_2` FOREIGN KEY (`id_thanhvien`) REFERENCES `thanhvien` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lichsu`
--

LOCK TABLES `lichsu` WRITE;
/*!40000 ALTER TABLE `lichsu` DISABLE KEYS */;
/*!40000 ALTER TABLE `lichsu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loaivatdung`
--

DROP TABLE IF EXISTS `loaivatdung`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `loaivatdung` (
  `id` int NOT NULL AUTO_INCREMENT,
  `tenloai` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loaivatdung`
--

LOCK TABLES `loaivatdung` WRITE;
/*!40000 ALTER TABLE `loaivatdung` DISABLE KEYS */;
INSERT INTO `loaivatdung` VALUES (1,'book'),(2,'device');
/*!40000 ALTER TABLE `loaivatdung` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nhanvien`
--

DROP TABLE IF EXISTS `nhanvien`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nhanvien` (
  `id` int NOT NULL AUTO_INCREMENT,
  `hoten` varchar(100) NOT NULL,
  `sodienthoai` varchar(11) NOT NULL,
  `gioitinh` enum('Nam','Nữ') NOT NULL,
  `diachi` varchar(150) NOT NULL,
  `id_taikhoan` int NOT NULL,
  `tinhtrang` enum('Đang làm việc','Đã nghỉ') NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_taikhoan` (`id_taikhoan`),
  CONSTRAINT `nhanvien_ibfk_1` FOREIGN KEY (`id_taikhoan`) REFERENCES `taikhoan` (`id`),
  CONSTRAINT `nhanvien_ibfk_2` FOREIGN KEY (`id_taikhoan`) REFERENCES `taikhoan` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nhanvien`
--

LOCK TABLES `nhanvien` WRITE;
/*!40000 ALTER TABLE `nhanvien` DISABLE KEYS */;
INSERT INTO `nhanvien` VALUES (1,'thanh thuy','0987654321','Nữ','ABC abc',14,'Đang làm việc'),(2,'Hoang Dung','0899405228','Nam','ABC abc',16,'Đang làm việc');
/*!40000 ALTER TABLE `nhanvien` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phieudat`
--

DROP TABLE IF EXISTS `phieudat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phieudat` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_thanhvien` int NOT NULL,
  `ngaydat` datetime NOT NULL,
  `tinhtrang` enum('Đã xuất phiếu','Đã xử lý','Đã huỷ','Ẩn') NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_thanhvien` (`id_thanhvien`),
  CONSTRAINT `phieudat_ibfk_1` FOREIGN KEY (`id_thanhvien`) REFERENCES `thanhvien` (`id`),
  CONSTRAINT `phieudat_ibfk_2` FOREIGN KEY (`id_thanhvien`) REFERENCES `thanhvien` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phieudat`
--

LOCK TABLES `phieudat` WRITE;
/*!40000 ALTER TABLE `phieudat` DISABLE KEYS */;
INSERT INTO `phieudat` VALUES (16,1,'2025-04-16 00:00:00','Đã xuất phiếu'),(17,1,'2025-04-16 12:00:00','Đã xử lý'),(18,1,'2025-04-16 10:12:30','Đã xử lý'),(19,1,'2025-04-17 09:32:16','Đã huỷ'),(22,14,'2025-04-17 09:45:05','Đã xử lý'),(23,1,'2025-04-29 05:00:00','Đã huỷ');
/*!40000 ALTER TABLE `phieudat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phieumuon`
--

DROP TABLE IF EXISTS `phieumuon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phieumuon` (
  `id` int NOT NULL AUTO_INCREMENT,
  `thoigianmuon` datetime NOT NULL,
  `thoigiantra` datetime NOT NULL,
  `id_thanhvien` int NOT NULL,
  `id_nhanvien` int NOT NULL,
  `tinhtrang` enum('Đã xuất phiếu','Đã trả','Đã huỷ','Ẩn') NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_nhanvien` (`id_nhanvien`),
  KEY `id_thanhvien` (`id_thanhvien`),
  CONSTRAINT `phieumuon_ibfk_1` FOREIGN KEY (`id_nhanvien`) REFERENCES `nhanvien` (`id`),
  CONSTRAINT `phieumuon_ibfk_2` FOREIGN KEY (`id_thanhvien`) REFERENCES `thanhvien` (`id`),
  CONSTRAINT `phieumuon_ibfk_3` FOREIGN KEY (`id_nhanvien`) REFERENCES `nhanvien` (`id`),
  CONSTRAINT `phieumuon_ibfk_4` FOREIGN KEY (`id_thanhvien`) REFERENCES `thanhvien` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phieumuon`
--

LOCK TABLES `phieumuon` WRITE;
/*!40000 ALTER TABLE `phieumuon` DISABLE KEYS */;
INSERT INTO `phieumuon` VALUES (2,'2025-05-02 11:55:35','2025-05-02 11:55:34',14,2,'Đã trả'),(3,'2025-05-02 11:56:25','2025-05-02 11:56:25',1,2,'Đã xuất phiếu'),(4,'2025-05-02 11:58:19','2025-05-02 11:58:18',1,2,'Đã xuất phiếu'),(5,'2025-05-03 11:03:12','2025-05-04 11:02:34',1,2,'Đã xuất phiếu'),(6,'2025-05-03 11:06:34','2025-05-03 11:06:25',14,2,'Đã trả');
/*!40000 ALTER TABLE `phieumuon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phieuphat`
--

DROP TABLE IF EXISTS `phieuphat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phieuphat` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_thanhvien` int NOT NULL,
  `lydo` varchar(255) NOT NULL,
  `mucphat` varchar(100) NOT NULL,
  `tinhtrang` enum('Đã xuất phiếu','Đã xử lý','Đã huỷ','Ẩn') NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_thanhvien` (`id_thanhvien`),
  CONSTRAINT `phieuphat_ibfk_1` FOREIGN KEY (`id_thanhvien`) REFERENCES `thanhvien` (`id`),
  CONSTRAINT `phieuphat_ibfk_2` FOREIGN KEY (`id_thanhvien`) REFERENCES `thanhvien` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phieuphat`
--

LOCK TABLES `phieuphat` WRITE;
/*!40000 ALTER TABLE `phieuphat` DISABLE KEYS */;
INSERT INTO `phieuphat` VALUES (1,14,'Trã trễ; Làm hỏng vật dụng; ','','Đã xuất phiếu');
/*!40000 ALTER TABLE `phieuphat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phieutra`
--

DROP TABLE IF EXISTS `phieutra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phieutra` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_thanhvien` int NOT NULL,
  `id_nhanvien` int NOT NULL,
  `thoigiantra` datetime NOT NULL,
  `tinhtrang` enum('Đã xuất phiếu','Đã huỷ','Trễ','Ẩn') NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_thanhvien` (`id_thanhvien`),
  KEY `id_nhanvien` (`id_nhanvien`),
  CONSTRAINT `phieutra_ibfk_1` FOREIGN KEY (`id_thanhvien`) REFERENCES `thanhvien` (`id`),
  CONSTRAINT `phieutra_ibfk_2` FOREIGN KEY (`id_nhanvien`) REFERENCES `nhanvien` (`id`),
  CONSTRAINT `phieutra_ibfk_3` FOREIGN KEY (`id_thanhvien`) REFERENCES `thanhvien` (`id`),
  CONSTRAINT `phieutra_ibfk_4` FOREIGN KEY (`id_nhanvien`) REFERENCES `nhanvien` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phieutra`
--

LOCK TABLES `phieutra` WRITE;
/*!40000 ALTER TABLE `phieutra` DISABLE KEYS */;
INSERT INTO `phieutra` VALUES (1,1,1,'2025-04-15 16:04:03','Đã xuất phiếu'),(5,14,2,'2025-05-04 08:23:12','Đã xuất phiếu'),(6,14,2,'2025-05-04 09:47:14','Đã xuất phiếu');
/*!40000 ALTER TABLE `phieutra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `taikhoan`
--

DROP TABLE IF EXISTS `taikhoan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `taikhoan` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(100) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `ngaythamgia` datetime NOT NULL,
  `vaitro` int NOT NULL DEFAULT '0',
  `tinhtrang` enum('Hoạt động','Đã bị khoá') NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `taikhoan`
--

LOCK TABLES `taikhoan` WRITE;
/*!40000 ALTER TABLE `taikhoan` DISABLE KEYS */;
INSERT INTO `taikhoan` VALUES (1,'Duc Doan Qua Dep Trai','$2a$12$DaFFfBx69A9DCSC.xjnniudAhuc/74Rmhl5tRjYzVwLJQXtTa90Hi','duc@gmail.com','2025-04-01 00:00:00',0,'Hoạt động'),(12,'Thanh Thuy','$2a$12$breR9.GQk9mumqnEDSQbu.Dspv5PLzRAbYAHhyjlyqaM2Mj3laY/e','thuy@gmail.com','2025-04-04 00:00:00',0,'Hoạt động'),(13,'Duc','$2a$12$51e/wxXDWSNmAsgbLKvICeicXUv3gL4RN25.f6FZJMQFe6N7N8J5C','dduc1171@gmail.com','2025-04-08 00:00:00',0,'Hoạt động'),(14,'Thanh Thuy','$2a$12$DaFFfBx69A9DCSC.xjnniudAhuc/74Rmhl5tRjYzVwLJQXtTa90Hi','thuy1@gmail.com','2025-04-13 16:03:22',1,'Hoạt động'),(15,'dung@gmail.com','$2a$12$OUcnnLlEzqZq.98xi8IGJOUXokJikPQlx9AGkgGpOIy/1uAAtgexG','a@gmail.com','2025-04-17 09:38:43',0,'Hoạt động'),(16,'dungdia','$2a$12$DaFFfBx69A9DCSC.xjnniudAhuc/74Rmhl5tRjYzVwLJQXtTa90Hi','dung@gmail.com','2025-04-01 00:00:00',1,'Hoạt động');
/*!40000 ALTER TABLE `taikhoan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `thanhvien`
--

DROP TABLE IF EXISTS `thanhvien`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `thanhvien` (
  `id` int NOT NULL AUTO_INCREMENT,
  `hoten` varchar(100) NOT NULL,
  `sodienthoai` varchar(11) NOT NULL,
  `id_taikhoan` int NOT NULL,
  `tinhtrang` enum('Hoạt động','Đã bị khoá') NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_taikhoan` (`id_taikhoan`),
  CONSTRAINT `thanhvien_ibfk_1` FOREIGN KEY (`id_taikhoan`) REFERENCES `taikhoan` (`id`),
  CONSTRAINT `thanhvien_ibfk_2` FOREIGN KEY (`id_taikhoan`) REFERENCES `taikhoan` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `thanhvien`
--

LOCK TABLES `thanhvien` WRITE;
/*!40000 ALTER TABLE `thanhvien` DISABLE KEYS */;
INSERT INTO `thanhvien` VALUES (1,'minh duc hih ihi','0999999999',1,'Hoạt động'),(12,'Dũng 124124','0899304226',12,'Hoạt động'),(13,'','',13,'Hoạt động'),(14,'abc','0897627362',15,'Hoạt động');
/*!40000 ALTER TABLE `thanhvien` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vatdung`
--

DROP TABLE IF EXISTS `vatdung`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vatdung` (
  `id` int NOT NULL AUTO_INCREMENT,
  `tenvatdung` varchar(100) NOT NULL,
  `hinhanh` varchar(255) NOT NULL,
  `mota` varchar(255) DEFAULT NULL,
  `id_loaivatdung` int NOT NULL,
  `tinhtrang` enum('Chưa mượn','Đang mượn','Đã đặt','Bị hỏng','Ẩn') NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_loaivatdung` (`id_loaivatdung`),
  CONSTRAINT `vatdung_ibfk_1` FOREIGN KEY (`id_loaivatdung`) REFERENCES `loaivatdung` (`id`),
  CONSTRAINT `vatdung_ibfk_2` FOREIGN KEY (`id_loaivatdung`) REFERENCES `loaivatdung` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vatdung`
--

LOCK TABLES `vatdung` WRITE;
/*!40000 ALTER TABLE `vatdung` DISABLE KEYS */;
INSERT INTO `vatdung` VALUES (3,'sách 1','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','ngày xưa có một chuện tình giữa nam và nữ',1,'Đang mượn'),(4,'sách 2','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','ngày xưa có một chuện tình',1,'Bị hỏng'),(5,'sách 3','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','ngày xưa có một chuện tình',1,'Ẩn'),(6,'sách 4','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','ngày xưa có một chuện tình',1,'Đã đặt'),(7,'sách 5','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','ngày xưa có một chuện tình',1,'Ẩn'),(8,'sách 6','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','ngày xưa có một chuện tình',1,'Đang mượn'),(9,'sách 1','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','ngày xưa có một chuện tình',1,'Đang mượn'),(10,'sách 1','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','ngày xưa có một chuện tình',1,'Ẩn'),(11,'sách 1','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','ngày xưa có một chuện tình',1,'Đang mượn'),(12,'sách 10','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','ngày xưa có một chuện tình',1,'Đang mượn'),(13,'sách 11','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','ngày xưa có một chuện tình',1,'Đang mượn'),(14,'thiết bị 1','https://hanoicomputercdn.com/media/product/65015_thiet_bi_chuyen_doi_hinh_anh_elgato_hd60x__1_.jpg','Thiết bị chuyển đổi hình ảnh Elgato HD60X',2,'Chưa mượn'),(15,'thiết bị 2 thiết bị 2 thiết bị 2 thiết bị 2 thiết bị 2 thiết bị 2','https://hanoicomputercdn.com/media/product/65015_thiet_bi_chuyen_doi_hinh_anh_elgato_hd60x__1_.jpg','Thiết bị chuyển đổi hình ảnh Elgato HD60X',2,'Bị hỏng'),(16,'thiết bị 3','https://hanoicomputercdn.com/media/product/65015_thiet_bi_chuyen_doi_hinh_anh_elgato_hd60x__1_.jpg','Thiết bị chuyển đổi hình ảnh Elgato HD60X',2,'Đang mượn'),(17,'thiết bị 4','https://hanoicomputercdn.com/media/product/65015_thiet_bi_chuyen_doi_hinh_anh_elgato_hd60x__1_.jpg','Thiết bị chuyển đổi hình ảnh Elgato HD60X',2,'Chưa mượn'),(18,'thiết bị 5','https://hanoicomputercdn.com/media/product/65015_thiet_bi_chuyen_doi_hinh_anh_elgato_hd60x__1_.jpg','Thiết bị chuyển đổi hình ảnh Elgato HD60X',2,'Ẩn'),(19,'sachhhh ','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','sach hayyyyy',1,'Đã đặt'),(20,'thiết bị ','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','thiết bị hayyyyy',2,'Chưa mượn'),(21,'thiết bị pro','https://nld.mediacdn.vn/thumb_w/698/291774122806476800/2023/6/19/ngay-xua-co-1-chuyen-tinh-1-6365-16871692447131238194593.jpg','thiết bị hayyyyy',2,'Bị hỏng');
/*!40000 ALTER TABLE `vatdung` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-04 21:52:55
