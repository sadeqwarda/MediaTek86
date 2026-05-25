-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : lun. 25 mai 2026 à 14:31
-- Version du serveur : 8.4.7
-- Version de PHP : 8.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `mediatek86`
--
CREATE DATABASE IF NOT EXISTS `mediatek86` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `mediatek86`;

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

CREATE TABLE IF NOT EXISTS `absence` (
  `idpersonnel` int NOT NULL,
  `datedebut` datetime NOT NULL,
  `datefin` datetime DEFAULT NULL,
  `idmotif` int NOT NULL,
  PRIMARY KEY (`idpersonnel`,`datedebut`),
  KEY `idmotif` (`idmotif`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES
(1, '2024-03-04 00:00:00', '2024-03-06 00:00:00', 2),
(1, '2024-05-13 08:00:00', '2024-05-17 17:00:00', 1),
(1, '2024-09-02 08:00:00', '2024-09-06 17:00:00', 4),
(1, '2024-11-18 08:00:00', '2024-11-18 17:00:00', 3),
(13, '2026-05-23 00:00:00', '2026-05-30 00:00:00', 3),
(3, '2026-05-05 00:00:00', '2026-05-25 00:00:00', 1),
(2, '2024-04-08 00:00:00', '2026-04-12 00:00:00', 2),
(2, '2024-07-01 08:00:00', '2024-07-05 17:00:00', 1),
(2, '2026-05-25 00:00:00', '2026-05-25 00:00:00', 4),
(3, '2024-01-22 08:00:00', '2024-01-26 17:00:00', 1),
(3, '2024-03-11 08:00:00', '2024-03-12 17:00:00', 2),
(3, '2024-05-20 00:00:00', '2024-05-21 00:00:00', 3),
(3, '2024-08-05 00:00:00', '2025-08-09 00:00:00', 1),
(4, '2024-02-05 08:00:00', '2024-02-09 17:00:00', 1),
(4, '2024-04-15 08:00:00', '2024-04-16 17:00:00', 2),
(4, '2024-06-10 08:00:00', '2024-06-11 17:00:00', 3),
(4, '2024-09-09 08:00:00', '2024-09-13 17:00:00', 1),
(4, '2024-11-04 08:00:00', '2024-11-08 17:00:00', 4),
(5, '2024-01-29 08:00:00', '2024-02-02 17:00:00', 1),
(5, '2024-03-18 08:00:00', '2024-03-19 17:00:00', 2),
(5, '2024-06-17 08:00:00', '2024-06-18 17:00:00', 3),
(5, '2024-08-19 08:00:00', '2024-08-23 17:00:00', 1),
(5, '2024-10-21 08:00:00', '2024-10-25 17:00:00', 4),
(6, '2024-02-19 08:00:00', '2024-02-23 17:00:00', 1),
(6, '2024-04-22 08:00:00', '2024-04-23 17:00:00', 2),
(6, '2024-07-08 08:00:00', '2024-07-09 17:00:00', 3),
(6, '2024-09-16 08:00:00', '2024-09-20 17:00:00', 1),
(6, '2024-12-09 08:00:00', '2024-12-13 17:00:00', 4),
(7, '2024-03-25 08:00:00', '2024-03-29 17:00:00', 1),
(7, '2024-05-06 08:00:00', '2024-05-07 17:00:00', 2),
(7, '2024-07-15 08:00:00', '2024-07-16 17:00:00', 3),
(7, '2024-08-26 08:00:00', '2024-08-30 17:00:00', 1),
(7, '2024-11-25 08:00:00', '2024-11-29 17:00:00', 4),
(8, '2024-04-29 08:00:00', '2024-04-30 17:00:00', 2),
(8, '2024-06-24 08:00:00', '2024-06-25 17:00:00', 3),
(8, '2024-09-23 08:00:00', '2024-09-27 17:00:00', 1),
(8, '2024-12-16 08:00:00', '2024-12-20 17:00:00', 4),
(9, '2024-01-02 08:00:00', '2024-01-05 17:00:00', 1),
(9, '2024-03-06 08:00:00', '2024-03-07 17:00:00', 2),
(9, '2024-05-27 08:00:00', '2024-05-28 17:00:00', 3),
(9, '2024-07-22 00:00:00', '2024-07-27 00:00:00', 1),
(9, '2024-10-28 08:00:00', '2024-10-31 17:00:00', 4),
(10, '2024-02-01 08:00:00', '2024-02-02 17:00:00', 2),
(10, '2024-04-01 08:00:00', '2024-04-05 17:00:00', 1),
(10, '2024-06-03 08:00:00', '2024-06-04 17:00:00', 3),
(10, '2024-08-12 00:00:00', '2024-08-17 00:00:00', 2),
(10, '2024-11-12 08:00:00', '2024-11-15 17:00:00', 4),
(2, '2026-01-01 00:00:00', '2026-01-19 00:00:00', 2),
(2, '2026-06-04 00:00:00', '2026-06-25 00:00:00', 4);

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

CREATE TABLE IF NOT EXISTS `motif` (
  `idmotif` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idmotif`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`idmotif`, `libelle`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

CREATE TABLE IF NOT EXISTS `personnel` (
  `idpersonnel` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `prenom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `tel` varchar(15) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `mail` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `idservice` int NOT NULL,
  PRIMARY KEY (`idpersonnel`),
  KEY `idservice` (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES
(1, 'Martin', 'Jeanne', '0601010101', 'jean.martin@gmail.com', 1),
(2, 'Bernard', 'jeanne', '0602020202', 'claire.bernard@hotmail.com', 1),
(22, 'sadeq', 'maud', '0652525286', 'w.tse@2test.fr', 2),
(4, 'Thomas', 'Emma', '0604040404', 'emma.thomas@gmail.com', 2),
(5, 'Robert', 'Hugo', '0605050505', 'hugo.robert@hotmail.com', 3),
(6, 'Richard', 'Manon', '0606060607', 'manon.richard@outlook.com', 3),
(20, 'sade', 'warda', 'test', 'w.mail@test.fr', 2),
(8, 'Durand', 'Léa', '0608080808', 'lea.durand@hotmail.com', 2),
(9, 'Moreau', 'Tom', '0609090909', 'tom.moreau@outlook.com', 3),
(10, 'Laurent', 'Inès', '0610101018', 'ines.laurent@gmail.com', 3),
(13, 'Dubois', 'Lucas', '0603030303', 'lucas.dubois@outlook.com', 2),
(21, 'sade', 'wardo', 'test', 'w.mail@test.fr', 2),
(15, 'karin', 'jean', '0652777777', 'karin@test.fr', 2),
(17, 'Dubois', 'Lucas', '0603030303', 'lucas.dubois@outlook.com', 2),
(19, 'sad', 'jamal', '0666655266', 'test@gmail.com', 1);

-- --------------------------------------------------------

--
-- Structure de la table `responsable`
--

CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `pwd` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES
('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

CREATE TABLE IF NOT EXISTS `service` (
  `idservice` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`idservice`, `nom`) VALUES
(1, 'administratif'),
(2, 'médiation culturelle'),
(3, 'prêt');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
