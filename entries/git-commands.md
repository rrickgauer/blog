

## Branches

### Creating a new branch

To create a new branch and then switch to it:

```shell
git checkout -b newBranchName
```

From here, you can do all the changes you want in the branch including doing commits. They will be added to the branch.


### Work on an existing branch

If you already have a branch and you want to work on it, you can switch to it by using:

```shell
git checkout branchName
```

### Pushing changes to the new branch

When you are ready to push your *first* commits to the new branch, do the following:

```shell
git push --set-upstream origin newBranchName
```

This will push your commits to your new branch and set the upstream to your new branch. After this first push, any subsequent commit pushes you want to make to your new branch you can just do the normal push:

```shell
git push
```

### Merging a branch

When you are ready to merge a branch into another, go to your repository on GitHub and it will walk you through the steps.

After that, you need to reconcile your changes onto your local repo. To do this, *switch to the master branch* and use these commands:

```shell
git add *
git stash
git pull
```

### Additional commands

To list the local branches:

```shell
git branch
```

To delete a local branch:

```shell
git branch -d <branch_name>
```

