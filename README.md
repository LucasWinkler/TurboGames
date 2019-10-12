# About
This is the virtual game store project for Microsoft Enterprise (PROG3050) at Conestoga College. 

**Team:** TurboGames

**Members:** Lucas W, Cam L, Xander D, and Fernando G

**Using:** ASP.NET Core 2.2 MVC

## How to get started (for team members)

*If you already have the project cloned then skip #1*

1. Open git bash in your current folder and paste: `git clone git@github.com:LucasWinkler/TurboGames-ConestogaVirtualGameStore.git`

You should now have the project in your current folder.

2. You can switch to different branches by typing `git checkout <branch-name>` e.g. `git checkout development`

You will most likely want to start in the development branch.

3. Pull the latest changes using `git pull` just incase you don't have them

When you need to work on the project you will add a new branch for that specific feature

4. To do so type: `git checkout -b <feature-name> development` e.g. `git checkout -b add-games development`

5. Every time you add a decent amount of code and you want to save that type:
```
git add .			<-- Adds all changed files
git commit -m "Commit message"		<--	e.g. git commit -m "Added wishlist page"
``` 

6. To push/upload all of your commits to the remote feature branch type: `git push origin <feature-name>`

7. Once you have finished creating your feature type: 
```
git checkout development
git merge --no-f <feature-name>
git branch -d <feature-name>
git push
```

This will (hopefully) switch to development, merge your feature branch into development, delete your feature branch and then push all changes to development.



