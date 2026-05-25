# MediaTek86

## Présentation
Application de gestion du personnel et des absences développée en C# WinForms avec une architecture MVC et une base de données MySQL.

## Fonctionnalités

==> Authentification
- connexion sécurisée
- affichage / masquage du mot de passe

==> Gestion du personnel
- affichage du personnel
- recherche d'un personnel
- ajout d'un nouveau personnel
- modification d'un personnel existant
- suppression d'un personnel existant

==> Gestion des absences
- affichage des absences
- ajout d'une absence
- modification d'une absence
- suppression d'une absence
- contrôle des dates ainsi que le chevauchement

## Technologies utilisées
- C#
- WinForms
- MySQL
- phpMyAdmin
- Architecture MVC
- Git / GitHub

## Architecture du projet

- model: classes métier
- view: interfaces graphiques WinForms
- controller: gestion des traitements
- dal: accès aux données MySQL
- bddmanager: gestion de la connexion base de données
- installateur: fichiers d'installation de l'application

## Base de données

Base utilisée : mediatek86

## Lancement du projet

1. Importer la base MySQL
2. Vérifier la chaîne de connexion
3. Lancer MediaTek86.exe

## Installation

L'installateur se trouve dans le dossier :

installateur

# Captures d’écran

==> Connexion

![Connexion](captures/connexion.png)

==> Menu

![menu](captures/menu.png)

==> Gestion du personnel

![Personnel](captures/personnel.png)


==> Gestion des absences

![Absences](captures/absences.png)

# Modèle conceptuel de données (MCD)

![MCD](captures/mcd.png)

# Diagramme de paquetages

![Diagramme de paquetages](captures/packages.png)

# Historique des commits

==> Initialisation du projet
- ajout des fichiers du projet

==> Mise en place de l’architecture MVC
- création de la structure MVC
- fusion et correction des classes
- suppression du BddManager en doublon dans le DAL

==> Gestion de l’authentification
- ajout de la connexion responsable
- ouverture de la fenêtre menu
- ajout de l’affichage du mot de passe

==> Gestion du personnel
- affichage de la liste du personnel
- affichage des services dans le ComboBox
- sélection d’un personnel dans le DataGridView
- recherche d’un personnel
- réinitialisation des champs
- contrôle des doublons lors de l’ajout

==> Gestion des absences
- création de la fenêtre absences
- affichage des absences du personnel
- gestion des motifs
- affichage vide au démarrage de la fenêtre

==> Interface graphique
- amélioration du design des fenêtres
- agrandissement des formulaires
- ajout des captures d’écran

==> Documentation et déploiement
- création du README
- ajout du diagramme de paquetage
- ajout du MCD
- ajout du script SQL complet
- création de l’installateur
- tests et nettoyage du code

![commits](captures/commits.png)

# Auteur
Warda SADEQ

Projet réalisé dans le cadre de la formation BTS SIO option SLAM.
