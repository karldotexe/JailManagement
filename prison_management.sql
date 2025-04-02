-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 30, 2025 at 04:23 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `prison_management`
--

-- --------------------------------------------------------

--
-- Table structure for table `prisoners`
--

CREATE TABLE `prisoners` (
  `id` int(11) NOT NULL,
  `full_name` varchar(255) NOT NULL,
  `id_number` varchar(50) NOT NULL,
  `age` int(11) NOT NULL,
  `contact_number` varchar(20) DEFAULT NULL,
  `prisoner_case` text NOT NULL,
  `detained_date` date NOT NULL,
  `cell_number` varchar(50) DEFAULT NULL,
  `sentence_start` date DEFAULT NULL,
  `sentence_end` date DEFAULT NULL,
  `gender` enum('Male','Female','Other') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `prisoners`
--

INSERT INTO `prisoners` (`id`, `full_name`, `id_number`, `age`, `contact_number`, `prisoner_case`, `detained_date`, `cell_number`, `sentence_start`, `sentence_end`, `gender`) VALUES
(1, 'Female', '123456789', 41, '09876543234', 'Robbery BOBa', '2025-03-28', 'lalalawefsdf', '2025-03-21', '2035-01-24', 'Other'),
(3, 'Ady', '32433435465456575676', 23, '09873234556', 'Nanagasad', '2025-03-09', 'KJASsadDasdJK', '2025-02-26', '1954-03-25', 'Male'),
(4, 'Althea Soriano', '3435435', 43, '09876543212', 'Namababae', '2025-12-09', 'asdewrert', '2025-03-04', '2046-04-04', 'Other'),
(5, 'JEJEJE', '99843892', 55, '32453465675', 'Naglakad', '2025-03-20', 'asdasd', '2025-03-26', '2025-07-31', 'Female'),
(6, 'weadsda', '325345', 32, '32142354', '324rdfgfhe56trgf', '2025-03-20', '14/02/2025', '2025-01-29', '2025-02-27', 'Male'),
(7, 'sdfsdf', '4354645', 122, '675654675', '645rtgfbgfhg', '2025-03-30', 'df546434', '2025-03-30', '2025-03-30', 'Female'),
(8, 'Karl Perez', '43547567654356754345', 122, '45456578796', 'Nambully', '2025-03-30', '34B', '2025-03-06', '2025-05-22', 'Female');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `prisoners`
--
ALTER TABLE `prisoners`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_number` (`id_number`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `prisoners`
--
ALTER TABLE `prisoners`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
