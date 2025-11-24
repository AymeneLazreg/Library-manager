Parfait ! Avec tous ces fichiers `.cs` et ton designer, je te propose un **README.md complet** pour ton projet **Library Manager Lite** qui explique l’ensemble des fonctionnalités, la structure et le fonctionnement.

Voici le fichier prêt à copier-coller :

---

# 📚 Library Manager Lite

**Library Manager Lite** est une application Windows Forms (C# / .NET Framework) permettant de gérer des utilisateurs, leurs informations personnelles, ainsi que les enregistrements liés aux activités ou objets associés à chaque utilisateur.

---

## 🚀 Fonctionnalités principales

### Gestion des utilisateurs

* Création de nouveaux comptes utilisateurs.
* Modification des informations existantes.
* Affichage complet des données utilisateur :

  * Numéro d’identification
  * Nom
  * Prénom
  * Date de naissance
  * Adresse
  * Téléphone
* Gestion des fichiers associés pour chaque utilisateur (`<NomUtilisateur>`, `<NomUtilisateur>_saveFile`, `<NomUtilisateur>_LogFile`).

### Historique et actions

* Ajout et suppression d’éléments dans les listes d’activités ou objets.
* Journaux de modifications et actions des utilisateurs.
* Sauvegarde automatique des fichiers au clic ou lors de la fermeture du formulaire.

### Interface utilisateur

* Formulaires principaux :

  * `Main` : Accueil et navigation vers les fonctionnalités principales.
  * `registerForm` : Formulaire d’enregistrement d’un nouvel utilisateur.
  * `UserList` : Liste des utilisateurs et modification des informations.
  * `work` : Gestion des activités ou objets pour chaque utilisateur.
* ListBox, RichTextBox et TextBox pour l’affichage et l’édition des informations.
* Boutons pour recharger, appliquer les changements, enregistrer et supprimer des entrées.

---

## 📁 Structure des fichiers

### Fichiers principaux

* `Main.cs` : Formulaire principal avec navigation.
* `registerForm.cs` : Création de nouveaux comptes utilisateurs.
* `UserList.cs` : Gestion et modification des utilisateurs existants.
* `work.cs` : Gestion des objets ou activités par utilisateur.
* `*.Designer.cs` : Contient le code généré par le designer Windows Forms.

### Fichiers de données

* `list.txt` : Contient la liste de tous les utilisateurs.
* `<NomUtilisateur>` : Fichier contenant les informations personnelles de l’utilisateur.
* `<NomUtilisateur>_saveFile` : Fichier sauvegardant les objets ou activités en cours.
* `<NomUtilisateur>_LogFile` : Journal des actions effectuées sur les objets ou activités.
* `number.txt` : Compteur du numéro d’utilisateur courant.

---

## 🔧 Fonctionnement interne

### Création et modification d’utilisateur

* Lors de l’enregistrement, un fichier temporaire `test.txt` est créé avec les informations saisies.
* Le compteur utilisateur (`number.txt`) est incrémenté.
* Le fichier temporaire est renommé avec le numéro d’utilisateur.
* Les fichiers `_saveFile` et `_LogFile` sont créés pour l’historique et les sauvegardes.

### Parsing des informations

* Les données sont séparées par des délimiteurs :

  * `:` pour séparer le nom de la donnée et sa valeur.
  * `;` pour marquer la fin d’une valeur.
  * `@` pour séparer le numéro utilisateur du reste des données.
* Exemple :

  ```
  1@
  Name :John;
  Surname :Doe;
  Birth Date :12/08/2000;
  Adress :123 Street;
  Phone :0612345678;
  Registered on : 24/11/2025 13:10:22
  ```

### Gestion des activités (`work.cs`)

* Ajout d’un objet ou action dans `listBox2`.
* Chaque action est enregistrée dans `listBox3` avec un timestamp.
* Sauvegarde automatique des fichiers `_saveFile` et `_LogFile` lors de la fermeture du formulaire.

---

## 🛠 Technologies utilisées

* **Langage** : C#
* **Framework** : .NET Framework 4.x
* **Interface** : Windows Forms
* **Stockage** : Fichiers texte (StreamReader / StreamWriter)

---

## ⚠️ Bugs connus et limitations

* Les fichiers temporaires (`test.txt`) doivent exister pour certaines opérations.
* Le Designer Visual Studio peut générer des erreurs si un contrôle porte le nom `Name` (conflit avec la propriété `Form.Name`).

  * **Solution** : Renommer le TextBox `Name` en `NameBox`.
* Gestion minimale des exceptions sur les fichiers manquants ou en lecture seule.

---

## 🔮 Améliorations possibles

* Migration vers un format JSON ou XML pour plus de flexibilité.
* Ajout d’un système de recherche ou de filtres.
* Modernisation de l’interface (WPF, WinUI).
* Sécurisation des fichiers (permissions, hash, validation).

---

## 🧑‍💻 Auteur

Développé dans le cadre d’un projet de gestion simplifiée d’utilisateurs et de leurs activités.

---

Si tu veux, je peux te faire **une version visuelle améliorée du README avec captures d’écran et diagramme du flux de données** pour que ça ait un style plus professionnel.

Veux‑tu que je fasse ça ?
