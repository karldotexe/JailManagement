-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 04, 2025 at 07:58 PM
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
-- Table structure for table `pending_prisoners`
--

CREATE TABLE `pending_prisoners` (
  `id` int(11) NOT NULL,
  `full_name` varchar(255) DEFAULT NULL,
  `id_number` varchar(100) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `contact_number` varchar(100) DEFAULT NULL,
  `prisoner_case` text DEFAULT NULL,
  `detained_date` date DEFAULT NULL,
  `cell_number` varchar(100) DEFAULT NULL,
  `sentence_start` date DEFAULT NULL,
  `sentence_end` date DEFAULT NULL,
  `gender` varchar(50) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  `submitted_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pending_prisoners`
--
ALTER TABLE `pending_prisoners`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pending_prisoners`
--
ALTER TABLE `pending_prisoners`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
