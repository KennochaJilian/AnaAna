APPLICATION ASP.NET Core MVC
Formateurs suivant le projet : Tarik OUALI

 
PRÉSENTATION 
1. Description du projet 
Nous souhaitons mettre en place un site web qui permet de créer et diffuser très simplement des sondages en lignes (cf. http://www.strawpoll.me/ ) 

2. Objectifs du projet 
Créer un site web géré avec ASP.NET Core MVC : 
•	Une première page de garde affiche un message de bienvenu à l’utilisateur. Si l’utilisateur n’est pas déjà connecté, un lien lui permettra de se connecter ou de créer un compte. S’il est connecté, la page affiche la liste des sondages créés précédemment, et un lien lui permet d’accéder à la seconde page de l’application.
•	La seconde page de l’application consiste en un formulaire permettant de créer un nouveau sondage, en saisissant la description du sondage, la liste des choix possibles, ainsi qu’une option permettant de spécifier si le sondage est à choix unique ou multiple. Lors de la validation de ce formulaire, le sondage est créé, trois liens sont générés et spécifiés à l’utilisateur créateur, un lien permettant de désactiver le sondage, un autre lien permettant d’accéder à la page de vote du sondage, et un dernier lien permet d’accéder à la page publique des résultats du sondage. 
o	Un message indique à l’utilisateur ayant créé le sondage qu’il doit précautionneusement garder le lien permettant de désactiver le sondage 
o	Le second lien est le lien que l’administrateur partagera aux gens qu’il compte soumettre au sondage. 

•	Si le lien de désactivation du sondage est appelé, il ne sera plus possible de participer au sondage, et l’utilisateur renvoyé vers la page de résultat du sondage. 
o	Attention, ce lien doit être un minimum « sécurisé ». Un utilisateur ayant eu connaissance du lien de consultation ne doit pas être capable de retrouver le lien de suppression. 

•	Les invitations se font sur adresse email, et le vote se fait après création d’un compte.

•	La gestion de l’authentification avec une gestion par cookie sera suffisante.

•	La page de vote d’un sondage affiche : 
o	La description du sondage 
o	Le nombre de votants 
o	Les choix possibles 

•	L’utilisateur accédant à la page en question peut sélectionner un ou plusieurs choix (selon le mode de sondage sélectionné par le créateur), puis valider son choix. L’utilisateur est alors redirigé vers la page de consultation des résultats du sondage.
o	Attention, il ne doit plus être possible de voter sur un sondage désactivé.
o	Un utilisateur ayant déjà voté doit pouvoir modifier son vote. 

•	La page de consultation affiche la description du sondage, le nombre de votants, la liste des choix possibles classés par nombre de votants (décroissant). 
o	Même si le sondage est désactivé, la consultation des résultats doit être possible. 
o	(optionnel) Une représentation graphique interactive est possible. 
