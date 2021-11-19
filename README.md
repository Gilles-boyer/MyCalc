# Premiers Pas en C#

## Pour Générer le Projet : 
### Prérequis :
 - Avoir Visual Studio
### Process : 
- git Clone du projet de
- Ouvrir le projet avec visual studio : Fichier=>Ouvir=>Projet/Solution =>MyCalc.csproj
- Dans l'explorateur de solution Click Droit sur MyCalc => Regénérer

## Detail du Projet :
Il s’agit d'écrire un programme qui fasse la même chose que la Calculatrice livrée avec Windows, dans sa version "standard". </br>
Pour simplifier encore un peu le développement On ne développera pas le menu, ni l’aide, ni les fonctions suivantes : 
"MC", "MR", "MS"."M+" 
</br> La calculatrice ressemblera donc à ceci :</br>
![Calculatrice](img/calculatrice.png)

## Contrainte :
	- Projet à effectuer en une journée
	- Projet Individuel
	- Un lien vers un répertoire git du projet
	- Le résultat final doit avoir exactement les mêmes composants d'interface   Calculatrice que l'image ci-dessus (Veuillez trouver, en pièce jointe). 
	- Tous les buttons doit fonctionner correctement.

## Difficulté :
	- L'apprentissage d'un nouveau language
	- Les notions des éléments graphiques xaml
	- Logique de gestion du fonctionnement

## Pour aller plus loin :
	- Création des mèthodes : MC/MR/MS/M+
	- voir pour definir double avec un point et non une virgule
	[x] Avoir un Historique d'affichage (réalisé le 18/11)
	[en cours] Créer un système de licence utilisateur avec une api


## Api test pour login en post:
https://apimycalc974.000webhostapp.com/ </br>
Creation d'un fichier dans le dossier doc pour simuler la connexion avec une api avec une requete post .</br>
Token Test : "396bebd7-5831-416c-9560-ea5b44ac5301"

## Logique de la calculatrice:
-> Traitement l'affichage en String</br>
-> Utilisation de double pour faire les opérations</br>
-> opération de type a + b = ab ensuite a = ab</br>

## Screen Application

### First Start App : 
![FirstStart](img/firstStart.png)
### Click "Alt" pour afficher l'espace licence:
![ClickAlt](img/clickAlt.png)
### Test si licence est vide:
![LicenceEmpty](img/licenceEmpty.png)
### Test si licence n'est pas Valide:
![LicenceNotGood](img/licenceNotGood.png)
### Licence Valide : 
![FirstStart](img/licenceGreat.png)
### Enjoy : 
![FirstStart](img/enjoy.png)