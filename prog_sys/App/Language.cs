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
                message = "pour cr�er une sauvegarde, entrer la commande 'save'\n" +
                    "pour acceder au menu de sauvegarde pr�-initialiser, entrer 'menu'\n" +
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

    public static string saveType()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "Quel sera le type de sauvegarde ? (1: complete, 2: differential)";
                break;
            case "2":
                message = "What type will the save be ? (1: complete, 2: differentiel)";
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
                message = "Erreur lors de la cr�ation des fichiers log et state : ";
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
                    "1 - Cr�er un nouveau travail de sauvegarde\n" +
                    "2 - Modifier un travail de sauvegarde\n" +
                    "3 - Supprimer un travail de sauvegarde\n" +
                    "4 - Supprimer tout les travaux de sauvegarde\n" +
                    "5 - faire une sauvegarde\n"+
                    "6 - Ajouter un emplacement de travail de sauvegarde\n"+
                    "7 - Supprimer un emplacement de travail de sauvegarde\n"+
                    "8 - quitter le management des travaux sauvegarde\n";
                break;
            case "2":
                message = "\nWhat do you want to do\n" +
                    "1 - create a new save work\n" +
                    "2 - edit a save work\n" +
                    "3 - delete a save work\n" +
                    "4 - delete all saves work\n" +
                    "5 - do a save\n"+
                    "6 - add a save work location\n"+
                    "7 - delete a save work location\n"+
                    "8 - quit save work management\n";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string numberSaveWork()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "veuillez indiquer le numero (0-4) du travail de sauvegarde vous souhaitez �diter : ";
                break;
            case "2":
                message = "select the number (0-4) where save work will be edited";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string editSaveWork()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = " (laisser vide pour ne pas modifier)";
                break;
            case "2":
                message = " (let empty to not modify)";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string deleteSaveWork()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "Quel travail de sauvegarde souhaitez-vous supprimer ?";
                break;
            case "2":
                message = "Which save work do you want to delete ?";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string deleteAllSaveWork()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "Etes-vous s�r de vouloir supprimer tout les travaux de sauvegarde ? (1: oui, 2: non)";
                break;
            case "2":
                message = "Are you sure you want to delete all saves works ? (1: yes, 2: no)";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string indexNotExist()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "l'index doit �tre compris entre 0 et 4";
                break;
            case "2":
                message = "index must be between 0 and 4";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string workDeleted()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "la t�che n'existe pas";
                break;
            case "2":
                message = "work doesn't exist";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string saveDeleted()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "t�che supprim�e";
                break;
            case "2":
                message = "work deleted";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string unvalidMessage()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "entr�e invalide";
                break;
            case "2":
                message = "unvalid input";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string unvalidMessageExample()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = ", entr�e attendu : ";
                break;
            case "2":
                message = ", required input : ";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string noEmpty()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "L'entr�e ne peut pas �tre vide";
                break;
            case "2":
                message = "input can't be empty";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string confirmDelete()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "voulez vous �craser la t�che ? (y/n)";
                break;
            case "2":
                message = "Do you want to erease the save work ? (y/n)";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string taskAdded()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "T�che ajout�e";
                break;
            case "2":
                message = "save work added";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string taskNotAdded()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "Impossible d'ajouter la tache! : ";
                break;
            case "2":
                message = "Can't add task! : ";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string taskConfig()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "Voici les configurations actuelles :";
                break;
            case "2":
                message = "Here's the configurations :";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }

    public static string noTask()
    {
        string message;
        switch (selectedLanguage)
        {
            case "1":
                message = "] [vide]";
                break;
            case "2":
                message = "] [empty]";
                break;
            default:
                message = "unknown language use 'language' to change language or 'exit' to exit the app";
                break;
        }
        return message;
    }
    
}