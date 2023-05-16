-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mar. 16 mai 2023 à 17:11
-- Version du serveur : 8.0.31
-- Version de PHP : 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `heliobank`
--

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(50) NOT NULL,
  `pin` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `client`
--

INSERT INTO `client` (`id`, `first_name`, `last_name`, `email`, `password`, `pin`) VALUES
(1, 'John', 'Doe', 'johndoe@example.com', 'password123', 1234),
(2, 'Jane', 'Doe', 'janedoe@example.com', 'securepassword', 5678),
(3, 'Bob', 'Smith', 'bobsmith@example.com', 'p@ssw0rd', 9012),
(4, 'Damien', 'Pelaez', 'dpdp@example.com', 'Berna123*', 1293);

-- --------------------------------------------------------

--
-- Structure de la table `currentaccount`
--

DROP TABLE IF EXISTS `currentaccount`;
CREATE TABLE IF NOT EXISTS `currentaccount` (
  `id` int NOT NULL AUTO_INCREMENT,
  `balance` decimal(10,2) NOT NULL DEFAULT '0.00',
  `payment_limit` float NOT NULL,
  `client` int NOT NULL,
  `number` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `client` (`client`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `currentaccount`
--

INSERT INTO `currentaccount` (`id`, `balance`, `payment_limit`, `client`, `number`) VALUES
(1, '200.00', 150, 4, 'BEWDK9-K2WV-YWWD-');

-- --------------------------------------------------------

--
-- Structure de la table `savingaccount`
--

DROP TABLE IF EXISTS `savingaccount`;
CREATE TABLE IF NOT EXISTS `savingaccount` (
  `id` int NOT NULL AUTO_INCREMENT,
  `balance` float NOT NULL,
  `interest_rate` int NOT NULL,
  `client` int NOT NULL,
  `number` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `client` (`client`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `savingaccount`
--

INSERT INTO `savingaccount` (`id`, `balance`, `interest_rate`, `client`, `number`) VALUES
(1, 0, 2, 4, 'BEUQS9-4TZG-DYEI-');

-- --------------------------------------------------------

--
-- Structure de la table `transaction`
--

DROP TABLE IF EXISTS `transaction`;
CREATE TABLE IF NOT EXISTS `transaction` (
  `id` int NOT NULL AUTO_INCREMENT,
  `from_account` varchar(255) DEFAULT NULL,
  `to_account` varchar(255) DEFAULT NULL,
  `amount` float NOT NULL,
  `make` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `type` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `transaction`
--

INSERT INTO `transaction` (`id`, `from_account`, `to_account`, `amount`, `make`, `type`) VALUES
(1, 'distributeur', 'BEWDK9-K2WV-YWWD-', 100, '2023-04-11 18:29:13', ''),
(2, 'distributeur', 'BEWDK9-K2WV-YWWD-', 100, '2023-04-11 18:31:52', 'deposit'),
(3, 'distributeur', 'BEWDK9-K2WV-YWWD-', 100, '2023-04-11 18:41:20', 'deposit');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
