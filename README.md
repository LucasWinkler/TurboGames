# About
A team project for the Microsoft Enterprise (PROG3050) course at Conestoga College. This is a virtual game store created in ASP.NET Core 2.2 using Model-View-Controller (MVC) and a code-first design. Created by Team TurboGames.

**Team:** TurboGames

**Members:** Lucas W, Cam L, Xander D, and Fernando G

**Using:** ASP.NET Core 2.2 MVC

## How to get started (for team members)

*If you already have the project cloned then skip #1*

1. Open git bash in your current folder and paste: `git clone git@github.com:LucasWinkler/TurboGames-ConestogaVirtualGameStore.git`

You should now have the project in your current folder.

2. You can switch to different branches by typing `git checkout <branch-name>` e.g. `git checkout develop`

You will most likely want to start in the develop branch.

3. Pull the latest changes using `git pull` just incase you don't have them

When you need to work on the project you will add a new branch for that specific feature

4. To do so type: 
```
git checkout -b <feature-name> develop`   <-- e.g. git checkout -b add-games develop (creates new branch based on the develop branch)
git push --set-upstream origin <feature-name>   <-- Pushes the new branch to the remote repository (github)
```

5. Every time you add a decent amount of code type (DO THIS A LOT!!!!):
```
git add .			<-- Adds all changed files
git commit -m "Commit message"		<--	e.g. git commit -m "Added wishlist page"
``` 

The next step should be done almost as often as you commit. 
This way your feature is always up-to-date with github.

6. To push/upload all of your commits to the remote feature branch type: `git push origin <feature-name>`

7. Once you have finished creating your feature type: 
```
git checkout develop
git merge --no-f <feature-name>
git branch -d <feature-name>
git push
```

This will (hopefully) switch to develop, merge your feature branch into develop, delete your feature branch and then push all changes to develop.

Tips: 
`git status` will  return information on new changes.
Mess up when creating a branch and want to remake or rename it? `git checkout develop` then `git branch -D <feature-name>`

