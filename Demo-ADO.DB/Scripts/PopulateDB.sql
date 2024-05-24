/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO [dbo].[Type] 
VALUES
    ('Normal'),
    ('Feu'),
    ('Plante'),
    ('Eau'),
    ('Eletrik'),
    ('Poison'),
    ('Vol');

INSERT INTO [dbo].[Pokemon]([Name], Height, [Weight], Type1Id, Type2Id)
VALUES 
    ('Bulbizarre', 70, 7, 3, 6),
    ('Nosferalto', 160, 55, 6, 7),
    ('Pikachu', 40, 6, 5, null);