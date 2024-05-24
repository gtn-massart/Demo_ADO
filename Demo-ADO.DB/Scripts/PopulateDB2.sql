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

INSERT INTO [dbo].[Author](Lastname, Firstname)
VALUES
    ('Hugo','Victor'),
    ('Zola','Emile'),
    ('King','Stephen'),
    ('Poe','Edgar Allan')


INSERT INTO [dbo].[Book](Title, Description, AuthorId)
VALUES
    ('Cujo', 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor aut nobis officia maiores, libero deserunt.', 3),
    ('Les misérables', 'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Rerum minima sint delectus harum quos minus?', 1),
    ('Le chat noir', 'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Corrupti minus illo itaque odio, delectus distinctio?', 4),
    ('Germinal', 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolore omnis corporis, voluptatibus voluptates veniam maiores!', 2)