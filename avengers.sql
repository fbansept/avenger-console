-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Mer 01 Avril 2020 à 07:45
-- Version du serveur :  5.7.11
-- Version de PHP :  5.6.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `avengers`
--

-- --------------------------------------------------------

--
-- Structure de la table `civil`
--

CREATE TABLE `civil` (
  `id` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `civil`
--

INSERT INTO `civil` (`id`) VALUES
(10),
(11),
(12);

-- --------------------------------------------------------

--
-- Structure de la table `droit`
--

CREATE TABLE `droit` (
  `id` int(10) NOT NULL,
  `nom` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `droit`
--

INSERT INTO `droit` (`id`, `nom`) VALUES
(1, 'supression_utilisateur'),
(2, 'affichage_utilisateur');

-- --------------------------------------------------------

--
-- Structure de la table `droit_utilisateur`
--

CREATE TABLE `droit_utilisateur` (
  `id_droit` int(10) NOT NULL,
  `id_utilisateur` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `droit_utilisateur`
--

INSERT INTO `droit_utilisateur` (`id_droit`, `id_utilisateur`) VALUES
(1, 10),
(2, 11);

-- --------------------------------------------------------

--
-- Structure de la table `evaluation`
--

CREATE TABLE `evaluation` (
  `id` int(10) NOT NULL,
  `id_super_hero` int(10) NOT NULL,
  `id_redacteur` int(10) NOT NULL,
  `note` int(5) NOT NULL,
  `comentaire` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `evaluation`
--

INSERT INTO `evaluation` (`id`, `id_super_hero`, `id_redacteur`, `note`, `comentaire`) VALUES
(4, 1, 10, 15, 'pas mal');

-- --------------------------------------------------------

--
-- Structure de la table `incident`
--

CREATE TABLE `incident` (
  `id` int(10) NOT NULL,
  `nom` varchar(255) NOT NULL,
  `civil_id` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `incident`
--

INSERT INTO `incident` (`id`, `nom`, `civil_id`) VALUES
(1, 'kidnaping', 4),
(2, 'vol', 4),
(3, 'vol a main armé', 2);

-- --------------------------------------------------------

--
-- Structure de la table `super_hero`
--

CREATE TABLE `super_hero` (
  `id` int(10) NOT NULL,
  `id_civil` int(10) DEFAULT NULL,
  `super_nom` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `super_hero`
--

INSERT INTO `super_hero` (`id`, `id_civil`, `super_nom`) VALUES
(1, 11, 'iron man');

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

CREATE TABLE `utilisateur` (
  `id` int(11) NOT NULL,
  `nom` varchar(255) NOT NULL,
  `prenom` varchar(255) NOT NULL,
  `civilite` enum('Monsieur','Madame','Mademoiselle') DEFAULT 'Monsieur',
  `email` varchar(255) DEFAULT NULL,
  `mot_de_passe` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `utilisateur`
--

INSERT INTO `utilisateur` (`id`, `nom`, `prenom`, `civilite`, `email`, `mot_de_passe`) VALUES
(10, 'BANSEPT', 'franck', 'Monsieur', 'bansept.franck@gmail.com', 'root'),
(11, 'Stark', 'Tony', 'Monsieur', 'tony@starx.com', 'root'),
(12, 'LaCompta', 'Ginette', 'Madame', 'ginette@avenger.com', 'root');

--
-- Index pour les tables exportées
--

--
-- Index pour la table `civil`
--
ALTER TABLE `civil`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `droit`
--
ALTER TABLE `droit`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `droit_utilisateur`
--
ALTER TABLE `droit_utilisateur`
  ADD PRIMARY KEY (`id_droit`,`id_utilisateur`),
  ADD KEY `utilisateur_droit` (`id_utilisateur`);

--
-- Index pour la table `evaluation`
--
ALTER TABLE `evaluation`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_super_hero` (`id_super_hero`),
  ADD KEY `id_redacteur` (`id_redacteur`);

--
-- Index pour la table `incident`
--
ALTER TABLE `incident`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `super_hero`
--
ALTER TABLE `super_hero`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_civil` (`id_civil`);

--
-- Index pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `droit`
--
ALTER TABLE `droit`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT pour la table `evaluation`
--
ALTER TABLE `evaluation`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT pour la table `incident`
--
ALTER TABLE `incident`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT pour la table `super_hero`
--
ALTER TABLE `super_hero`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `civil`
--
ALTER TABLE `civil`
  ADD CONSTRAINT `utilisateur_civil` FOREIGN KEY (`id`) REFERENCES `utilisateur` (`id`);

--
-- Contraintes pour la table `droit_utilisateur`
--
ALTER TABLE `droit_utilisateur`
  ADD CONSTRAINT `droit_utilisateur` FOREIGN KEY (`id_droit`) REFERENCES `droit` (`id`),
  ADD CONSTRAINT `utilisateur_droit` FOREIGN KEY (`id_utilisateur`) REFERENCES `utilisateur` (`id`);

--
-- Contraintes pour la table `evaluation`
--
ALTER TABLE `evaluation`
  ADD CONSTRAINT `id_super_hero_evaluation` FOREIGN KEY (`id_super_hero`) REFERENCES `super_hero` (`id`),
  ADD CONSTRAINT `redacteur_evaluation` FOREIGN KEY (`id_redacteur`) REFERENCES `utilisateur` (`id`);

--
-- Contraintes pour la table `super_hero`
--
ALTER TABLE `super_hero`
  ADD CONSTRAINT `civil_super_hero` FOREIGN KEY (`id_civil`) REFERENCES `civil` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
