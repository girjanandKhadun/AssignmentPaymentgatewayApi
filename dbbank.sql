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
-- Database: `dbbank`
--

-- --------------------------------------------------------

--
-- Table structure for table `bank_transaction_history`
--

CREATE TABLE `bank_transaction_history` (
  `TransactionId` varchar(60) NOT NULL,
  `CardNumber` varchar(60) DEFAULT NULL,
  `TransactionDate` datetime DEFAULT NULL,
  `TransactionAmount` decimal(16,2) DEFAULT NULL,
  `TransactionType` varchar(60) DEFAULT NULL,
  `TransactionStatus` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bank_transaction_history`
--

INSERT INTO `bank_transaction_history` (`TransactionId`, `CardNumber`, `TransactionDate`, `TransactionAmount`, `TransactionType`, `TransactionStatus`) VALUES
('0829e8ab-a03e-4543-beb7-6f7a14bd466b', '2407199449917042', '2019-08-12 20:46:08', '-1.00', 'Debit', 'Success'),
('6bbeb604-e6a5-4fac-9a38-efd9f897a772', '2407199449917042', '2019-08-12 20:43:14', '12.00', 'Debit', 'Success'),
('7cc19b73-6faa-4b4e-ae81-676572f232a2', '2407199449917042', '2019-08-12 20:47:04', '100.00', 'Debit', 'Success'),
('8cf38bea-1419-47e3-a254-1e0559a403fc', '2407199449917042', '2019-08-12 20:48:12', '100.00', 'Debit', 'Success'),
('a86dbda7-c944-4a27-b38f-7a584e790682', '2407199449917042', '2019-08-13 23:06:00', '549.99', 'Debit', 'Success'),
('bd8b6622-da48-4c13-90e2-7f9c833380b8', '2407199449917042', '2019-08-14 00:20:04', '549.99', 'Debit', 'Success'),
('d4adb26f-2ecd-460d-a1d8-f31097df9a54', '2407199449917042', '2019-08-12 20:51:29', '1000.00', 'Debit', 'Success');

-- --------------------------------------------------------

--
-- Table structure for table `bank_user`
--

CREATE TABLE `bank_user` (
  `userId` int(11) NOT NULL,
  `FirstName` varchar(60) DEFAULT NULL,
  `LastName` varchar(60) DEFAULT NULL,
  `Email` varchar(60) DEFAULT NULL,
  `Appid` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bank_user`
--

INSERT INTO `bank_user` (`userId`, `FirstName`, `LastName`, `Email`, `Appid`) VALUES
(1, 'Girjanand', 'Khadun', 'gir_girish@live.com', '593805db-4f40-4f0a-b1c7-93610989d9a9');

-- --------------------------------------------------------

--
-- Table structure for table `bank_user_client`
--

CREATE TABLE `bank_user_client` (
  `IdentityNumber` varchar(15) NOT NULL,
  `FirstName` varchar(60) DEFAULT NULL,
  `LastName` varchar(60) DEFAULT NULL,
  `DateOfBirth` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bank_user_client`
--

INSERT INTO `bank_user_client` (`IdentityNumber`, `FirstName`, `LastName`, `DateOfBirth`) VALUES
('K2407944608215', 'Girjanand', 'Khadun', '1994-07-24');

-- --------------------------------------------------------

--
-- Table structure for table `bank_user_client_account`
--

CREATE TABLE `bank_user_client_account` (
  `AccountNumber` varchar(60) NOT NULL,
  `IdentityNumber` varchar(15) DEFAULT NULL,
  `OpeningDate` date DEFAULT NULL,
  `AccountType` varchar(10) DEFAULT NULL,
  `AvailableAmount` decimal(15,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bank_user_client_account`
--

INSERT INTO `bank_user_client_account` (`AccountNumber`, `IdentityNumber`, `OpeningDate`, `AccountType`, `AvailableAmount`) VALUES
('100016484', 'K2407944608215', '2019-08-09', 'Current', '997677.02');

-- --------------------------------------------------------

--
-- Table structure for table `bank_user_client_card_info`
--

CREATE TABLE `bank_user_client_card_info` (
  `CardNumber` varchar(60) NOT NULL,
  `AccountNumber` varchar(60) DEFAULT NULL,
  `CardType` varchar(10) DEFAULT NULL,
  `ExpirationDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bank_user_client_card_info`
--

INSERT INTO `bank_user_client_card_info` (`CardNumber`, `AccountNumber`, `CardType`, `ExpirationDate`) VALUES
('2407199449917042', '100016484', 'Credit', '2030-12-30');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bank_transaction_history`
--
ALTER TABLE `bank_transaction_history`
  ADD PRIMARY KEY (`TransactionId`),
  ADD KEY `CardNumber` (`CardNumber`);

--
-- Indexes for table `bank_user`
--
ALTER TABLE `bank_user`
  ADD PRIMARY KEY (`userId`);

--
-- Indexes for table `bank_user_client`
--
ALTER TABLE `bank_user_client`
  ADD PRIMARY KEY (`IdentityNumber`);

--
-- Indexes for table `bank_user_client_account`
--
ALTER TABLE `bank_user_client_account`
  ADD PRIMARY KEY (`AccountNumber`),
  ADD KEY `IdentityNumber` (`IdentityNumber`);

--
-- Indexes for table `bank_user_client_card_info`
--
ALTER TABLE `bank_user_client_card_info`
  ADD PRIMARY KEY (`CardNumber`),
  ADD KEY `AccountNumber` (`AccountNumber`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bank_user`
--
ALTER TABLE `bank_user`
  MODIFY `userId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bank_transaction_history`
--
ALTER TABLE `bank_transaction_history`
  ADD CONSTRAINT `transaction_history_ibfk_1` FOREIGN KEY (`CardNumber`) REFERENCES `bank_user_client_card_info` (`CardNumber`);

--
-- Constraints for table `bank_user_client_account`
--
ALTER TABLE `bank_user_client_account`
  ADD CONSTRAINT `user_client_account_ibfk_1` FOREIGN KEY (`IdentityNumber`) REFERENCES `bank_user_client` (`IdentityNumber`);

--
-- Constraints for table `bank_user_client_card_info`
--
ALTER TABLE `bank_user_client_card_info`
  ADD CONSTRAINT `user_client_card_info_ibfk_1` FOREIGN KEY (`AccountNumber`) REFERENCES `bank_user_client_account` (`AccountNumber`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
