using System;
using System.Globalization;

class Language
{
    string selectedLanguage;

    public Language(string selectedLanguage)
    {
        this.selectedLanguage = selectedLanguage;
    }

    public string defaultMessage()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "pour créer une sauvegarde, entrer la commande 'save'\n" +
                    "pour changer de langue, entrer 'language'\n" +
                    "pour stopper l'application, entrer 'exit'";
                break;
            case "2":
                message = "to create a backup, use the command 'save'\n" +
                    "to change language, use 'language'\n" +
                    "to exit the app, use 'exit'";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public string saveNameMessage()
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

    public string numberOfFilesToSaveMessage()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "combien de fichiers à sauvegarder ?";
                break;
            case "2":
                message = "how many files to save ?";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public string originPathMessage()
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

    public string targetPathMessage()
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

    public string fileNameMessage()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "nom du fichier a sauvegarder";
                break;
            case "2":
                message = "name of the file to save";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }
}