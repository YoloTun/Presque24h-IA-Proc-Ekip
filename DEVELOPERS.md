# Comment contribuer

Vous pouvez vous assigner une issue et commencer à travailler dessus sur votre propre branche quand vous le voulez, assurez-vous simplement de passer par une pull request sur la branche ``dev`` quand vous pensez que votre travail est prêt à être intégré et liez celle-ci à l'issue.

Vous trouverez ci-après les règles particulières au dépôt concernant les contributions.

## Guidelines pour les commits

Le dépôt utilise une GitHub Action pour automatiser son versioning, pour que celle-ci fonctionne correctement il est nécessaire de suivre un format précis pour les commits.

### Format

Premièrement, __il n'est pas nécessaire que chaque commit soit dans ce format, seuls les plus importants sont nécessaires__, cependant plus il y en aura qui suivront cette norme mieux ce sera.

Pour un **correctif de bug** (aucun changement de fonctionnalités, compatible avec ce qui existait précédemment) : les messages doivent prendre ce format :

```
fix({élément modifié}): {titre du commit}

{Description plus longue si nécessaire}
```

Pour une **nouvelle fonctionnalité** c'est la même chose mais on remplace ``fix`` par ``feat`` :

```
feat({élément modifié}): {titre du commit}

{Description plus longue si nécessaire}
```

Finalement pour un changement de **version majeure** (version stable puis tout changement rendant l'API non compatible avec l'ancienne version) :

```
{niveau de modification (ex : feat)}({élément modifié}): {titre du commit}

{Description plus longue si nécessaire}

BREAKING CHANGE: {Explication du changement majeur}
```

### Informations complémentaires

Ce format est requis pour la [GitHub Action de montée de version](https://github.com/marketplace/actions/github-tag).

Les règles exactes de versioning sont celles proposées par SemVer et dont les spécifications détaillées sont indiquées ici : https://semver.org/

Les guidelines de commit utilisées par défaut pour la GitHub Action sont celles d'[Angular](https://github.com/angular/angular.js/blob/master/DEVELOPERS.md#-git-commit-guidelines).