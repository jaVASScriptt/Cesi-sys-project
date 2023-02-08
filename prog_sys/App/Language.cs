using System;
using System.Globalization;

static class Language
{
    static string selectedLanguage;

    public static void setLanguage(string inputLanguage)
    {
        selectedLanguage = inputLanguage;
    }

    public static string defaultMessage()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "pour créer une sauvegarde, entrer la commande 'save'\n" +
                    "pour acceder au menu de sauvegarde pré-initialiser, entrer 'menu'\n" +
                    "pour changer de langue, entrer 'language'\n" +
                    "pour stopper l'application, entrer 'exit'";
                break;
            case "2":
                message = "to create a backup, use the command 'save'\n" +
                    "to acces pre-initialized saved menu, use 'menu'\n" +
                    "to change language, use 'language'\n" +
                    "to exit the app, use 'exit'";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string saveNameMessage()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "donner un nom pour la sauvegarde";
                break;
            case "2":
                message = "choose a name for the save";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string originPathMessage()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "donnez le chemin d'acces des fichiers a copier";
                break;
            case "2":
                message = "give the path of files to save ";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string targetPathMessage()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "donnez le chemin d'acces ou les fichiers vont se copier";
                break;
            case "2":
                message = "give the path where files will be saved";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string errorCreatingFiles()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "Erreur lors de la création des fichiers log et state : ";
                break;
            case "2":
                message = "Error when creating log and state files";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string featureMenu()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "\nQue souhaitez-vous faire ?\n" +
                    "1 - Créer un nouveau travail de sauvegarde\n" +
                    "2 - Modifier un travail de sauvegarde\n" +
                    "3 - Supprimer un travail de sauvegarde\n" +
                    "4 - Supprimer tout les travaux de sauvegarde\n" +
                    "5 - quitter le management des travaux sauvegarde\n";
                break;
            case "2":
                message = "\nWhat do you want to do\n" +
                    "1 - create a new save work\n" +
                    "2 - edit a save work\n" +
                    "3 - delete a save work\n" +
                    "4 - delete all saves work\n" +
                    "5 - leave save work manager\n";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }
}