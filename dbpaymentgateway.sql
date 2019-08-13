-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 13, 2019 at 11:15 PM
-- Server version: 10.3.16-MariaDB
-- PHP Version: 7.3.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbpaymentgateway`
--

-- --------------------------------------------------------

--
-- Table structure for table `transaction_history`
--

CREATE TABLE `transaction_history` (
  `TransactionId` int(11) NOT NULL,
  `CardNumber` varchar(60) DEFAULT NULL,
  `TransactionDate` datetime DEFAULT NULL,
  `PurchaseAmount` decimal(16,2) DEFAULT NULL,
  `PurchaseDescription` varchar(60) DEFAULT NULL,
  `TransactionStatus` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaction_history`
--

INSERT INTO `transaction_history` (`TransactionId`, `CardNumber`, `TransactionDate`, `PurchaseAmount`, `PurchaseDescription`, `TransactionStatus`) VALUES
(1, '2407199449917042', '2019-08-09 00:00:00', '15220.01', 'Kenneth Cole Watch from MIKADO store', 'Success'),
(2, '2407199449917042', '2019-08-12 20:46:09', '-1.00', 'T-Shirt', 'Success'),
(3, '2407199449917042', '2019-08-12 20:47:04', '100.00', 'T-Shirt', 'Success'),
(4, '2407199449917042', '2019-08-12 20:48:12', '100.00', 'T-Shirt', 'Success'),
(5, '2407199449917042', '2019-08-12 20:51:29', '1000.00', 'T-Shirt', 'Success'),
(6, '2407199449917042', '2019-08-13 23:06:00', '549.99', 'Pearl White Shirt', 'Success'),
(7, '2407199449917042', '2019-08-14 00:20:04', '549.99', 'Pearl White Shirt', 'Success');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `userId` int(11) NOT NULL,
  `FirstName` varchar(60) DEFAULT NULL,
  `LastName` varchar(60) DEFAULT NULL,
  `Email` varchar(60) DEFAULT NULL,
  `Appid` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userId`, `FirstName`, `LastName`, `Email`, `Appid`) VALUES
(1, 'Girjanand', 'Khadun', 'gir_girish@live.com', '0c56f2c2-5457-4a32-ba2b-971afdb9f99e');

-- --------------------------------------------------------

--
-- Table structure for table `user_client`
--

CREATE TABLE `user_client` (
  `IdentityNumber` varchar(15) NOT NULL,
  `FirstName` varchar(60) DEFAULT NULL,
  `LastName` varchar(60) DEFAULT NULL,
  `DateOfBirth` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_client`
--

INSERT INTO `user_client` (`IdentityNumber`, `FirstName`, `LastName`, `DateOfBirth`) VALUES
('K2407944608215', 'Girjanand', 'Khadun', '1994-07-24');

-- --------------------------------------------------------

--
-- Table structure for table `user_client_card_info`
--

CREATE TABLE `user_client_card_info` (
  `CardNumber` varchar(60) NOT NULL,
  `IdentityNumber` varchar(15) DEFAULT NULL,
  `CardType` varchar(10) DEFAULT NULL,
  `ExpirationDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_client_card_info`
--

INSERT INTO `user_client_card_info` (`CardNumber`, `IdentityNumber`, `CardType`, `ExpirationDate`) VALUES
('2407199449917042', 'K2407944608215', 'Credit', '2030-12-31');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `transaction_history`
--
ALTER TABLE `transaction_history`
  ADD PRIMARY KEY (`TransactionId`),
  ADD KEY `CardNumber` (`CardNumber`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userId`);

--
-- Indexes for table `user_client`
--
ALTER TABLE `user_client`
  ADD PRIMARY KEY (`IdentityNumber`);

--
-- Indexes for table `user_client_card_info`
--
ALTER TABLE `user_client_card_info`
  ADD PRIMARY KEY (`CardNumber`),
  ADD KEY `IdentityNumber` (`IdentityNumber`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `transaction_history`
--
ALTER TABLE `transaction_history`
  MODIFY `TransactionId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `userId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `transaction_history`
--
ALTER TABLE `transaction_history`
  ADD CONSTRAINT `transaction_history_ibfk_1` FOREIGN KEY (`CardNumber`) REFERENCES `user_client_card_info` (`CardNumber`);

--
-- Constraints for table `user_client_card_info`
--
ALTER TABLE `user_client_card_info`
  ADD CONSTRAINT `user_card_info_ibfk_1` FOREIGN KEY (`IdentityNumber`) REFERENCES `user_client` (`IdentityNumber`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
